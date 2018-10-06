using UnityEngine;

public class Space
{
    public BuildingSite buildingSite;
    public int Location { get; private set; }

    public Space(int cost, int rent, int location)
    {
        buildingSite = new BuildingSite(cost, rent);

        Location = location;
    }
}
