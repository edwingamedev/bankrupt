﻿
public class BuildingSite
{
    public int Owner { get; private set; }

    public int Rent { get; private set; }

    public int Cost { get; private set; }

    public void Buy()
    {

    }

    public BuildingSite(int cost, int rent)
    {
        Cost = cost;
        Rent = rent;
        Owner = -1;
    }
}