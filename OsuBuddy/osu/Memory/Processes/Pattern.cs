using System;

namespace osu.Memory.Processes
{
	// Token: 0x0200008E RID: 142
	public class Pattern
	{
		// Token: 0x060003CF RID: 975 RVA: 0x000116D0 File Offset: 0x000116D0
		public static Pattern Parse(string pattern)
		{
			string[] array = pattern.Split(new char[]
			{
				' '
			});
			byte[] bytes = Array.ConvertAll<string, byte>(array, (string b) => (b == "??") ? 0 : Convert.ToByte(b, 16));
			bool[] mask = Array.ConvertAll<string, bool>(array, (string b) => b != "??");
			return new Pattern
			{
				Bytes = bytes,
				Mask = mask
			};
		}

		// Token: 0x04000325 RID: 805
		public byte[] Bytes;

		// Token: 0x04000326 RID: 806
		public bool[] Mask;
	}
}
