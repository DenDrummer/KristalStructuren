
public static class UserStats
{
    public static State State { get; set; }
    public static string Cif { get; set; }
    public static int Bonds { get; set; }
    public static int Size { get; set; }

    static UserStats()
    {
        State = State.Default;
        Cif = ""; //default cif file goes here
        Bonds = 2;
        Size = 3;
    }
}