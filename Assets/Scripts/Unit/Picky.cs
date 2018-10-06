using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picky : Unit
{
    public Picky(int startMoney) : base(startMoney)
    {
        Debug.Log(GetType());
    }

    public override void BuyHouse()
    {
        
    }
}
