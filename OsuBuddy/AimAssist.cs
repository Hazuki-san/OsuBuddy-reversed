using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using osu;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Objects.Player.Beatmaps.Objects;
using OsuBuddy;
using SimpleDependencyInjection;
using WindowsInput;

public class AimAssist
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct Ac__DisplayClass15_0
	{
		public AimAssist A4__this;

		public Vector2 hitObjectPosition;

		public float hitObjectRadius;

		public int index;

		public OsuBeatmap beatmap;

		public OsuHitObject currentHitObject;
	}

	private OsuManager osu;

	private OsuBeatmap beatmap;

	private bool enabled;

	private InputSimulator inputSimulator;

	private Vector2 lastMousePos;

	public readonly int AIM_SPEED_MAX = 20;

	public readonly int AIM_SPEED_MIN = 0;

	public readonly int AIM_STARTING_DISTANCE_MAX = 1000;

	public readonly int AIM_STARTING_DISTANCE_MIN = 0;

	public readonly int AIM_STOPPING_DISTANCE_MAX = 100;

	public readonly int AIM_STOPPING_DISTANCE_MIN = 0;

	private int aimSpeed = 5;

	private int aimStartingDistance = 250;

	private int aimStoppingDistance = 30;

	public AimAssist()
	{
		osu = DependencyContainer.Get<OsuManager>();
		inputSimulator = new InputSimulator();
		lastMousePos = new Vector2(0f, 0f);
	}

	public void Start(OsuBeatmap beatmap)
	{
		Ac__DisplayClass15_0 ac__DisplayClass15_ = default(Ac__DisplayClass15_0);
		ac__DisplayClass15_.A4__this = this;
		ac__DisplayClass15_.beatmap = beatmap;
		this.beatmap = ac__DisplayClass15_.beatmap;
		enabled = true;
		ac__DisplayClass15_.index = osu.Player.HitObjectManager.CurrentHitObjectIndex;
		ac__DisplayClass15_.currentHitObject = ac__DisplayClass15_.beatmap.HitObjects[ac__DisplayClass15_.index];
		ac__DisplayClass15_.hitObjectRadius = osu.HitObjectRadius(ac__DisplayClass15_.beatmap.CircleSize);
		while (osu.CanPlay && ac__DisplayClass15_.index < ac__DisplayClass15_.beatmap.HitObjects.Count && enabled)
		{
			Thread.Sleep(10);
			if (osu.IsPaused)
			{
				continue;
			}
			int currentTime = osu.CurrentTime;
			if (currentTime <= ac__DisplayClass15_.currentHitObject.EndTime)
			{
				ac__DisplayClass15_.hitObjectPosition = ((ac__DisplayClass15_.currentHitObject is OsuSlider) ? (ac__DisplayClass15_.currentHitObject as OsuSlider).PositionAtTime(osu.CurrentTime) : ac__DisplayClass15_.currentHitObject.Position);
				if (!(ac__DisplayClass15_.currentHitObject is OsuSpinner))
				{
					AStartg__aimAssist15_0(osu.WindowManager.PlayfieldToScreen(ac__DisplayClass15_.hitObjectPosition), ref ac__DisplayClass15_);
				}
				lastMousePos = osu.Player.Ruleset.MousePosition;
			}
			if (currentTime >= ac__DisplayClass15_.currentHitObject.EndTime)
			{
				AStartg__getNextObject15_2(ref ac__DisplayClass15_);
			}
			while (osu.CanPlay && ac__DisplayClass15_.index >= ac__DisplayClass15_.beatmap.HitObjects.Count && enabled)
			{
				Thread.Sleep(5);
			}
		}
	}

	public int getAimSpeed()
	{
		return aimSpeed;
	}

	public int getAimStartingDistance()
	{
		return aimStartingDistance;
	}

	public int getAimStoppingDistance()
	{
		return aimStoppingDistance;
	}

	public void setAimSpeed(int speed)
	{
		aimSpeed = speed;
		if (aimSpeed <= AIM_SPEED_MIN)
		{
			aimSpeed = AIM_SPEED_MIN;
		}
		if (aimSpeed >= AIM_SPEED_MAX)
		{
			aimSpeed = AIM_SPEED_MAX;
		}
	}

	public void setAimStartingDistance(int distance)
	{
		aimStartingDistance = distance;
		if (aimStartingDistance <= AIM_STARTING_DISTANCE_MIN)
		{
			aimStartingDistance = AIM_STARTING_DISTANCE_MIN;
		}
		if (aimStartingDistance >= AIM_STARTING_DISTANCE_MAX)
		{
			aimStartingDistance = int.MaxValue;
		}
	}

	public void setAimStoppingDistance(int distance)
	{
		aimStoppingDistance = distance;
		if (aimStoppingDistance <= AIM_STOPPING_DISTANCE_MIN)
		{
			aimStoppingDistance = AIM_STOPPING_DISTANCE_MIN;
		}
		if (aimStoppingDistance >= AIM_STOPPING_DISTANCE_MAX)
		{
			aimStoppingDistance = AIM_STOPPING_DISTANCE_MAX;
		}
	}

	public double distance(Vector2 p1, Vector2 p2)
	{
		return Math.Sqrt(Math.Pow(p1.X - p2.X, 2.0) + Math.Pow(p1.Y - p2.Y, 2.0));
	}

	public double distance(double p1, double p2)
	{
		return Math.Abs(p1 - p2);
	}

	public void Stop()
	{
		enabled = false;
	}

	[CompilerGenerated]
	private void AStartg__aimAssist15_0(Vector2 position, ref Ac__DisplayClass15_0 P_1)
	{
		double a = 0.0;
		double a2 = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		Vector2 mousePosition = osu.Player.Ruleset.MousePosition;
		if (distance(mousePosition, position) < (double)aimStartingDistance)
		{
			if (!AStartg__isMouseOnNote15_1(ref P_1))
			{
				if (distance(mousePosition, position) < distance(lastMousePos, position))
				{
					a = (double)(position.X - mousePosition.X) / 100.0;
					a2 = (double)(position.Y - mousePosition.Y) / 100.0;
					num = (double)(mousePosition.X - lastMousePos.X) / 100.0;
					num2 = (double)(mousePosition.Y - lastMousePos.Y) / 100.0;
					a = (a + num) * (double)aimSpeed / 2.0;
					a2 = (a2 + num2) * (double)aimSpeed / 2.0;
				}
				else
				{
					a = (double)(lastMousePos.X - mousePosition.X) / 10.0;
					a2 = (double)(lastMousePos.Y - mousePosition.Y) / 10.0;
				}
			}
			else
			{
				a = (double)(lastMousePos.X - mousePosition.X) / 10.0;
				a2 = (double)(lastMousePos.Y - mousePosition.Y) / 10.0;
			}
		}
		inputSimulator.Mouse.MoveMouseBy((int)Math.Round(a), (int)Math.Round(a2));
	}

	[CompilerGenerated]
	private bool AStartg__isMouseOnNote15_1(ref Ac__DisplayClass15_0 P_0)
	{
		Vector2 p = osu.WindowManager.ScreenToPlayfield(osu.Player.Ruleset.MousePosition);
		return distance(P_0.hitObjectPosition, p) - (double)P_0.hitObjectRadius * ((double)(float)aimStoppingDistance / 100.0) <= 0.0;
	}

	[CompilerGenerated]
	private void AStartg__getNextObject15_2(ref Ac__DisplayClass15_0 P_0)
	{
		P_0.index++;
		if (P_0.index < P_0.beatmap.HitObjects.Count)
		{
			P_0.currentHitObject = P_0.beatmap.HitObjects[P_0.index];
		}
	}
}
