using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Board board;
    private int numOfBoardSpaces = 20;
    private string gameConfigPath;
    private string gameConfigFileNamePath = "\\gameConfig.txt";

    private void Awake()
    {
        gameConfigPath = System.IO.Directory.GetCurrentDirectory() + gameConfigFileNamePath;
        Debug.LogFormat("Game Config file path \"{0}\"", @gameConfigPath);
    }

    // Use this for initialization
    void Start()
    {
        SetupBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupBoard()
    {
        board = new Board(numOfBoardSpaces, gameConfigPath);
        board.GetAllSpaces();
    }
}
