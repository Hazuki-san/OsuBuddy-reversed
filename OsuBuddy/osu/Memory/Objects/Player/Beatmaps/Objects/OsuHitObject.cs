using System.Numerics;

namespace osu.Memory.Objects.Player.Beatmaps.Objects
{
    public class OsuHitObject
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Vector2 Position { get; set; }

        public OsuHitObject(int startTime, int endTime, Vector2 position)
        {
            StartTime = startTime;
            EndTime = endTime;
            Position = position;
        }
    }
}
