using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stochastic : Unit
{
    public Stochastic(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void BuyHouse()
    {

    }
}
