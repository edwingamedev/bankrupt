using UnityEngine;

public class Space
{
    public BuildingSite buildingSite;

    public Space(int cost, int rent)
    {
        buildingSite = new BuildingSite(cost, rent);
    }
}
