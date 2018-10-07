using UnityEngine;
using System.Collections.Generic;

public abstract class Unit
{
    public int Coins { get; private set; }
    public int Id { get; set; }
    public int Location { get; set; }

    public List<int> properties;

    public delegate void OnBankrupt(int id);
    public OnBankrupt onBankrupt;

    public Unit(int startMoney, OnBankrupt onBankrupt)
    {
        Coins = startMoney;

        properties = new List<int>();

        this.onBankrupt = onBankrupt;
    }

    public abstract void WillBuySite(BuildingSite buildingSite);

    public void BuySite(BuildingSite buildingSite)
    {
        //checks if has money to buy site
        if (Coins - buildingSite.Cost > 0)
        {
            //pays the cost
            Coins -= buildingSite.Cost;
            buildingSite.Buy(this);

            ///Debug.LogFormat("Unit {0}, payed {1} and bought site {2}", Id, buildingSite.Cost, Location);

            properties.Add(Location);
        }
        else
        {
            ///Debug.LogFormat("Unit {0}, doesnt have enough money to buy {1} for ${2}", Id, Location, buildingSite.Cost);
        }
    }

    public void Move(int position)
    {
        Location = position;
        ///Debug.LogFormat("Unit {0}, moved to a {1}", Id, Location);
    }

    public int RollDice(int numOfFaces)
    {
        int dice = Random.Range(1, numOfFaces + 1);

        ///Debug.LogFormat("Unit {0} (${3}), rolled a d{1}: {2}", Id, numOfFaces, dice, Coins);

        return dice + Location;

    }

    public void AddMoney(int amount)
    {
        Coins += amount;
    }

    private void BankRupt()
    {


        //report unit got bankrupt
        onBankrupt(Id);
    }

    public int PayRent(int amount)
    {
        Coins -= amount;

        //pay the full amount if has money
        //otherwise pay the full money
        //if the unit has less the 0, pay nothing

        //got bankrupt
        if (Coins < 0)
        {
            ///Debug.LogWarningFormat("Unit {0}, got bankrupt", Id);

            //got bankrupt
            BankRupt();
        }

        return Coins >= 0 ? amount : (Coins < 0 ? 0 : Coins);
    }
}
