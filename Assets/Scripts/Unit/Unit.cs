using UnityEngine;
using System.Collections.Generic;

public abstract class Unit
{
    public int Coins { get; private set; }

    public int Id { get; set; }

    private List<int> properties;

    public Unit(int startMoney)
    {
        Coins = startMoney;

        properties = new List<int>();
    }

    public abstract void WillBuySite(Space space);

    public void BuySite(Space space)
    {
        //checks if has money to buy site
        if (Coins - space.buildingSite.Cost > 0)
        {
            //pays the cost
            Coins -= space.buildingSite.Cost;
            space.buildingSite.Buy(this);

            properties.Add(space.Location);
        }
    }

    public void RollDice()
    {

    }

    public void AddMoney(int amount)
    {
        Coins += amount;
    }

    public int PayRent(int amount)
    {
        Coins -= amount;

        //pay the full amount if has money
        //otherwise pay the full money
        //if the unit has less the 0, pay nothing
        return Coins >= 0 ? amount : (Coins < 0 ? 0 : Coins);
    }
}
