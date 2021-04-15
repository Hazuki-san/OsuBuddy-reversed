using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using osu;
using osu.Enums;
using osu.Memory.Objects.Bindings;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using SimpleDependencyInjection;
using WindowsInput;
using WindowsInput.Native;

namespace OsuBuddy
{
	// Token: 0x020000AE RID: 174
	public class Relax
	{
		// Token: 0x06000478 RID: 1144 RVA: 0x000167CC File Offset: 0x000149CC
		public Relax()
		{
			this.osu = DependencyContainer.Get<OsuManager>();
			this.inputSimulator = new InputSimulator();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001685C File Offset: 0x00014A5C
		public void Start(OsuBeatmap beatmap)
		{
			Relax.Ac__DisplayClass18_0 ac__DisplayClass18_;
			ac__DisplayClass18_.A4__this = this;
			ac__DisplayClass18_.beatmap = beatmap;
			this.beatmap = ac__DisplayClass18_.beatmap;
			this.enabled = true;
			ac__DisplayClass18_.key1 = (VirtualKeyCode)this.osu.BindingManager.GetKeyCode(Bindings.OsuLeft);
			ac__DisplayClass18_.key2 = (VirtualKeyCode)this.osu.BindingManager.GetKeyCode(Bindings.OsuRight);
			//ac__DisplayClass18_.key1 = this.osu.BindingManager.GetKeyCode(Bindings.OsuLeft);
			//ac__DisplayClass18_.key2 = this.osu.BindingManager.GetKeyCode(Bindings.OsuRight);
			this.currentKeyPressed = ac__DisplayClass18_.key2;
			ac__DisplayClass18_.beatmapSpeed = (this.osu.Player.HitObjectManager.CurrentMods.HasFlag(Mods.DoubleTime) ? 1.5f : (this.osu.Player.HitObjectManager.CurrentMods.HasFlag(Mods.HalfTime) ? 0.75f : 1f));
			int num = this.osu.HitWindow50((double)ac__DisplayClass18_.beatmap.OverallDifficulty);
			int num2 = this.osu.HitWindow50((double)ac__DisplayClass18_.beatmap.OverallDifficulty);
			int num3 = this.osu.HitWindow100((double)ac__DisplayClass18_.beatmap.OverallDifficulty);
			int num4 = this.osu.HitWindow300((double)ac__DisplayClass18_.beatmap.OverallDifficulty);
			ac__DisplayClass18_.hitObjectRadius = this.osu.HitObjectRadius(ac__DisplayClass18_.beatmap.CircleSize);
			ac__DisplayClass18_.alreadyHit = false;
			bool flag = false;
			ac__DisplayClass18_.rand = new Random();
			ac__DisplayClass18_.randomOffset = ac__DisplayClass18_.rand.Next(-this.offset, this.offset);
			ac__DisplayClass18_.randomHoldTime = ac__DisplayClass18_.rand.Next((int)(((float)this.holdTime - 5f) * ac__DisplayClass18_.beatmapSpeed), (int)(((float)this.holdTime + 5f) * ac__DisplayClass18_.beatmapSpeed));
			ac__DisplayClass18_.lastTimeHit = 0;
			ac__DisplayClass18_.index = this.osu.Player.HitObjectManager.CurrentHitObjectIndex;
			ac__DisplayClass18_.currentHitObject = ac__DisplayClass18_.beatmap.HitObjects[ac__DisplayClass18_.index];
			this.AStartg__releaseBothKeys18_2(ref ac__DisplayClass18_);
			while (this.osu.CanPlay && ac__DisplayClass18_.index < ac__DisplayClass18_.beatmap.HitObjects.Count && this.enabled)
			{
				TimingHelper.Delay(1U);
				bool isPaused = this.osu.IsPaused;
				if (isPaused)
				{
					Thread.Sleep(5);
				}
				else
				{
					Relax.Ac__DisplayClass18_1 ac__DisplayClass18_2;
					ac__DisplayClass18_2.currentTime = this.osu.CurrentTime;
					bool flag2 = ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime - num;
					if (flag2)
					{
						ac__DisplayClass18_.hitObjectPosition = ((ac__DisplayClass18_.currentHitObject is OsuSlider) ? (ac__DisplayClass18_.currentHitObject as OsuSlider).PositionAtTime(this.osu.CurrentTime) : ac__DisplayClass18_.currentHitObject.Position);
						bool flag3 = !ac__DisplayClass18_.alreadyHit;
						if (flag3)
						{
							bool flag4 = this.AStartg__isMouseOnNote18_1(ref ac__DisplayClass18_);
							if (flag4)
							{
								bool flag5 = ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime + ac__DisplayClass18_.randomOffset;
								if (flag5)
								{
									flag = false;
									this.AStartg__pressKey18_4(ref ac__DisplayClass18_, ref ac__DisplayClass18_2);
								}
							}
							else
							{
								bool flag6 = ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime + num2;
								if (flag6)
								{
									flag = true;
									this.AStartg__pressKey18_4(ref ac__DisplayClass18_, ref ac__DisplayClass18_2);
								}
							}
						}
					}
					bool flag7 = !flag & ac__DisplayClass18_.alreadyHit;
					if (flag7)
					{
						bool flag8 = ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.EndTime + ac__DisplayClass18_.randomOffset + ac__DisplayClass18_.randomHoldTime;
						if (flag8)
						{
							this.AStartg__releaseKey18_5(ref ac__DisplayClass18_);
							this.AStartg__getNextObject18_3(ref ac__DisplayClass18_);
						}
					}
					else
					{
						bool flag9 = ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.EndTime + num2 + ac__DisplayClass18_.randomHoldTime;
						if (flag9)
						{
							this.AStartg__releaseKey18_5(ref ac__DisplayClass18_);
							this.AStartg__getNextObject18_3(ref ac__DisplayClass18_);
						}
					}
					while (this.osu.CanPlay && ac__DisplayClass18_.index >= ac__DisplayClass18_.beatmap.HitObjects.Count && this.enabled)
					{
						Thread.Sleep(5);
					}
				}
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00004593 File Offset: 0x00002793
		public int getOffset()
		{
			return this.offset;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000459B File Offset: 0x0000279B
		public int getHoldTime()
		{
			return this.holdTime;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000045A3 File Offset: 0x000027A3
		public int getAlternateTime()
		{
			return this.alternateTime;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000045AB File Offset: 0x000027AB
		public int getPercentToHitOutsideOffset()
		{
			return this.percentToHitOutsideOffset;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00016CA4 File Offset: 0x00014EA4
		public void setOffset(int offset)
		{
			this.offset = offset;
			bool flag = offset <= this.OFFSET_MIN;
			if (flag)
			{
				offset = this.OFFSET_MIN;
			}
			bool flag2 = offset >= this.OFFSET_MAX;
			if (flag2)
			{
				offset = this.OFFSET_MAX;
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00016CEC File Offset: 0x00014EEC
		public void setHoldTime(int time)
		{
			this.holdTime = time;
			bool flag = this.holdTime <= this.HOLD_TIME_MIN;
			if (flag)
			{
				this.holdTime = this.HOLD_TIME_MIN;
			}
			bool flag2 = this.holdTime >= this.HOLD_TIME_MAX;
			if (flag2)
			{
				this.holdTime = this.HOLD_TIME_MAX;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00016D44 File Offset: 0x00014F44
		public void setAlternateTime(int time)
		{
			this.alternateTime = time;
			bool flag = this.alternateTime <= this.ALTERNATE_TIME_MIN;
			if (flag)
			{
				this.alternateTime = this.ALTERNATE_TIME_MIN;
			}
			bool flag2 = this.alternateTime >= this.ALTERNATE_TIME_MAX;
			if (flag2)
			{
				this.alternateTime = int.MaxValue;
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00016D9C File Offset: 0x00014F9C
		public void setPercentToHitOutsideOffset(int percent)
		{
			this.percentToHitOutsideOffset = percent;
			bool flag = this.percentToHitOutsideOffset <= this.PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN;
			if (flag)
			{
				this.percentToHitOutsideOffset = this.PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN;
			}
			bool flag2 = this.percentToHitOutsideOffset >= this.PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX;
			if (flag2)
			{
				this.percentToHitOutsideOffset = this.PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX;
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000164B4 File Offset: 0x000146B4
		public double distance(Vector2 p1, Vector2 p2)
		{
			return Math.Sqrt(Math.Pow((double)(p1.X - p2.X), 2.0) + Math.Pow((double)(p1.Y - p2.Y), 2.0));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00016504 File Offset: 0x00014704
		public double distance(double p1, double p2)
		{
			return Math.Abs(p1 - p2);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000045B3 File Offset: 0x000027B3
		public void Stop()
		{
			this.enabled = false;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00016DF4 File Offset: 0x00014FF4
		[CompilerGenerated]
		private void AStartg__pressKey18_4(ref Relax.Ac__DisplayClass18_0 A_1, ref Relax.Ac__DisplayClass18_1 A_2)
		{
			bool flag = (float)(A_2.currentTime - A_1.lastTimeHit) <= (float)this.alternateTime * A_1.beatmapSpeed;
			if (flag)
			{
				this.AStartg__alternateKeys18_0(ref A_1);
			}
			else
			{
				this.currentKeyPressed = A_1.key1;
			}
			this.inputSimulator.Keyboard.KeyDown(this.currentKeyPressed);
			A_1.alreadyHit = true;
			A_1.lastTimeHit = A_2.currentTime;
			A_1.randomHoldTime = A_1.rand.Next((int)(((float)this.holdTime - 5f) * A_1.beatmapSpeed), (int)(((float)this.holdTime + 5f) * A_1.beatmapSpeed));
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00016EA4 File Offset: 0x000150A4
		[CompilerGenerated]
		private void AStartg__releaseKey18_5(ref Relax.Ac__DisplayClass18_0 A_1)
		{
			this.inputSimulator.Keyboard.KeyUp(this.currentKeyPressed);
			A_1.alreadyHit = false;
			bool flag = A_1.rand.Next(1, 101) <= this.percentToHitOutsideOffset;
			if (flag)
			{
				bool flag2 = A_1.rand.Next(0, 2) == 0;
				if (flag2)
				{
					A_1.randomOffset = A_1.rand.Next(-this.offset * 2, -this.offset);
				}
				else
				{
					A_1.randomOffset = A_1.rand.Next(this.offset, this.offset * 2);
				}
			}
			else
			{
				A_1.randomOffset = A_1.rand.Next(-this.offset, this.offset);
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00016F68 File Offset: 0x00015168
		[CompilerGenerated]
		private void AStartg__alternateKeys18_0(ref Relax.Ac__DisplayClass18_0 A_1)
		{
			bool flag = this.currentKeyPressed == A_1.key1;
			if (flag)
			{
				this.currentKeyPressed = A_1.key2;
			}
			else
			{
				this.currentKeyPressed = A_1.key1;
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00016FA8 File Offset: 0x000151A8
		[CompilerGenerated]
		private bool AStartg__isMouseOnNote18_1(ref Relax.Ac__DisplayClass18_0 A_1)
		{
			return this.distance(A_1.hitObjectPosition, this.osu.WindowManager.ScreenToPlayfield(this.osu.Player.Ruleset.MousePosition)) - (double)A_1.hitObjectRadius <= 0.0;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000045BC File Offset: 0x000027BC
		[CompilerGenerated]
		private void AStartg__releaseBothKeys18_2(ref Relax.Ac__DisplayClass18_0 A_1)
		{
			this.inputSimulator.Keyboard.KeyUp(A_1.key1);
			this.inputSimulator.Keyboard.KeyUp(A_1.key2);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00017004 File Offset: 0x00015204
		[CompilerGenerated]
		private void AStartg__getNextObject18_3(ref Relax.Ac__DisplayClass18_0 A_1)
		{
			int index = A_1.index;
			A_1.index = index + 1;
			bool flag = A_1.index < A_1.beatmap.HitObjects.Count;
			if (flag)
			{
				A_1.currentHitObject = A_1.beatmap.HitObjects[A_1.index];
			}
		}

		// Token: 0x04000447 RID: 1095
		private OsuManager osu;

		// Token: 0x04000448 RID: 1096
		private OsuBeatmap beatmap;

		// Token: 0x04000449 RID: 1097
		private bool enabled;

		// Token: 0x0400044A RID: 1098
		private InputSimulator inputSimulator;

		// Token: 0x0400044B RID: 1099
		private VirtualKeyCode currentKeyPressed;

		// Token: 0x0400044C RID: 1100
		public readonly int OFFSET_MAX = 50;

		// Token: 0x0400044D RID: 1101
		public readonly int OFFSET_MIN = 0;

		// Token: 0x0400044E RID: 1102
		public readonly int HOLD_TIME_MAX = 100;

		// Token: 0x0400044F RID: 1103
		public readonly int HOLD_TIME_MIN = 30;

		// Token: 0x04000450 RID: 1104
		public readonly int ALTERNATE_TIME_MAX = 1000;

		// Token: 0x04000451 RID: 1105
		public readonly int ALTERNATE_TIME_MIN = 0;

		// Token: 0x04000452 RID: 1106
		public readonly int PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX = 100;

		// Token: 0x04000453 RID: 1107
		public readonly int PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN = 0;

		// Token: 0x04000454 RID: 1108
		private int offset = 20;

		// Token: 0x04000455 RID: 1109
		private int holdTime = 50;

		// Token: 0x04000456 RID: 1110
		private int alternateTime = 200;

		// Token: 0x04000457 RID: 1111
		private int percentToHitOutsideOffset = 5;

		// Token: 0x020000AF RID: 175
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct Ac__DisplayClass18_0
		{
			// Token: 0x04000458 RID: 1112
			public int lastTimeHit;

			// Token: 0x04000459 RID: 1113
			public Relax A4__this;

			// Token: 0x0400045A RID: 1114
			public float beatmapSpeed;

			// Token: 0x0400045B RID: 1115
			public VirtualKeyCode key1;

			// Token: 0x0400045C RID: 1116
			public bool alreadyHit;

			// Token: 0x0400045D RID: 1117
			public int randomHoldTime;

			// Token: 0x0400045E RID: 1118
			public Random rand;

			// Token: 0x0400045F RID: 1119
			public int randomOffset;

			// Token: 0x04000460 RID: 1120
			public VirtualKeyCode key2;

			// Token: 0x04000461 RID: 1121
			public Vector2 hitObjectPosition;

			// Token: 0x04000462 RID: 1122
			public float hitObjectRadius;

			// Token: 0x04000463 RID: 1123
			public int index;

			// Token: 0x04000464 RID: 1124
			public OsuBeatmap beatmap;

			// Token: 0x04000465 RID: 1125
			public OsuHitObject currentHitObject;
		}

		// Token: 0x020000B0 RID: 176
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct Ac__DisplayClass18_1
		{
			// Token: 0x04000466 RID: 1126
			public int currentTime;
		}
	}
}
