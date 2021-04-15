using osu.Enums;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using System.Collections.Generic;

namespace osu.Memory.Objects.Player.Beatmaps
{
    public class OsuBeatmap : OsuObject
    {
        public Ruleset Ruleset { get; set; }

        public string Checksum { get; set; }

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Version { get; set; }

        public float ApproachRate { get; set; }
        public float CircleSize { get; set; }
        public float HPDrainRate { get; set; }
        public float OverallDifficulty { get; set; }

        public double SliderMultiplier { get; set; }
        public double SliderTickRate { get; set; }

        public List<OsuHitObject> HitObjects { get; set; }
    }
}
