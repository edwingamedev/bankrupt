using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public Space[] spaces;

    //create a board with spaces
    public Board(int numOfSpaces, string gameConfigPath)
    {
        spaces = new Space[numOfSpaces];

        Debug.Log(string.Format("Board Generated with {0} spaces", spaces.Length));

        //Space Setup
        AssignSpacesConfig(gameConfigPath);
    }

    private void AssignSpacesConfig(string gameConfigPath)
    {
        //read file
        string line = FileReader.ReadTextFile(gameConfigPath);

        string[] lines = line.Split('\n');

        //read and load the configuration for each space of the board
        for (int i = 0; i < spaces.Length; i++)
        {
            //get first and second entries split by x number of empty spaces
            string cost = lines[i].Substring(0, lines[i].IndexOf(' '));
            string rent = lines[i].Substring(lines[i].LastIndexOf(' '));

            spaces[i] = new Space(int.Parse(cost), int.Parse(rent));
        }
    }

    public void GetAllSpaces()
    {
        string log = "Board Spaces\n";

        for (int i = 0; i < spaces.Length; i++)
        {
            if (spaces[i] != null)
                log += string.Format("Space {0}: Owner: {1}, Cost: {2}, Rent: {3}\n", i, spaces[i].buildingSite.Owner, spaces[i].buildingSite.Cost, spaces[i].buildingSite.Rent);
        }

        Debug.Log(log);
    }
}
