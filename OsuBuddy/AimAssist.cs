using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using osu;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using SimpleDependencyInjection;
using WindowsInput;

namespace OsuBuddy
{
	// Token: 0x020000AC RID: 172
	public class AimAssist
	{
		// Token: 0x0600046A RID: 1130 RVA: 0x00016128 File Offset: 0x00014328
		public AimAssist()
		{
			this.osu = DependencyContainer.Get<OsuManager>();
			this.inputSimulator = new InputSimulator();
			this.lastMousePos = new Vector2(0f, 0f);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x000161B4 File Offset: 0x000143B4
		public void Start(OsuBeatmap beatmap)
		{
			AimAssist.Ac__DisplayClass15_0 ac__DisplayClass15_ = new Ac__DisplayClass15_0();
			ac__DisplayClass15_.A4__this = this;
			ac__DisplayClass15_.beatmap = beatmap;
			this.beatmap = ac__DisplayClass15_.beatmap;
			this.enabled = true;
			ac__DisplayClass15_.index = this.osu.Player.HitObjectManager.CurrentHitObjectIndex;
			ac__DisplayClass15_.currentHitObject = ac__DisplayClass15_.beatmap.HitObjects[ac__DisplayClass15_.index];
			ac__DisplayClass15_.hitObjectRadius = this.osu.HitObjectRadius(ac__DisplayClass15_.beatmap.CircleSize);
			while (this.osu.CanPlay && ac__DisplayClass15_.index < ac__DisplayClass15_.beatmap.HitObjects.Count && this.enabled)
			{
				Thread.Sleep(10);
				bool isPaused = this.osu.IsPaused;
				if (!isPaused)
				{
					int currentTime = this.osu.CurrentTime;
					bool flag = currentTime <= ac__DisplayClass15_.currentHitObject.EndTime;
					if (flag)
					{
						ac__DisplayClass15_.hitObjectPosition = ((ac__DisplayClass15_.currentHitObject is OsuSlider) ? (ac__DisplayClass15_.currentHitObject as OsuSlider).PositionAtTime(this.osu.CurrentTime) : ac__DisplayClass15_.currentHitObject.Position);
						bool flag2 = !(ac__DisplayClass15_.currentHitObject is OsuSpinner);
						if (flag2)
						{
							this.AStartg__aimAssist15_0(this.osu.WindowManager.PlayfieldToScreen(ac__DisplayClass15_.hitObjectPosition), ref ac__DisplayClass15_);
						}
						this.lastMousePos = this.osu.Player.Ruleset.MousePosition;
					}
					bool flag3 = currentTime >= ac__DisplayClass15_.currentHitObject.EndTime;
					if (flag3)
					{
						this.AStartg__getNextObject15_2(ref ac__DisplayClass15_);
					}
					while (this.osu.CanPlay && ac__DisplayClass15_.index >= ac__DisplayClass15_.beatmap.HitObjects.Count && this.enabled)
					{
						Thread.Sleep(5);
					}
				}
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00004572 File Offset: 0x00002772
		public int getAimSpeed()
		{
			return this.aimSpeed;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000457A File Offset: 0x0000277A
		public int getAimStartingDistance()
		{
			return this.aimStartingDistance;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00004582 File Offset: 0x00002782
		public int getAimStoppingDistance()
		{
			return this.aimStoppingDistance;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000163AC File Offset: 0x000145AC
		public void setAimSpeed(int speed)
		{
			this.aimSpeed = speed;
			bool flag = this.aimSpeed <= this.AIM_SPEED_MIN;
			if (flag)
			{
				this.aimSpeed = this.AIM_SPEED_MIN;
			}
			bool flag2 = this.aimSpeed >= this.AIM_SPEED_MAX;
			if (flag2)
			{
				this.aimSpeed = this.AIM_SPEED_MAX;
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00016404 File Offset: 0x00014604
		public void setAimStartingDistance(int distance)
		{
			this.aimStartingDistance = distance;
			bool flag = this.aimStartingDistance <= this.AIM_STARTING_DISTANCE_MIN;
			if (flag)
			{
				this.aimStartingDistance = this.AIM_STARTING_DISTANCE_MIN;
			}
			bool flag2 = this.aimStartingDistance >= this.AIM_STARTING_DISTANCE_MAX;
			if (flag2)
			{
				this.aimStartingDistance = int.MaxValue;
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0001645C File Offset: 0x0001465C
		public void setAimStoppingDistance(int distance)
		{
			this.aimStoppingDistance = distance;
			bool flag = this.aimStoppingDistance <= this.AIM_STOPPING_DISTANCE_MIN;
			if (flag)
			{
				this.aimStoppingDistance = this.AIM_STOPPING_DISTANCE_MIN;
			}
			bool flag2 = this.aimStoppingDistance >= this.AIM_STOPPING_DISTANCE_MAX;
			if (flag2)
			{
				this.aimStoppingDistance = this.AIM_STOPPING_DISTANCE_MAX;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000164B4 File Offset: 0x000146B4
		public double distance(Vector2 p1, Vector2 p2)
		{
			return Math.Sqrt(Math.Pow((double)(p1.X - p2.X), 2.0) + Math.Pow((double)(p1.Y - p2.Y), 2.0));
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00016504 File Offset: 0x00014704
		public double distance(double p1, double p2)
		{
			return Math.Abs(p1 - p2);
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000458A File Offset: 0x0000278A
		public void Stop()
		{
			this.enabled = false;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00016520 File Offset: 0x00014720
		[CompilerGenerated]
		private void AStartg__aimAssist15_0(Vector2 position, ref AimAssist.Ac__DisplayClass15_0 A_2)
		{
			double num = 0.0;
			double num2 = 0.0;
			Vector2 mousePosition = this.osu.Player.Ruleset.MousePosition;
			bool flag = this.distance(mousePosition, position) < (double)this.aimStartingDistance;
			if (flag)
			{
				bool flag2 = !this.AStartg__isMouseOnNote15_1(ref A_2);
				if (flag2)
				{
					bool flag3 = this.distance(mousePosition, position) < this.distance(this.lastMousePos, position);
					if (flag3)
					{
						num = (double)(position.X - mousePosition.X) / 100.0;
						num2 = (double)(position.Y - mousePosition.Y) / 100.0;
						double num3 = (double)(mousePosition.X - this.lastMousePos.X) / 100.0;
						double num4 = (double)(mousePosition.Y - this.lastMousePos.Y) / 100.0;
						num = (num + num3) * (double)this.aimSpeed / 2.0;
						num2 = (num2 + num4) * (double)this.aimSpeed / 2.0;
					}
					else
					{
						num = (double)(this.lastMousePos.X - mousePosition.X) / 10.0;
						num2 = (double)(this.lastMousePos.Y - mousePosition.Y) / 10.0;
					}
				}
				else
				{
					num = (double)(this.lastMousePos.X - mousePosition.X) / 10.0;
					num2 = (double)(this.lastMousePos.Y - mousePosition.Y) / 10.0;
				}
			}
			this.inputSimulator.Mouse.MoveMouseBy((int)Math.Round(num), (int)Math.Round(num2));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00016704 File Offset: 0x00014904
		[CompilerGenerated]
		private bool AStartg__isMouseOnNote15_1(ref AimAssist.Ac__DisplayClass15_0 A_1)
		{
			Vector2 p = this.osu.WindowManager.ScreenToPlayfield(this.osu.Player.Ruleset.MousePosition);
			return this.distance(A_1.hitObjectPosition, p) - (double)A_1.hitObjectRadius * ((double)((float)this.aimStoppingDistance) / 100.0) <= 0.0;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00016774 File Offset: 0x00014974
		[CompilerGenerated]
		private void AStartg__getNextObject15_2(ref AimAssist.Ac__DisplayClass15_0 A_1)
		{
			int index = A_1.index;
			A_1.index = index + 1;
			bool flag = A_1.index < A_1.beatmap.HitObjects.Count;
			if (flag)
			{
				A_1.currentHitObject = A_1.beatmap.HitObjects[A_1.index];
			}
		}

		// Token: 0x04000433 RID: 1075
		private OsuManager osu;

		// Token: 0x04000434 RID: 1076
		private OsuBeatmap beatmap;

		// Token: 0x04000435 RID: 1077
		private bool enabled;

		// Token: 0x04000436 RID: 1078
		private InputSimulator inputSimulator;

		// Token: 0x04000437 RID: 1079
		private Vector2 lastMousePos;

		// Token: 0x04000438 RID: 1080
		public readonly int AIM_SPEED_MAX = 20;

		// Token: 0x04000439 RID: 1081
		public readonly int AIM_SPEED_MIN = 0;

		// Token: 0x0400043A RID: 1082
		public readonly int AIM_STARTING_DISTANCE_MAX = 1000;

		// Token: 0x0400043B RID: 1083
		public readonly int AIM_STARTING_DISTANCE_MIN = 0;

		// Token: 0x0400043C RID: 1084
		public readonly int AIM_STOPPING_DISTANCE_MAX = 100;

		// Token: 0x0400043D RID: 1085
		public readonly int AIM_STOPPING_DISTANCE_MIN = 0;

		// Token: 0x0400043E RID: 1086
		private int aimSpeed = 5;

		// Token: 0x0400043F RID: 1087
		private int aimStartingDistance = 250;

		// Token: 0x04000440 RID: 1088
		private int aimStoppingDistance = 30;

		// Token: 0x020000AD RID: 173
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct Ac__DisplayClass15_0
		{
			// Token: 0x04000441 RID: 1089
			public AimAssist A4__this;

			// Token: 0x04000442 RID: 1090
			public Vector2 hitObjectPosition;

			// Token: 0x04000443 RID: 1091
			public float hitObjectRadius;

			// Token: 0x04000444 RID: 1092
			public int index;

			// Token: 0x04000445 RID: 1093
			public OsuBeatmap beatmap;

			// Token: 0x04000446 RID: 1094
			public OsuHitObject currentHitObject;
		}
	}
}
