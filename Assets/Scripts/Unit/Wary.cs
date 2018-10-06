using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wary : Unit
{
    private int remainingCoins = 80;

    public Wary(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void WillBuySite(Space space)
    {
        //buys any Building Site if remains 80 coins
        if((Money - space.buildingSite.Cost) >= remainingCoins)
        {
            BuySite(space);
        }
    }
}
