using System;

namespace osu.Memory.Objects.Window
{
    public class OsuViewport : OsuObject
    {
        public int X => OsuProcess.ReadInt32(BaseAddress + 0x4);

        public int Y => OsuProcess.ReadInt32(BaseAddress + 0x8);

        public int Width => OsuProcess.ReadInt32(BaseAddress + 0xC);

        public int Height => OsuProcess.ReadInt32(BaseAddress + 0x10);

        public OsuViewport(UIntPtr pointerToBaseAddress) : base(pointerToBaseAddress) { }
    }
}
