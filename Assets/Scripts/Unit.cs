using UnityEngine;

public class Unit
{
    public int Money { get; private set; }

    public int Rent { get; private set; }

    public int Cost { get; private set; }

    public Unit(int startMoney)
    {
        Money = startMoney;
    }

    public virtual void BuyHouse()
    {

    }

    public void RollDice()
    {

    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public int PayRent(int amount)
    {
        Money -= amount;

        //pay the full amount if has money
        //otherwise pay the full money
        //if the unit has less the 0, pay nothing
        return Money >= 0 ? amount : (Money < 0 ? 0 : Money);
    }
}
