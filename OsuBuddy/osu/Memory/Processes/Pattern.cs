using System;
using System.Runtime.CompilerServices;

namespace osu.Memory.Processes
{
	// Token: 0x0200008E RID: 142
	public class Pattern
	{
		// Token: 0x060003CF RID: 975 RVA: 0x000116D0 File Offset: 0x0000F8D0
		public static Pattern Parse(string pattern)
		{
			string[] array = pattern.Split(new char[]
			{
				' '
			});
			byte[] bytes = Array.ConvertAll<string, byte>(array, new Converter<string, byte>(Pattern.Ac.A9.AParseb__2_0));
			bool[] mask = Array.ConvertAll<string, bool>(array, new Converter<string, bool>(Pattern.Ac.A9.AParseb__2_1));
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

		// Token: 0x0200008F RID: 143
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x060003D3 RID: 979 RVA: 0x00003EAF File Offset: 0x000020AF
			internal byte AParseb__2_0(string b)
			{
				return (b == "??") ? 0 : Convert.ToByte(b, 16);
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x00003EC9 File Offset: 0x000020C9
			internal bool AParseb__2_1(string b)
			{
				return b != "??";
			}

			// Token: 0x04000327 RID: 807
			public static readonly Pattern.Ac A9 = new Pattern.Ac();

			// Token: 0x04000328 RID: 808
			public static Converter<string, byte> A9__2_0;

			// Token: 0x04000329 RID: 809
			public static Converter<string, bool> A9__2_1;
		}
	}
}
