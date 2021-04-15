using osu.Enums;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using System;
using System.Collections.Generic;

namespace osu.Memory.Objects.Player
{
    public class OsuPlayer : OsuObject
    {
        private bool asyncLoadComplete => OsuProcess.ReadBool(BaseAddress + 0x182);

        public override bool IsLoaded => base.IsLoaded && asyncLoadComplete;

        public OsuRuleset Ruleset { get; private set; }

        public OsuHitObjectManager HitObjectManager { get; private set; }

        public OsuPlayer(UIntPtr pointerToBaseAddress) : base(pointerToBaseAddress)
        {
            Children = new OsuObject[]
            {
                Ruleset = new OsuRuleset
                {
                    Offset = 0x60
                },
                HitObjectManager = new OsuHitObjectManager
                {
                    Offset = 0x40
                }
            };
        }

        public OsuBeatmap Beatmap
        {
            get
            {
                UIntPtr beatmapBase = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0xD4);

                return new OsuBeatmap
                {
                    Ruleset = (Ruleset)OsuProcess.ReadInt32(beatmapBase + 0x114),

                    Checksum = OsuProcess.ReadString(beatmapBase + 0x6C),

                    Artist = OsuProcess.ReadString(beatmapBase + 0x18, true),
                    Title = OsuProcess.ReadString(beatmapBase + 0x24, true),
                    Creator = OsuProcess.ReadString(beatmapBase + 0x78, true),
                    Version = OsuProcess.ReadString(beatmapBase + 0xA8, true),

                    ApproachRate = OsuProcess.ReadFloat(beatmapBase + 0x2C),
                    CircleSize = OsuProcess.ReadFloat(beatmapBase + 0x30),
                    HPDrainRate = OsuProcess.ReadFloat(beatmapBase + 0x34),
                    OverallDifficulty = OsuProcess.ReadFloat(beatmapBase + 0x38),

                    SliderMultiplier = OsuProcess.ReadDouble(beatmapBase + 0x8),
                    SliderTickRate = OsuProcess.ReadDouble(beatmapBase + 0x10),

                    HitObjects = new List<OsuHitObject>(HitObjectManager.HitObjects)
                };
            }
        }

        public Ruleset CurrentRuleset => (Ruleset)OsuProcess.ReadInt32(BaseAddress + 0x114);

        public bool ReplayMode => OsuProcess.ReadBool(BaseAddress + 0x17A);

        public int AudioCheckCount
        {
            get => OsuProcess.ReadInt32(BaseAddress + 0x14C);
            set => OsuProcess.WriteMemory(BaseAddress + 0x14C, BitConverter.GetBytes(value), sizeof(int));
        }
    }
}
