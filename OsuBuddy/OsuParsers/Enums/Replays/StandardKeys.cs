namespace OsuParsers.Enums.Replays
{
    public enum StandardKeys
    {
        None = 0,
        M1 = (1 << 0),
        M2 = (1 << 1),
        K1 = (1 << 2) + M1,
        K2 = (1 << 3) + M2,
        BOTH = 15,
        Smoke = 1 << 4,
    }
}
