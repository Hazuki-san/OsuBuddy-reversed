using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Mania
{
	// Token: 0x02000081 RID: 129
	public class ManiaNote : HitCircle
	{
		// Token: 0x06000376 RID: 886 RVA: 0x00003B5B File Offset: 0x00001D5B
		public ManiaNote(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00010B64 File Offset: 0x0000ED64
		public void SetColumn(int count, int column)
		{
			double num = 512.0 / (double)count;
			int num2 = Convert.ToInt32(Math.Floor((double)column * num));
			this.Position = new Vector2((float)num2, 0f);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00010BA4 File Offset: 0x0000EDA4
		public int GetColumn(int count)
		{
			double num = 512.0 / (double)count;
			return (int)((double)this.Position.X / num);
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00003BA4 File Offset: 0x00001DA4
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00003B9A File Offset: 0x00001D9A
		public new Vector2 Position
		{
			get
			{
				return new Vector2(base.Position.X, 0f);
			}
			set
			{
				base.Position = value;
			}
		}
	}
}
