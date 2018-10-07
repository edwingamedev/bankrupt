using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stochastic : Unit
{
    private float probability = 50;

    public Stochastic(int startMoney, OnBankrupt onBankrupt) : base(startMoney, onBankrupt)
    {
        ///Debug.Log(GetType());
    }

    public override void WillBuySite(BuildingSite buildingSite)
    {
        //buys any Building Site with 50% chance
        if ((Random.value) < (probability / 100))
        {
            BuySite(buildingSite);
        }
        //else
        //{
        //    ///Debug.LogFormat("Unit {0}, decided not to buy site {1}", Id, Location);
        //}
    }
}
