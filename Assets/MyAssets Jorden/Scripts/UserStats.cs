
using UnityEngine;

public static class UserStats
{
    public static State State { get; set; }
    public static string Cif { get; set; }
    public static Transform FirstLocation { get; set; }
    public static Transform SecondLocation { get; set; }

    static UserStats()
    {
        State = State.Default;
        Cif = ""; //default cif file goes here
    }
}
