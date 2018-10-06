public class Bank
{
    //The amount for each lap completed 
    public int LapMoney { get; private set; }

    public Bank(int lapAmount)
    {
        LapMoney = lapAmount;
    }

    public void PayRent(Unit lodger, Unit owner, Space space)
    {
        //value to be payed
        int rent = space.buildingSite.Rent;

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
