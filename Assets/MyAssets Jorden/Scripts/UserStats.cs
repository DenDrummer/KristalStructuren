
public static class UserStats
{
    public static State State { get; set; }

    static UserStats()
    {
        State = State.Default;
    }
}
