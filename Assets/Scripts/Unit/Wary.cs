using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wary : Unit
{
    private int remainingCoins = 80;

    public Wary(int startMoney, OnBankrupt onBankrupt) : base(startMoney, onBankrupt)
    {
        ///Debug.Log(GetType());
    }

    public override void WillBuySite(BuildingSite buildingSite)
    {
        //buys any Building Site if remains 80 coins
        if((Coins - buildingSite.Cost) >= remainingCoins)
        {
            BuySite(buildingSite);
        }
        //else
        //{
        //   /// Debug.LogFormat("Unit {0}, decided not to buy site {1}", Id, Location);
        //}
    }
}
