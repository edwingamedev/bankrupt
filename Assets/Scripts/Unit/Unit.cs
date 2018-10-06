using UnityEngine;
using System.Collections.Generic;

public abstract class Unit
{
    public int Money { get; private set; }

    public int Rent { get; private set; }

    public int Cost { get; private set; }

    public int Id { get; set; }

    private List<int> properties;

    public Unit(int startMoney)
    {
        Money = startMoney;

        properties = new List<int>();
    }

    public abstract void WillBuySite(Space space);

    public void BuySite(Space space)
    {
        //checks if has money to buy site
        if (Money - space.buildingSite.Cost > 0)
        {
            //pays the cost
            Money -= space.buildingSite.Cost;
            space.buildingSite.Buy(this);

            properties.Add(space.Location);
        }
    }

    public void RollDice()
    {

    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public int PayRent(int amount)
    {
        Money -= amount;

        //pay the full amount if has money
        //otherwise pay the full money
        //if the unit has less the 0, pay nothing
        return Money >= 0 ? amount : (Money < 0 ? 0 : Money);
    }
}
