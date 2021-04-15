using System;
using System.Collections.Generic;
using osu.Enums;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;

namespace osu.Memory.Objects.Player
{
	// Token: 0x02000098 RID: 152
	public class OsuPlayer : OsuObject
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00004190 File Offset: 0x00004190
		private bool asyncLoadComplete
		{
			get
			{
				return this.OsuProcess.ReadBool(this.BaseAddress + 386);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x000041AD File Offset: 0x000041AD
		public override bool IsLoaded
		{
			get
			{
				return base.IsLoaded && this.asyncLoadComplete;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x000041C0 File Offset: 0x000041C0
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x000041C8 File Offset: 0x000041C8
		public OsuRuleset Ruleset { get; private set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x000041D1 File Offset: 0x000041D1
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x000041D9 File Offset: 0x000041D9
		public OsuHitObjectManager HitObjectManager { get; private set; }

		// Token: 0x06000401 RID: 1025 RVA: 0x00011DB8 File Offset: 0x00011DB8
		public OsuPlayer(UIntPtr pointerToBaseAddress) : base(new UIntPtr?(pointerToBaseAddress))
		{
			OsuObject[] array = new OsuObject[2];
			int num = 0;
			OsuRuleset osuRuleset = new OsuRuleset();
			osuRuleset.Offset = 96;
			OsuRuleset osuRuleset2 = osuRuleset;
			this.Ruleset = osuRuleset;
			array[num] = osuRuleset2;
			int num2 = 1;
			OsuHitObjectManager osuHitObjectManager = new OsuHitObjectManager();
			osuHitObjectManager.Offset = 64;
			OsuHitObjectManager osuHitObjectManager2 = osuHitObjectManager;
			this.HitObjectManager = osuHitObjectManager;
			array[num2] = osuHitObjectManager2;
			base.Children = array;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00011E14 File Offset: 0x00011E14
		public OsuBeatmap Beatmap
		{
			get
			{
				UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 212);
				return new OsuBeatmap
				{
					Ruleset = (Ruleset)this.OsuProcess.ReadInt32(pointer + 276),
					Checksum = this.OsuProcess.ReadString(pointer + 108, false, null),
					Artist = this.OsuProcess.ReadString(pointer + 24, true, null),
					Title = this.OsuProcess.ReadString(pointer + 36, true, null),
					Creator = this.OsuProcess.ReadString(pointer + 120, true, null),
					Version = this.OsuProcess.ReadString(pointer + 168, true, null),
					ApproachRate = this.OsuProcess.ReadFloat(pointer + 44),
					CircleSize = this.OsuProcess.ReadFloat(pointer + 48),
					HPDrainRate = this.OsuProcess.ReadFloat(pointer + 52),
					OverallDifficulty = this.OsuProcess.ReadFloat(pointer + 56),
					SliderMultiplier = this.OsuProcess.ReadDouble(pointer + 8),
					SliderTickRate = this.OsuProcess.ReadDouble(pointer + 16),
					HitObjects = new List<OsuHitObject>(this.HitObjectManager.HitObjects)
				};
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x000041E2 File Offset: 0x000041E2
		public Ruleset CurrentRuleset
		{
			get
			{
				return (Ruleset)this.OsuProcess.ReadInt32(this.BaseAddress + 276);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x000041FF File Offset: 0x000041FF
		public bool ReplayMode
		{
			get
			{
				return this.OsuProcess.ReadBool(this.BaseAddress + 378);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000421C File Offset: 0x0000421C
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00004239 File Offset: 0x00004239
		public int AudioCheckCount
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 332);
			}
			set
			{
				this.OsuProcess.WriteMemory(this.BaseAddress + 332, BitConverter.GetBytes(value), 4U);
			}
		}
	}
}
