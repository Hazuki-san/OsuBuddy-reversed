using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
	// Token: 0x02000079 RID: 121
	public class HitObject
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000338 RID: 824 RVA: 0x000039B2 File Offset: 0x000039B2
		// (set) Token: 0x06000339 RID: 825 RVA: 0x000039BA File Offset: 0x000039BA
		public Vector2 Position { get; set; } = Vector2.Zero;

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600033A RID: 826 RVA: 0x000039C3 File Offset: 0x000039C3
		// (set) Token: 0x0600033B RID: 827 RVA: 0x000039CB File Offset: 0x000039CB
		public int StartTime { get; set; } = 0;

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600033C RID: 828 RVA: 0x000039D4 File Offset: 0x000039D4
		// (set) Token: 0x0600033D RID: 829 RVA: 0x000039DC File Offset: 0x000039DC
		public int EndTime { get; set; } = 0;

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600033E RID: 830 RVA: 0x000039E5 File Offset: 0x000039E5
		// (set) Token: 0x0600033F RID: 831 RVA: 0x000039ED File Offset: 0x000039ED
		public HitSoundType HitSound { get; set; } = HitSoundType.None;

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000340 RID: 832 RVA: 0x000039F6 File Offset: 0x000039F6
		// (set) Token: 0x06000341 RID: 833 RVA: 0x000039FE File Offset: 0x000039FE
		public Extras Extras { get; set; } = new Extras();

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00003A07 File Offset: 0x00003A07
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00003A0F File Offset: 0x00003A0F
		public bool IsNewCombo { get; set; } = false;

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00003A18 File Offset: 0x00003A18
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00003A20 File Offset: 0x00003A20
		public int ComboOffset { get; set; } = 0;

		// Token: 0x06000346 RID: 838 RVA: 0x000107EC File Offset: 0x000107EC
		public HitObject()
		{
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0001083C File Offset: 0x0001083C
		public HitObject(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset)
		{
			this.Position = position;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.HitSound = hitSound;
			this.Extras = extras;
			this.IsNewCombo = isNewCombo;
			this.ComboOffset = comboOffset;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00003A29 File Offset: 0x00003A29
		public TimeSpan StartTimeSpan
		{
			get
			{
				return TimeSpan.FromMilliseconds((double)this.StartTime);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00003A37 File Offset: 0x00003A37
		public TimeSpan EndTimeSpan
		{
			get
			{
				return TimeSpan.FromMilliseconds((double)this.EndTime);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00003A45 File Offset: 0x00003A45
		public TimeSpan TotalTimeSpan
		{
			get
			{
				return TimeSpan.FromMilliseconds((double)(this.EndTime - this.StartTime));
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00003A5A File Offset: 0x00003A5A
		public float DistanceFrom(HitObject otherObject)
		{
			return Vector2.Distance(this.Position, otherObject.Position);
		}
	}
}
