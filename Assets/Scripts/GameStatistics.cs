using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStatistics
{
    private List<int> numOfTurn;
    private List<Unit> winner;
    private List<bool> matchTimedOut;

    // 0 Madcap
    // 1 Picky
    // 2 Wary
    // 3 Stochastic
    private int[] numOfWinner;

    public GameStatistics()
    {
        numOfTurn = new List<int>();
        winner = new List<Unit>();
        matchTimedOut = new List<bool>();
        numOfWinner = new int[4];
    }

    public void AddTurn(int value)
    {
        numOfTurn.Add(value);
    }

    public void AddWinner(Unit unit)
    {
        winner.Add(unit);
    }

    public void AddTimeOut(bool hasTimedOut)
    {
        matchTimedOut.Add(hasTimedOut);
    }

    private int NumOfTimedOut()
    {
        int num = 0;

        foreach (var item in matchTimedOut)
        {
            if (item)
            {
                num++;
            }
        }

        return num;
    }

    private int AverageTurns()
    {
        int count = 0;

        for (int i = 0; i < numOfTurn.Count; i++)
        {
            count += numOfTurn[i];
        }

        return count / numOfTurn.Count;
    }

    private string MostWinner()
    {
        //i did this way instead of linq for performance purposes

        // 0 Madcap
        // 1 Picky
        // 2 Wary
        // 3 Stochastic

        for (int i = 0; i < winner.Count; i++)
        {
            if (winner[i].GetType().Equals(typeof(Madcap)))
            {
                numOfWinner[0]++;
            }
            else if (winner[i].GetType().Equals(typeof(Picky)))
            {
                numOfWinner[1]++;
            }
            else if (winner[i].GetType().Equals(typeof(Wary)))
            {
                numOfWinner[2]++;
            }
            else if (winner[i].GetType().Equals(typeof(Stochastic)))
            {
                numOfWinner[3]++;
            }
        }

        int maxValue = numOfWinner.Max();

        switch (numOfWinner.ToList().IndexOf(maxValue))
        {
            default:
            case 0:
                return string.Format("{0} with #{1} wins", "Madcap", maxValue);
            case 1:
                return string.Format("{0} with #{1} wins", "Picky", maxValue);
            case 2:
                return string.Format("{0} with #{1} wins", "Wary", maxValue);
            case 3:
                return string.Format("{0} with #{1} wins", "Stochastic", maxValue);
        }
    }

    private void WinPercentagePerUnit()
    {
        Debug.LogFormat("Madcap #{0} wins, win rate {1}%", numOfWinner[0], (numOfWinner[0] / (float)numOfTurn.Count) * 100);
        Debug.LogFormat("Picky #{0} wins, win rate {1}%", numOfWinner[1], (numOfWinner[1] / (float)numOfTurn.Count) * 100);
        Debug.LogFormat("Wary #{0} wins, win rate {1}%", numOfWinner[2], (numOfWinner[2] / (float)numOfTurn.Count) * 100);
        Debug.LogFormat("Stochastic #{0} wins, win rate {1}%", numOfWinner[3], (numOfWinner[3] / (float)numOfTurn.Count) * 100);
    }

    public void ShowStatistics()
    {
        /*
           Quantas partidas terminam por time out (1000 rodadas);
           Quantos turnos em média demora uma partida;
           Qual a porcentagem de vitórias por comportamento dos jogadores;
           Qual o comportamento que mais vence.
         */

        Debug.LogWarning("Game Statistics");

        Debug.Log("Timed out matchs: " + NumOfTimedOut());
        Debug.Log("Average turns on matchs: " + AverageTurns());
        Debug.Log("The most winner: " + MostWinner());
        Debug.Log("Win percentage");
        WinPercentagePerUnit();
    }
}
