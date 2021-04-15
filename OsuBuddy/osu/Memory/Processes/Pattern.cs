using System;

namespace osu.Memory.Processes
{
    public class Pattern
    {
        public byte[] Bytes;
        public bool[] Mask;

        public static Pattern Parse(string pattern)
        {
            string[] patternSplit = pattern.Split(' ');

            byte[] bytes = Array.ConvertAll(patternSplit, b => b == "??" ? (byte)0x0 : Convert.ToByte(b, 16));
            bool[] mask = Array.ConvertAll(patternSplit, b => b != "??");

            return new Pattern
            {
                Bytes = bytes,
                Mask = mask
            };
        }
    }
}
