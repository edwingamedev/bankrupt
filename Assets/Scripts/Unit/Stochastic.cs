using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stochastic : Unit
{
    private float probability = 50;

    public Stochastic(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void WillBuySite(Space space)
    {
        //buys any Building Site with 50% chance
        if ((Random.value) < (probability / 100))
        {
            BuySite(space);
        }
    }
}
