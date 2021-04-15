using System;
using System.Numerics;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects.Catch
{
	// Token: 0x02000082 RID: 130
	public class CatchBananaRain : Spinner
	{
		// Token: 0x0600037B RID: 891 RVA: 0x00003B70 File Offset: 0x00001D70
		public CatchBananaRain(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
		{
		}
	}
}
