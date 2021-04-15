using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace osu.Memory.Objects.Window
{
	// Token: 0x02000096 RID: 150
	public class OsuWindowManager
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000402C File Offset: 0x0000222C
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x00004034 File Offset: 0x00002234
		public OsuViewport Viewport { get; private set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000403D File Offset: 0x0000223D
		public Vector2 WindowSize
		{
			get
			{
				return new Vector2((float)this.Viewport.Width, (float)this.Viewport.Height);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000405C File Offset: 0x0000225C
		public Vector2 WindowPosition
		{
			get
			{
				return new Vector2((float)this.Viewport.X, (float)this.Viewport.Y);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x0000407B File Offset: 0x0000227B
		public float WindowRatio
		{
			get
			{
				return this.WindowSize.Y / 480f;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00011834 File Offset: 0x0000FA34
		public Vector2 PlayfieldSize
		{
			get
			{
				float x = 512f * this.WindowRatio;
				float y = 384f * this.WindowRatio;
				return new Vector2(x, y);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x00011868 File Offset: 0x0000FA68
		public Vector2 PlayfieldPosition
		{
			get
			{
				float x = (this.WindowSize.X - this.PlayfieldSize.X) / 2f;
				float y = (this.WindowSize.Y - this.PlayfieldSize.Y) / 4f * 3f + -16f * this.WindowRatio;
				return new Vector2(x, y);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000408E File Offset: 0x0000228E
		public float PlayfieldRatio
		{
			get
			{
				return this.PlayfieldSize.Y / 384f;
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000040A1 File Offset: 0x000022A1
		public OsuWindowManager(UIntPtr viewportPointer)
		{
			this.Viewport = new OsuViewport(viewportPointer);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000040B8 File Offset: 0x000022B8
		public Vector2 ScreenToPlayfield(Vector2 screenCoords)
		{
			return (screenCoords - this.PlayfieldPosition) / this.PlayfieldRatio;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000040D1 File Offset: 0x000022D1
		public Vector2 PlayfieldToScreen(Vector2 playfieldCoords)
		{
			return playfieldCoords * this.PlayfieldRatio + this.PlayfieldPosition;
		}

		// Token: 0x04000345 RID: 837
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OsuViewport AViewportk__BackingField;
	}
}
