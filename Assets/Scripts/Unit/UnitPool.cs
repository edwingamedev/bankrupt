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

    public UnitPool(int numOfPlayers, int startMoney)
    {
        CreatePool();

        for (int i = 0; i < numOfPlayers; i++)
        {
            //add to the pool
            Units.Add(GenerateUnit(i % UnitTypes.Count, startMoney));
        }
    }

    private void CreatePool()
    {
        Units = new List<Unit>();

        ShuffleTypes();
    }

    private Unit GenerateUnit(int index, int startMoney)
    {
        // get public constructors
        ConstructorInfo[] ctors = UnitTypes[index].GetConstructors();

        // invoke the first public constructor with no parameters.
        return (Unit)ctors[0].Invoke(new object[] { startMoney });
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

    public Unit GetUnit(int index)
    {
        return Units[index];
    }
}
