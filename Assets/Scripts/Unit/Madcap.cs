using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madcap : Unit
{
    public Madcap(int startMoney, OnBankrupt onBankrupt) : base(startMoney, onBankrupt)
    {
        ///Debug.Log(GetType());
    }

    public override void WillBuySite(BuildingSite buildingSite)
    {
        //buys any Building Site
        BuySite(buildingSite);
    }
}
