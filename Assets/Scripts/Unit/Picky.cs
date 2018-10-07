using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picky : Unit
{
    private int rentRequired = 50;

    public Picky(int startMoney, OnBankrupt onBankrupt) : base(startMoney, onBankrupt)
    {
        ///Debug.Log(GetType());
    }

    public override void WillBuySite(BuildingSite buildingSite)
    {
        //buys any Building Site with rent > 50
        if (buildingSite.Rent > rentRequired)
        {
            BuySite(buildingSite);
        }
        else
        {
            ///Debug.LogFormat("Unit {0}, decided not to buy site {1}", Id, Location);
        }
    }
}
