using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Catch
{
	// Token: 0x02000083 RID: 131
	public class CatchFruit : HitCircle
	{
		// Token: 0x0600037C RID: 892 RVA: 0x00003B5B File Offset: 0x00003B5B
		public CatchFruit(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
