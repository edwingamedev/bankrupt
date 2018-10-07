using System;
using System.Collections.Generic;
using System.Reflection;

public class UnitPool
{
    private List<Unit> Units { get; set; }
    private List<Type> UnitTypes = new List<Type> { typeof(Wary), typeof(Madcap), typeof(Picky), typeof(Stochastic) };

    public UnitPool()
    {
        CreatePool();
    }

    public UnitPool(int numOfPlayers, int startMoney, Unit.OnBankrupt onBankrupt)
    {
        CreatePool();

        for (int i = 0; i < numOfPlayers; i++)
        {
            //add to the pool
            Units.Add(GenerateUnit(i % UnitTypes.Count, startMoney, onBankrupt));

            //set the id
            Units[i].Id = i;
        }
    }

    public int NumOfPlayers()
    {
        return Units.Count;
    }

    public void RemoveUnit(int id)
    {
        Units.Remove(Units.Find(unit => unit.Id == id));
    }

    private void CreatePool()
    {
        Units = new List<Unit>();

        ShuffleTypes();
    }

    private Unit GenerateUnit(int index, int startMoney, Unit.OnBankrupt onBankrupt)
    {
        // get public constructors
        ConstructorInfo[] ctors = UnitTypes[index].GetConstructors();

        // invoke the first public constructor with no parameters.
        return (Unit)ctors[0].Invoke(new object[] { startMoney, onBankrupt });
    }

    private void ShuffleTypes()
    {
        Random random = new Random();

        //randomize the unit types for 
        for (int i = UnitTypes.Count - 1; i > 0; i--)
        {
            Type temp = UnitTypes[i];
            int index = random.Next(0, i + 1);
            UnitTypes[i] = UnitTypes[index];
            UnitTypes[index] = temp;
        }
    }

    public Unit GetUnitByIndex(int index)
    {
        return Units[index];
    }

    public Unit GetUnitById(int id)
    {
        return Units.Find(unit => unit.Id == id);
    }
}
