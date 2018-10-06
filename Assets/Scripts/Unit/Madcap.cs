using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madcap : Unit
{
    public Madcap(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void WillBuySite(Space space)
    {
        //buys any Building Site
        BuySite(space);
    }
}
