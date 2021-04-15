using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Mania
{
	// Token: 0x02000080 RID: 128
	public class ManiaHoldNote : ManiaNote
	{
		// Token: 0x06000375 RID: 885 RVA: 0x00003B85 File Offset: 0x00001D85
		public ManiaHoldNote(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
