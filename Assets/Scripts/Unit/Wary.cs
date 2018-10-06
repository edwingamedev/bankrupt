using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wary : Unit
{
    public Wary(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void BuyHouse()
    {

    }
}
