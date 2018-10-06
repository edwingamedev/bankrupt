using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //classes
    private Board board;
    private Bank bank;
    private UnitPool units;

    //configs
    private int numOfPlayers = 4;
    private int numOfBoardSpaces = 20;
    private int lapMoney = 100;
    private int startingMoney = 300;

    //file
    private string gameConfigPath;
    private string gameConfigFileNamePath = "\\gameConfig.txt";

    private void Awake()
    {
        gameConfigPath = System.IO.Directory.GetCurrentDirectory() + gameConfigFileNamePath;
        Debug.LogFormat("Game Config file path \"{0}\"", @gameConfigPath);
    }

    void Start()
    {
        //create a board
        SetupBoard();

        //create a bank
        bank = new Bank(lapMoney);

        //create unit pool
        units = new UnitPool(numOfPlayers, startingMoney);
    }

    void Update()
    {

    }

    private void SetupBoard()
    {
        board = new Board(numOfBoardSpaces, gameConfigPath);
        board.GetAllSpaces();
    }
}
