
using UnityEngine;

public class BondDistances
{
    public float Distance { get; private set; }
    public Transform AtomFirst { get; private set; }
    public Transform AtomSecond { get; private set; }

    public BondDistances(float distance, Transform atomFirst, Transform atomSecond)
    {
        AtomFirst = atomFirst;
        AtomSecond = atomSecond;
        Distance = distance;
    }

    
    public int CompareTo(object obj)
    {
        if (Distance < ((BondDistances)obj).Distance)
        {
            return -1;
        }
        if (Distance > ((BondDistances)obj).Distance)
        {
            return 1;
        }
        return 0;
    }
}
