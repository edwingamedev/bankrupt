using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //classes
    private Board board;
    private Bank bank;
    private UnitPool units;
    private GameStatistics gameStatistics;

    //configs
    private int numOfPlayers = 4;
    private int numOfBoardSpaces = 20;
    private int lapMoney = 100;
    private int startingMoney = 300; // coins
    private int gameDuration = 1000; //rounds 1000
    private int numOfMatchs = 300;// 300;
    private int numOfDiceFaces = 6;

    //file
    private string gameConfigPath;
    private string gameConfigFileNamePath = "\\gameConfig.txt";

    private bool hasWinner = false;

    private void Awake()
    {
        gameConfigPath = System.IO.Directory.GetCurrentDirectory() + gameConfigFileNamePath;
        Debug.LogFormat("Game Config file path \"{0}\"", @gameConfigPath);
    }

    void Start()
    {
        //create statistics
        gameStatistics = new GameStatistics();

        //Play game for a num of Matchs
        for (int i = 0; i < numOfMatchs; i++)
        {
            NewGame();
        }

        gameStatistics.ShowStatistics();
    }

    public void NewGame()
    {
        //reset winner
        hasWinner = false;

        //create a board
        SetupBoard();

        //create a bank
        bank = new Bank(lapMoney);

        //create unit pool
        units = new UnitPool(numOfPlayers, startingMoney, BankRupt);

        //play game
        Play();
    }

    private void Play()
    {
        Unit _unit;
        BuildingSite _site;
        int _newPosition;

        //Turns
        for (int i = 0; i < gameDuration; i++)
        {
           // Debug.LogWarning((i + 1) + " Turn");

            //Each Player Turn
            for (int j = 0; j < units.NumOfPlayers(); j++)
            {
                //get a unit
                _unit = units.GetUnitByIndex(j);

                //roll dice and store new position
                _newPosition = _unit.RollDice(numOfDiceFaces);

                //move to new position clamping board spaces
                _unit.Move(_newPosition % numOfBoardSpaces);

                //checks for lap completion
                if (_newPosition >= numOfBoardSpaces)
                {
                    //receve money
                    bank.ReceiveMoneyForCompleteLap(_unit);

                    ///Debug.LogFormat("Unit {0}: received ${1}", _unit.Id, lapMoney);
                }

                //check buildingSite position
                _site = board.spaces[_unit.Location].buildingSite;

                //checks if property dont have a owner
                if (_site.Owner == -1)
                {
                    //no owner property
                    _unit.WillBuySite(_site);
                }
                else if (_site.Owner != _unit.Id)
                {
                    bank.PayRent(_unit, units.GetUnitById(_site.Owner), _site);
                }

                //checks if has winner
                if (units.NumOfPlayers() <= 1)
                {
                    hasWinner = true;
                    break;
                }
            }

            //checks if has winner
            if (hasWinner)
            {
                gameStatistics.AddTurn(i);
                break;
            }
        }

        //statistics duration
        if (!hasWinner)
        {
            gameStatistics.AddTurn(gameDuration);
        }

        //statistics timed out
        gameStatistics.AddTimeOut(!hasWinner);

        ShowResults();
    }

    private void BankRupt(int id)
    {
        Unit unit = units.GetUnitById(id);

        //Debug.LogWarning("#" + unit.properties.Count);

        //return to properties for purchase
        for (int i = unit.properties.Count; i > 0; i--)
        {
            //Debug.LogWarningFormat("return property {0}", unit.properties[i - 1]);

            //return site
            board.spaces[unit.properties[i - 1]].buildingSite.Return();

        }

        for (int i = unit.properties.Count; i > 0; i--)
        {
            //remove from unit
            unit.properties.Remove(i);
        }

        //remove unit from pool
        units.RemoveUnit(id);
    }

    private void ShowResults()
    {
        Unit _unit;
        Unit winner = units.GetUnitByIndex(0);
        //Debug.LogWarning("Results " + (!hasWinner ? "timed out" : ""));

        for (int i = 0; i < units.NumOfPlayers(); i++)
        {
            _unit = units.GetUnitByIndex(i);

            //assign winner
            if (_unit.Coins > winner.Coins)
            {
                winner = _unit;
            }

           // Debug.LogFormat("{0} {1}: ${2}, properties #{3}", _unit, _unit.Id, _unit.Coins, _unit.properties.Count);
        }

        //statistics winner
        gameStatistics.AddWinner(winner);

        //Debug.LogFormat("Winner {0} {1}", winner, winner.Id);
    }

    private void SetupBoard()
    {
        board = new Board(numOfBoardSpaces, gameConfigPath);
        board.GetAllSpaces();
    }
}
