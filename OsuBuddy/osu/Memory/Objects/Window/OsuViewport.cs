using System;

namespace osu.Memory.Objects.Window
{
	// Token: 0x02000095 RID: 149
	public class OsuViewport : OsuObject
	{
		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00003FB6 File Offset: 0x000021B6
		public int X
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 4);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00003FCF File Offset: 0x000021CF
		public int Y
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 8);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00003FE8 File Offset: 0x000021E8
		public int Width
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 12);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00004002 File Offset: 0x00002202
		public int Height
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 16);
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000401C File Offset: 0x0000221C
		public OsuViewport(UIntPtr pointerToBaseAddress) : base(new UIntPtr?(pointerToBaseAddress))
		{
		}
	}
}
