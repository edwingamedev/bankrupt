using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Board board;
    private int numOfBoardSpaces = 20;

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
        board = new Board(numOfBoardSpaces);

        board.GetAllSpaces();
    }
}
