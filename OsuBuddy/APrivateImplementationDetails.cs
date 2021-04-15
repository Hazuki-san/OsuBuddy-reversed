using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x020000BB RID: 187
[CompilerGenerated]
internal sealed class APrivateImplementationDetails
{
	// Token: 0x060004C6 RID: 1222 RVA: 0x00017F7C File Offset: 0x0001617C
	internal static uint ComputeStringHash(string s)
	{
		uint num;
		if (s != null)
		{
			num = 2166136261U;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((uint)s[i] ^ num) * 16777619U;
			}
		}
		return num;
	}

	// Token: 0x0400049B RID: 1179 RVA: 0x00002050 File Offset: 0x00000250
	internal static readonly APrivateImplementationDetails.__StaticArrayInitTypeSize=20 B94D1BAAE3F6C0DE08C8B53576645C147733BDA6D6ABC026D32879DC6381C018;

	// Token: 0x020000BC RID: 188
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 20)]
	private struct __StaticArrayInitTypeSize=20
	{
	}
}
