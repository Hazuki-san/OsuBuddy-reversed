using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
	// Token: 0x0200007B RID: 123
	public class Spinner : HitObject
	{
		// Token: 0x06000359 RID: 857 RVA: 0x0000399D File Offset: 0x00001B9D
		public Spinner(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
