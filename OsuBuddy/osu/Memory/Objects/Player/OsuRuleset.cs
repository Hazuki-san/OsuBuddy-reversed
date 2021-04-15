using System;
using System.Numerics;

namespace osu.Memory.Objects.Player
{
    public class OsuRuleset : OsuObject
    {
        public Vector2 MousePosition
        {
            get
            {
                UIntPtr catcherAddress = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x8C);

                bool isCtb = OsuProcess.ReadFloat(BaseAddress + 0x50) == 340;
                float x = OsuProcess.ReadFloat(isCtb ? catcherAddress + 0x4C : BaseAddress + 0x80);
                float y = OsuProcess.ReadFloat(isCtb ? catcherAddress + 0x50 : BaseAddress + 0x84);

                return new Vector2(x, y);
            }
            set
            {
                UIntPtr catcherAddress = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0x8C);

                bool isCtb = OsuProcess.ReadFloat(catcherAddress + 0x50) == 340;
                if (!isCtb)
                    return;

                UIntPtr wank = (UIntPtr)OsuProcess.ReadUInt32(BaseAddress + 0xA4);

                OsuProcess.WriteMemory(wank + 0x8, BitConverter.GetBytes(value.X), sizeof(float));
                OsuProcess.WriteMemory(wank + 0xC, BitConverter.GetBytes(1), sizeof(int));
                OsuProcess.WriteMemory(catcherAddress + 0x4C, BitConverter.GetBytes(value.X), sizeof(float));
                OsuProcess.WriteMemory(catcherAddress + 0x50, BitConverter.GetBytes(value.Y), sizeof(float));
            }
        }
    }
}
