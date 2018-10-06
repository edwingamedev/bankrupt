using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public Space[] spaces;

    //create a board with spaces
    public Board(int numOfSpaces)
    {
        spaces = new Space[numOfSpaces];

        Debug.Log(string.Format("Board Generated with {0} spaces", spaces.Length));

        //Space Setup
        AssignSpacesConfig();
    }

    private void AssignSpacesConfig()
    {
        //read and load the configuration for each space of the board
        for (int i = 0; i < spaces.Length; i++)
        {
            spaces[i] = new Space(0, 1);
        }
    }

    public void GetAllSpaces()
    {
        string log = string.Empty;

        for (int i = 0; i < spaces.Length; i++)
        {
            if (spaces[i] != null)
                log += string.Format("Space {0}: Owner: {1}, Cost: {2}, Rent: {3}\n", i, spaces[i].buildingSite.Owner, spaces[i].buildingSite.Cost, spaces[i].buildingSite.Rent);
        }

        Debug.Log(log);
    }
}
