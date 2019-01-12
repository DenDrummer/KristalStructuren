
public static class UserStats
{
    public static State State { get; set; }
    public static string Cif { get; set; }

    static UserStats()
    {
        State = State.Default;
        Cif = ""; //default cif file goes here
    }
}
