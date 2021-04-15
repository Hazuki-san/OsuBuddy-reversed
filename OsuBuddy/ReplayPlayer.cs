using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using osu;
using osu.Memory.Objects.Bindings;
using osu.Memory.Objects.Player.Beatmaps;
using osu.Memory.Processes;
using OsuBuddy;
using OsuParsers.Decoders;
using OsuParsers.Enums.Replays;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using SimpleDependencyInjection;
using WindowsInput;
using WindowsInput.Native;

public class ReplayPlayer
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct Ac__DisplayClass11_0
	{
		public ReplayPlayer A4__this;

		public ReplayFrame frame;

		public Rect osuWindowRect;

		public int windowBorders;

		public int monitorWidth;

		public int titleBarHeight;

		public int monitorHeight;

		public VirtualKeyCode key1;

		public VirtualKeyCode key2;

		public VirtualKeyCode smoke;

		public int frameIndex;

		public int totalElapsedFrameTime;

		public int currentTime;
	}

	private OsuManager osu;

	private OsuBeatmap beatmap;

	private bool enabled;

	private Replay replay;

	private List<ReplayFrame> replayFrames;

	private string replayPath;

	private InputSimulator inputSimulator;

	private bool shouldInterpolateReplay = false;

	private bool playMouse = true;

	private bool playKeyboard = true;

	public ReplayPlayer()
	{
		osu = DependencyContainer.Get<OsuManager>();
		inputSimulator = new InputSimulator();
	}

	public void Start(OsuBeatmap beatmap)
	{
		Ac__DisplayClass11_0 ac__DisplayClass11_ = default(Ac__DisplayClass11_0);
		ac__DisplayClass11_.A4__this = this;
		this.beatmap = beatmap;
		enabled = true;
		if (replayFrames == null)
		{
			return;
		}
		ac__DisplayClass11_.key1 = (VirtualKeyCode)osu.BindingManager.GetKeyCode(Bindings.OsuLeft);
		ac__DisplayClass11_.key2 = (VirtualKeyCode)osu.BindingManager.GetKeyCode(Bindings.OsuRight);
		ac__DisplayClass11_.smoke = (VirtualKeyCode)osu.BindingManager.GetKeyCode(Bindings.OsuSmoke);
		ac__DisplayClass11_.osuWindowRect = osu.OsuProcess.getOsuWindowRect();
		Rect osuClientRect = osu.OsuProcess.getOsuClientRect();
		ac__DisplayClass11_.monitorWidth = Screen.PrimaryScreen.Bounds.Width;
		ac__DisplayClass11_.monitorHeight = Screen.PrimaryScreen.Bounds.Height;
		ac__DisplayClass11_.windowBorders = (ac__DisplayClass11_.osuWindowRect.Right - ac__DisplayClass11_.osuWindowRect.Left - osuClientRect.Right) / 2;
		ac__DisplayClass11_.titleBarHeight = ac__DisplayClass11_.osuWindowRect.Bottom - ac__DisplayClass11_.osuWindowRect.Top - osuClientRect.Bottom - ac__DisplayClass11_.windowBorders;
		ac__DisplayClass11_.frameIndex = 0;
		ac__DisplayClass11_.frame = replayFrames[ac__DisplayClass11_.frameIndex];
		ac__DisplayClass11_.totalElapsedFrameTime = 0;
		ac__DisplayClass11_.currentTime = osu.CurrentTime;
		AStartg__waitForMapStart11_2(ref ac__DisplayClass11_);
		while (osu.CanPlay && enabled && ac__DisplayClass11_.frameIndex < replayFrames.Count + 1)
		{
			ac__DisplayClass11_.currentTime = osu.CurrentTime;
			if (osu.IsPaused)
			{
				Thread.Sleep(5);
			}
			else if (ac__DisplayClass11_.currentTime >= ac__DisplayClass11_.totalElapsedFrameTime)
			{
				AStartg__doMouseInput11_0(ref ac__DisplayClass11_);
				AStartg__doKeyboardInput11_1(ref ac__DisplayClass11_);
				ac__DisplayClass11_.frameIndex++;
				if (ac__DisplayClass11_.frameIndex < replayFrames.Count)
				{
					ac__DisplayClass11_.frame = replayFrames[ac__DisplayClass11_.frameIndex];
				}
				ac__DisplayClass11_.totalElapsedFrameTime += ac__DisplayClass11_.frame.TimeDiff;
			}
		}
		Console.WriteLine("Replay Ended.");
		while (osu.CanPlay && enabled)
		{
			Thread.Sleep(5);
		}
	}

	public void selectReplay(string replayPath)
	{
		if (!string.IsNullOrEmpty(replayPath))
		{
			this.replayPath = replayPath;
			Console.WriteLine("Decoding replay, please wait...");
			replay = ReplayDecoder.Decode(this.replayPath);
			replayFrames = replay.ReplayFrames;
			Console.WriteLine("Replay Loaded.");
			Console.WriteLine("Played by: " + replay.PlayerName);
			Console.WriteLine("Ruleset: " + replay.Ruleset);
			Console.WriteLine("Using mods: " + replay.Mods);
			if (shouldInterpolateReplay)
			{
				replayFrames = interpolateReplay();
			}
		}
	}

	public List<ReplayFrame> interpolateReplay()
	{
		if (replayFrames == null)
		{
			return null;
		}
		Console.WriteLine("Interpolating replay...");
		List<ReplayFrame> list = new List<ReplayFrame>();
		for (int i = 0; i < replayFrames.Count - 1; i++)
		{
			ReplayFrame replayFrame = new ReplayFrame();
			replayFrame.X = (replayFrames[i].X + replayFrames[i + 1].X) / 2f;
			replayFrame.Y = (replayFrames[i].Y + replayFrames[i + 1].Y) / 2f;
			replayFrame.TimeDiff = replayFrames[i].TimeDiff;
			switch (replayFrames[i].StandardKeys)
			{
				case StandardKeys.K1:
					replayFrame.StandardKeys = StandardKeys.K1;
					break;
				case StandardKeys.K2:
					replayFrame.StandardKeys = StandardKeys.K2;
					break;
				case StandardKeys.BOTH:
					replayFrame.StandardKeys = StandardKeys.BOTH;
					break;
				case StandardKeys.Smoke:
					replayFrame.StandardKeys = StandardKeys.Smoke;
					break;
				default:
					replayFrame.StandardKeys = StandardKeys.None;
					break;
			}
			ReplayFrame replayFrame2 = replayFrames[i];
			replayFrame2.TimeDiff /= 2;
			replayFrame.TimeDiff -= replayFrame2.TimeDiff;
			list.Add(replayFrame2);
			list.Add(replayFrame);
		}
		Console.WriteLine("Interpolated replay");
		Console.WriteLine("Original frame count: " + replayFrames.Count);
		Console.WriteLine("Interpolated frame count: " + (list.Count - replayFrames.Count));
		return list;
	}

	public List<ReplayFrame> flipReplay()
	{
		if (replayFrames == null)
		{
			return null;
		}
		Console.WriteLine("Flipping replay...");
		List<ReplayFrame> list = new List<ReplayFrame>();
		foreach (ReplayFrame replayFrame2 in replayFrames)
		{
			ReplayFrame replayFrame = replayFrame2;
			float num = 192f - replayFrame2.Y;
			replayFrame.Y = replayFrame2.Y + num * 2f;
			list.Add(replayFrame);
		}
		Console.WriteLine("Flipped replay");
		return list;
	}

	public void printReplayFrames()
	{
		foreach (ReplayFrame replayFrame in replayFrames)
		{
			Console.WriteLine("X: " + replayFrame.X + ", Y: " + replayFrame.Y + ", Keys: " + replayFrame.StandardKeys.ToString() + ", Time diff: " + replayFrame.TimeDiff);
		}
	}

	public List<ReplayFrame> getReplayFrames()
	{
		return replayFrames;
	}

	public string getReplayPath()
	{
		return replayPath;
	}

	public bool getPlayMouse()
	{
		return playMouse;
	}

	public bool getPlayKeyboard()
	{
		return playKeyboard;
	}

	public void setReplayFrames(List<ReplayFrame> newReplayFrames)
	{
		replayFrames = newReplayFrames;
	}

	public void setShouldInterpolateReplay(bool status)
	{
		shouldInterpolateReplay = status;
	}

	public void setPlayMouse(bool status)
	{
		playMouse = status;
	}

	public void setPlayKeyboard(bool status)
	{
		playKeyboard = status;
	}

	public void Stop()
	{
		enabled = false;
	}

	[CompilerGenerated]
	private void AStartg__doMouseInput11_0(ref Ac__DisplayClass11_0 P_0)
	{
		if (playMouse)
		{
			Vector2 mousePosition = osu.Player.Ruleset.MousePosition;
			Vector2 vector = osu.WindowManager.PlayfieldToScreen(new Vector2(P_0.frame.X, P_0.frame.Y));
			inputSimulator.Mouse.MoveMouseTo((double)((vector.X + (float)P_0.osuWindowRect.Left + (float)P_0.windowBorders) * 65536f / (float)P_0.monitorWidth), (double)((vector.Y + (float)P_0.osuWindowRect.Top + (float)P_0.titleBarHeight) * 65536f / (float)P_0.monitorHeight));
		}
	}

	[CompilerGenerated]
	private void AStartg__doKeyboardInput11_1(ref Ac__DisplayClass11_0 P_0)
	{
		if (playKeyboard)
		{
			if (P_0.frame.StandardKeys == StandardKeys.K1 || P_0.frame.StandardKeys == StandardKeys.BOTH)
			{
				inputSimulator.Keyboard.KeyDown(P_0.key1);
			}
			else
			{
				inputSimulator.Keyboard.KeyUp(P_0.key1);
			}
			if (P_0.frame.StandardKeys == StandardKeys.K2 || P_0.frame.StandardKeys == StandardKeys.BOTH)
			{
				inputSimulator.Keyboard.KeyDown(P_0.key2);
			}
			else
			{
				inputSimulator.Keyboard.KeyUp(P_0.key2);
			}
			if (P_0.frame.StandardKeys == StandardKeys.Smoke)
			{
				inputSimulator.Keyboard.KeyDown(P_0.smoke);
			}
			else
			{
				inputSimulator.Keyboard.KeyUp(P_0.smoke);
			}
		}
	}

	[CompilerGenerated]
	private void AStartg__waitForMapStart11_2(ref Ac__DisplayClass11_0 P_0)
	{
		while (P_0.currentTime >= P_0.totalElapsedFrameTime || P_0.frame.X < 0f || P_0.frame.X > 512f || P_0.frame.Y < 0f || P_0.frame.Y > 384f || P_0.frame.TimeDiff < 0)
		{
			P_0.frameIndex++;
			if (P_0.frameIndex < replayFrames.Count)
			{
				P_0.frame = replayFrames[P_0.frameIndex];
			}
			P_0.totalElapsedFrameTime += P_0.frame.TimeDiff;
		}
		AStartg__doMouseInput11_0(ref P_0);
	}
}
