using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
	// Token: 0x0200007E RID: 126
	public class TaikoHit : HitCircle
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600036F RID: 879 RVA: 0x0001092C File Offset: 0x0001092C
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00010954 File Offset: 0x00010954
		public bool IsBig
		{
			get
			{
				return base.HitSound.HasFlag(HitSoundType.Finish);
			}
			set
			{
				bool flag = value && !base.HitSound.HasFlag(HitSoundType.Finish);
				if (flag)
				{
					base.HitSound += 4;
				}
				else
				{
					bool flag2 = base.HitSound.HasFlag(HitSoundType.Finish);
					if (flag2)
					{
						base.HitSound -= 4;
					}
				}
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000371 RID: 881 RVA: 0x00010A18 File Offset: 0x00010A18
		// (set) Token: 0x06000372 RID: 882 RVA: 0x00010A64 File Offset: 0x00010A64
		public TaikoColor Color
		{
			get
			{
				bool flag = base.HitSound.HasFlag(HitSoundType.Whistle) || base.HitSound.HasFlag(HitSoundType.Clap);
				TaikoColor result;
				if (flag)
				{
					result = TaikoColor.Blue;
				}
				else
				{
					result = TaikoColor.Red;
				}
				return result;
			}
			set
			{
				bool flag = value == TaikoColor.Red;
				if (flag)
				{
					bool flag2 = base.HitSound.HasFlag(HitSoundType.Whistle);
					if (flag2)
					{
						base.HitSound -= 2;
					}
					bool flag3 = base.HitSound.HasFlag(HitSoundType.Clap);
					if (flag3)
					{
						base.HitSound -= 8;
					}
					bool flag4 = !base.HitSound.HasFlag(HitSoundType.Normal);
					if (flag4)
					{
						base.HitSound++;
					}
				}
				else
				{
					bool flag5 = value == TaikoColor.Blue;
					if (flag5)
					{
						bool flag6 = base.HitSound.HasFlag(HitSoundType.Normal);
						if (flag6)
						{
							base.HitSound--;
						}
						bool flag7 = !base.HitSound.HasFlag(HitSoundType.Whistle);
						if (flag7)
						{
							base.HitSound += 2;
						}
					}
				}
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00003B5B File Offset: 0x00003B5B
		public TaikoHit(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
