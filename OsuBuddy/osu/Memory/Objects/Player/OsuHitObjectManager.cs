using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using osu.Enums;
using osu.Enums.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;

namespace osu.Memory.Objects.Player
{
	// Token: 0x02000097 RID: 151
	public class OsuHitObjectManager : OsuObject
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x000040EA File Offset: 0x000040EA
		public override bool IsLoaded
		{
			get
			{
				return base.IsLoaded && this.HitObjectsCount > 0;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x000118D0 File Offset: 0x000118D0
		public Mods CurrentMods
		{
			get
			{
				UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 52);
				int num = this.OsuProcess.ReadInt32(pointer + 8);
				int num2 = this.OsuProcess.ReadInt32(pointer + 12);
				return (Mods)(num ^ num2);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00004100 File Offset: 0x00004100
		public int CurrentHitObjectIndex
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 140);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000411D File Offset: 0x0000411D
		public int HitObjectsCount
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.BaseAddress + 144);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x0001192C File Offset: 0x0001192C
		public List<OsuHitObject> HitObjects
		{
			get
			{
				List<OsuHitObject> list = new List<OsuHitObject>();
				int i = 0;
				while (i < this.HitObjectsCount)
				{
					OsuHitObject item;
					UIntPtr uintPtr;
					int startTime;
					int endTime;
					Vector2 position;
					HitObjectType hitObjectType3;
					List<ValueTuple<Vector2, Vector2>> list2;
					List<double> list3;
					UIntPtr uintPtr2;
					for (;;)
					{
						item = null;
						uintPtr = (UIntPtr)this.OsuProcess.ReadUInt32(this.<get_HitObjects>g__hitObjectListItemsPointer|9_1() + 8 + 4 * i);
						bool flag = !this.<get_HitObjects>g__isAddressValid|9_0(uintPtr);
						if (!flag)
						{
							HitObjectType hitObjectType = (HitObjectType)this.OsuProcess.ReadInt32(uintPtr + 24);
							hitObjectType &= (HitObjectType)(-113);
							hitObjectType &= (HitObjectType)(-5);
							startTime = this.OsuProcess.ReadInt32(uintPtr + 16);
							endTime = this.OsuProcess.ReadInt32(uintPtr + 20);
							position = new Vector2(this.OsuProcess.ReadFloat(uintPtr + 56), this.OsuProcess.ReadFloat(uintPtr + 60));
							HitObjectType hitObjectType2 = hitObjectType;
							hitObjectType3 = hitObjectType2;
							if (hitObjectType3 == HitObjectType.Circle)
							{
								goto IL_E8;
							}
							if (hitObjectType3 != HitObjectType.Slider)
							{
								goto Block_3;
							}
							list2 = new List<ValueTuple<Vector2, Vector2>>();
							list3 = new List<double>();
							uintPtr2 = (UIntPtr)this.OsuProcess.ReadUInt32(uintPtr + 196);
							UIntPtr uintPtr3 = (UIntPtr)this.OsuProcess.ReadUInt32(uintPtr + 200);
							bool flag2 = !this.<get_HitObjects>g__isAddressValid|9_0(uintPtr2) || !this.<get_HitObjects>g__isAddressValid|9_0(uintPtr3);
							if (!flag2)
							{
								UIntPtr uintPtr4 = (UIntPtr)this.OsuProcess.ReadUInt32(uintPtr2 + 4);
								UIntPtr uintPtr5 = (UIntPtr)this.OsuProcess.ReadUInt32(uintPtr3 + 4);
								bool flag3 = !this.<get_HitObjects>g__isAddressValid|9_0(uintPtr4) || !this.<get_HitObjects>g__isAddressValid|9_0(uintPtr5);
								if (!flag3)
								{
									goto IL_1BB;
								}
							}
						}
					}
					IL_33F:
					list.Add(item);
					i++;
					continue;
					Block_3:
					if (hitObjectType3 != HitObjectType.Spinner)
					{
						goto IL_33F;
					}
					item = new OsuSpinner(startTime, endTime, position);
					goto IL_33F;
					IL_E8:
					item = new OsuHitCircle(startTime, endTime, position);
					goto IL_33F;
					IL_1BB:
					int num = this.OsuProcess.ReadInt32(uintPtr2 + 12);
					int num2 = this.OsuProcess.ReadInt32(uintPtr2 + 12);
					for (int j = 0; j < num; j++)
					{
						UIntPtr uintPtr4;
						UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(uintPtr4 + 8 + 4 * j);
						Vector2 item2 = new Vector2(this.OsuProcess.ReadFloat(pointer + 8), this.OsuProcess.ReadFloat(pointer + 12));
						Vector2 item3 = new Vector2(this.OsuProcess.ReadFloat(pointer + 16), this.OsuProcess.ReadFloat(pointer + 20));
						list2.Add(new ValueTuple<Vector2, Vector2>(item2, item3));
					}
					for (int k = 0; k < num2; k++)
					{
						UIntPtr uintPtr5;
						double item4 = this.OsuProcess.ReadDouble(uintPtr5 + 8 + 8 * k);
						list3.Add(item4);
					}
					int repeats = this.OsuProcess.ReadInt32(uintPtr + 32);
					double pixelLength = this.OsuProcess.ReadDouble(uintPtr + 8);
					CurveType curveType = (CurveType)this.OsuProcess.ReadInt32(uintPtr + 232);
					item = new OsuSlider(startTime, endTime, position, repeats, pixelLength, curveType, list2, list3);
					goto IL_33F;
				}
				return list;
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00011CA0 File Offset: 0x00011CA0
		public HitState GetHitState(int index)
		{
			UIntPtr pointer = (UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 72);
			UIntPtr pointer2 = (UIntPtr)this.OsuProcess.ReadUInt32(pointer + 4);
			UIntPtr pointer3 = (UIntPtr)this.OsuProcess.ReadUInt32(pointer2 + 8 + 4 * index);
			HitObjectType hitObjectType = (HitObjectType)this.OsuProcess.ReadInt32(pointer3 + 24);
			hitObjectType &= (HitObjectType)(-113);
			hitObjectType &= (HitObjectType)(-5);
			HitState hitState = this.OsuProcess.ReadBool(pointer3 + 132) ? HitState.Hit : HitState.NotHit;
			HitObjectType hitObjectType2 = hitObjectType;
			HitObjectType hitObjectType3 = hitObjectType2;
			HitState result;
			if (hitObjectType3 != HitObjectType.Slider)
			{
				result = hitState;
			}
			else
			{
				UIntPtr pointer4 = (UIntPtr)this.OsuProcess.ReadUInt32(pointer3 + 204);
				result = (this.OsuProcess.ReadBool(pointer4 + 132) ? (hitState | HitState.SliderStartHit) : hitState);
			}
			return result;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00011D98 File Offset: 0x00011D98
		public OsuHitObjectManager() : base(null)
		{
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000413A File Offset: 0x0000413A
		[CompilerGenerated]
		private bool <get_HitObjects>g__isAddressValid|9_0(UIntPtr address)
		{
			return address != UIntPtr.Zero && this.OsuProcess.ReadInt32(address) != 0;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000415B File Offset: 0x0000415B
		[CompilerGenerated]
		private UIntPtr <get_HitObjects>g__hitObjectListItemsPointer|9_1()
		{
			return (UIntPtr)this.OsuProcess.ReadUInt32((UIntPtr)this.OsuProcess.ReadUInt32(this.BaseAddress + 72) + 4);
		}
	}
}
