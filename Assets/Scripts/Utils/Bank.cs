using UnityEngine;

public class Bank
{
    //The amount for each lap completed 
    public int LapMoney { get; private set; }

    public Bank(int lapAmount)
    {
        LapMoney = lapAmount;
    }

    public void PayRent(Unit lodger, Unit owner, BuildingSite buildingSite)
    {
        //value to be payed
        int rent = buildingSite.Rent;

        ///Debug.LogFormat("Unit {0} payed {1} rent to Unit {2}", lodger.Id, rent, owner.Id);

        //pay rent
        int amountPayed = lodger.PayRent(rent);

        //receive value
        owner.AddMoney(amountPayed);
    }

    public void ReceiveMoneyForCompleteLap(Unit unit)
    {
        //value to be payed
        unit.AddMoney(LapMoney);
    }
}
