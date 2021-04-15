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
using OsuBuddy;
using SimpleDependencyInjection;
using WindowsInput;
using WindowsInput.Native;

public class Relax
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct Ac__DisplayClass18_0
	{
		public int lastTimeHit;

		public Relax A4__this;

		public float beatmapSpeed;

		public VirtualKeyCode key1;

		public bool alreadyHit;

		public int randomHoldTime;

		public Random rand;

		public int randomOffset;

		public VirtualKeyCode key2;

		public Vector2 hitObjectPosition;

		public float hitObjectRadius;

		public int index;

		public OsuBeatmap beatmap;

		public OsuHitObject currentHitObject;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct Ac__DisplayClass18_1
	{
		public int currentTime;
	}

	private OsuManager osu;

	private OsuBeatmap beatmap;

	private bool enabled;

	private InputSimulator inputSimulator;

	private VirtualKeyCode currentKeyPressed;

	public readonly int OFFSET_MAX = 50;

	public readonly int OFFSET_MIN = 0;

	public readonly int HOLD_TIME_MAX = 100;

	public readonly int HOLD_TIME_MIN = 30;

	public readonly int ALTERNATE_TIME_MAX = 1000;

	public readonly int ALTERNATE_TIME_MIN = 0;

	public readonly int PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX = 100;

	public readonly int PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN = 0;

	private int offset = 20;

	private int holdTime = 50;

	private int alternateTime = 200;

	private int percentToHitOutsideOffset = 5;

	public Relax()
	{
		osu = DependencyContainer.Get<OsuManager>();
		inputSimulator = new InputSimulator();
	}

	public void Start(OsuBeatmap beatmap)
	{
		Ac__DisplayClass18_0 ac__DisplayClass18_ = default(Ac__DisplayClass18_0);
		ac__DisplayClass18_.A4__this = this;
		ac__DisplayClass18_.beatmap = beatmap;
		this.beatmap = ac__DisplayClass18_.beatmap;
		enabled = true;
		ac__DisplayClass18_.key1 = (VirtualKeyCode)osu.BindingManager.GetKeyCode(Bindings.OsuLeft);
		ac__DisplayClass18_.key2 = (VirtualKeyCode)osu.BindingManager.GetKeyCode(Bindings.OsuRight);
		currentKeyPressed = ac__DisplayClass18_.key2;
		ac__DisplayClass18_.beatmapSpeed = (osu.Player.HitObjectManager.CurrentMods.HasFlag(Mods.DoubleTime) ? 1.5f : (osu.Player.HitObjectManager.CurrentMods.HasFlag(Mods.HalfTime) ? 0.75f : 1f));
		int num = osu.HitWindow50(ac__DisplayClass18_.beatmap.OverallDifficulty);
		int num2 = osu.HitWindow50(ac__DisplayClass18_.beatmap.OverallDifficulty);
		int num3 = osu.HitWindow100(ac__DisplayClass18_.beatmap.OverallDifficulty);
		int num4 = osu.HitWindow300(ac__DisplayClass18_.beatmap.OverallDifficulty);
		ac__DisplayClass18_.hitObjectRadius = osu.HitObjectRadius(ac__DisplayClass18_.beatmap.CircleSize);
		ac__DisplayClass18_.alreadyHit = false;
		bool flag = false;
		ac__DisplayClass18_.rand = new Random();
		ac__DisplayClass18_.randomOffset = ac__DisplayClass18_.rand.Next(-offset, offset);
		ac__DisplayClass18_.randomHoldTime = ac__DisplayClass18_.rand.Next((int)(((float)holdTime - 5f) * ac__DisplayClass18_.beatmapSpeed), (int)(((float)holdTime + 5f) * ac__DisplayClass18_.beatmapSpeed));
		ac__DisplayClass18_.lastTimeHit = 0;
		ac__DisplayClass18_.index = osu.Player.HitObjectManager.CurrentHitObjectIndex;
		ac__DisplayClass18_.currentHitObject = ac__DisplayClass18_.beatmap.HitObjects[ac__DisplayClass18_.index];
		AStartg__releaseBothKeys18_2(ref ac__DisplayClass18_);
		Ac__DisplayClass18_1 ac__DisplayClass18_2 = default(Ac__DisplayClass18_1);
		while (osu.CanPlay && ac__DisplayClass18_.index < ac__DisplayClass18_.beatmap.HitObjects.Count && enabled)
		{
			TimingHelper.Delay(1u);
			if (osu.IsPaused)
			{
				Thread.Sleep(5);
				continue;
			}
			ac__DisplayClass18_2.currentTime = osu.CurrentTime;
			if (ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime - num)
			{
				ac__DisplayClass18_.hitObjectPosition = ((ac__DisplayClass18_.currentHitObject is OsuSlider) ? (ac__DisplayClass18_.currentHitObject as OsuSlider).PositionAtTime(osu.CurrentTime) : ac__DisplayClass18_.currentHitObject.Position);
				if (!ac__DisplayClass18_.alreadyHit)
				{
					if (AStartg__isMouseOnNote18_1(ref ac__DisplayClass18_))
					{
						if (ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime + ac__DisplayClass18_.randomOffset)
						{
							flag = false;
							AStartg__pressKey18_4(ref ac__DisplayClass18_, ref ac__DisplayClass18_2);
						}
					}
					else if (ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.StartTime + num2)
					{
						flag = true;
						AStartg__pressKey18_4(ref ac__DisplayClass18_, ref ac__DisplayClass18_2);
					}
				}
			}
			if (!flag & ac__DisplayClass18_.alreadyHit)
			{
				if (ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.EndTime + ac__DisplayClass18_.randomOffset + ac__DisplayClass18_.randomHoldTime)
				{
					AStartg__releaseKey18_5(ref ac__DisplayClass18_);
					AStartg__getNextObject18_3(ref ac__DisplayClass18_);
				}
			}
			else if (ac__DisplayClass18_2.currentTime >= ac__DisplayClass18_.currentHitObject.EndTime + num2 + ac__DisplayClass18_.randomHoldTime)
			{
				AStartg__releaseKey18_5(ref ac__DisplayClass18_);
				AStartg__getNextObject18_3(ref ac__DisplayClass18_);
			}
			while (osu.CanPlay && ac__DisplayClass18_.index >= ac__DisplayClass18_.beatmap.HitObjects.Count && enabled)
			{
				Thread.Sleep(5);
			}
		}
	}

	public int getOffset()
	{
		return offset;
	}

	public int getHoldTime()
	{
		return holdTime;
	}

	public int getAlternateTime()
	{
		return alternateTime;
	}

	public int getPercentToHitOutsideOffset()
	{
		return percentToHitOutsideOffset;
	}

	public void setOffset(int offset)
	{
		this.offset = offset;
		if (offset <= OFFSET_MIN)
		{
			offset = OFFSET_MIN;
		}
		if (offset >= OFFSET_MAX)
		{
			offset = OFFSET_MAX;
		}
	}

	public void setHoldTime(int time)
	{
		holdTime = time;
		if (holdTime <= HOLD_TIME_MIN)
		{
			holdTime = HOLD_TIME_MIN;
		}
		if (holdTime >= HOLD_TIME_MAX)
		{
			holdTime = HOLD_TIME_MAX;
		}
	}

	public void setAlternateTime(int time)
	{
		alternateTime = time;
		if (alternateTime <= ALTERNATE_TIME_MIN)
		{
			alternateTime = ALTERNATE_TIME_MIN;
		}
		if (alternateTime >= ALTERNATE_TIME_MAX)
		{
			alternateTime = int.MaxValue;
		}
	}

	public void setPercentToHitOutsideOffset(int percent)
	{
		percentToHitOutsideOffset = percent;
		if (percentToHitOutsideOffset <= PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN)
		{
			percentToHitOutsideOffset = PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN;
		}
		if (percentToHitOutsideOffset >= PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX)
		{
			percentToHitOutsideOffset = PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX;
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
	private void AStartg__pressKey18_4(ref Ac__DisplayClass18_0 P_0, ref Ac__DisplayClass18_1 P_1)
	{
		if ((float)(P_1.currentTime - P_0.lastTimeHit) <= (float)alternateTime * P_0.beatmapSpeed)
		{
			AStartg__alternateKeys18_0(ref P_0);
		}
		else
		{
			currentKeyPressed = P_0.key1;
		}
		inputSimulator.Keyboard.KeyDown(currentKeyPressed);
		P_0.alreadyHit = true;
		P_0.lastTimeHit = P_1.currentTime;
		P_0.randomHoldTime = P_0.rand.Next((int)(((float)holdTime - 5f) * P_0.beatmapSpeed), (int)(((float)holdTime + 5f) * P_0.beatmapSpeed));
	}

	[CompilerGenerated]
	private void AStartg__releaseKey18_5(ref Ac__DisplayClass18_0 P_0)
	{
		inputSimulator.Keyboard.KeyUp(currentKeyPressed);
		P_0.alreadyHit = false;
		if (P_0.rand.Next(1, 101) <= percentToHitOutsideOffset)
		{
			if (P_0.rand.Next(0, 2) == 0)
			{
				P_0.randomOffset = P_0.rand.Next(-offset * 2, -offset);
			}
			else
			{
				P_0.randomOffset = P_0.rand.Next(offset, offset * 2);
			}
		}
		else
		{
			P_0.randomOffset = P_0.rand.Next(-offset, offset);
		}
	}

	[CompilerGenerated]
	private void AStartg__alternateKeys18_0(ref Ac__DisplayClass18_0 P_0)
	{
		if (currentKeyPressed == P_0.key1)
		{
			currentKeyPressed = P_0.key2;
		}
		else
		{
			currentKeyPressed = P_0.key1;
		}
	}

	[CompilerGenerated]
	private bool AStartg__isMouseOnNote18_1(ref Ac__DisplayClass18_0 P_0)
	{
		return distance(P_0.hitObjectPosition, osu.WindowManager.ScreenToPlayfield(osu.Player.Ruleset.MousePosition)) - (double)P_0.hitObjectRadius <= 0.0;
	}

	[CompilerGenerated]
	private void AStartg__releaseBothKeys18_2(ref Ac__DisplayClass18_0 P_0)
	{
		inputSimulator.Keyboard.KeyUp(P_0.key1);
		inputSimulator.Keyboard.KeyUp(P_0.key2);
	}

	[CompilerGenerated]
	private void AStartg__getNextObject18_3(ref Ac__DisplayClass18_0 P_0)
	{
		P_0.index++;
		if (P_0.index < P_0.beatmap.HitObjects.Count)
		{
			P_0.currentHitObject = P_0.beatmap.HitObjects[P_0.index];
		}
	}
}
