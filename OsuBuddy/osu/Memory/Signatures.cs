using System;

namespace osu.Memory
{
	// Token: 0x02000088 RID: 136
	public static class Signatures
	{
		// Token: 0x0400030B RID: 779
		public static readonly Signature Time = new Signature
		{
			Pattern = "7E 55 8B 76 10 DB 05",
			Offset = 7
		};

		// Token: 0x0400030C RID: 780
		public const int IsAudioPlayingOffset = 48;

		// Token: 0x0400030D RID: 781
		public static readonly Signature Mode = new Signature
		{
			Pattern = "8D 45 BC 89 46 0C 83 3D",
			Offset = 8
		};

		// Token: 0x0400030E RID: 782
		public static readonly Signature Viewport = new Signature
		{
			Pattern = "89 45 C8 8B 72 0C 8B 15",
			Offset = 8
		};

		// Token: 0x0400030F RID: 783
		public static readonly Signature BindingManager = new Signature
		{
			Pattern = "8D 45 D8 50 8B 0D ?? ?? ?? ?? 8B 55 E0 39 09",
			Offset = 6
		};

		// Token: 0x04000310 RID: 784
		public static readonly Signature Player = new Signature
		{
			Pattern = "FF 50 0C 8B D8 8B 15",
			Offset = 7
		};
	}
}
