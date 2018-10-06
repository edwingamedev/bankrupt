using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //classes
    private Board board;
    private Bank bank;

    //configs
    private int numOfBoardSpaces = 20;
    private int lapMoney = 300;

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
