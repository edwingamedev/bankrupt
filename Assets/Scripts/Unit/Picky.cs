using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picky : Unit
{
    private int rentRequired = 50;

    public Picky(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void WillBuySite(Space space)
    {
        //buys any Building Site with rent > 50
        if (space.buildingSite.Rent > rentRequired)
        {
            BuySite(space);
        }
    }
}
