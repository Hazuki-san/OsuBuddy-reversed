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
using OsuParsers.Decoders;
using OsuParsers.Enums.Replays;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using SimpleDependencyInjection;
using WindowsInput;
using WindowsInput.Native;

namespace OsuBuddy
{
	// Token: 0x020000B1 RID: 177
	public class ReplayPlayer
	{
		// Token: 0x0600048B RID: 1163 RVA: 0x000045ED File Offset: 0x000027ED
		public ReplayPlayer()
		{
			this.osu = DependencyContainer.Get<OsuManager>();
			this.inputSimulator = new InputSimulator();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001705C File Offset: 0x0001525C
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

		// Token: 0x0600048D RID: 1165 RVA: 0x000172F8 File Offset: 0x000154F8
		public void selectReplay(string replayPath)
		{
			bool flag = string.IsNullOrEmpty(replayPath);
			if (!flag)
			{
				this.replayPath = replayPath;
				Console.WriteLine("Decoding replay, please wait...");
				this.replay = ReplayDecoder.Decode(this.replayPath);
				this.replayFrames = this.replay.ReplayFrames;
				Console.WriteLine("Replay Loaded.");
				Console.WriteLine("Played by: " + this.replay.PlayerName);
				Console.WriteLine("Ruleset: " + this.replay.Ruleset.ToString());
				Console.WriteLine("Using mods: " + this.replay.Mods.ToString());
				bool flag2 = this.shouldInterpolateReplay;
				if (flag2)
				{
					this.replayFrames = this.interpolateReplay();
				}
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000173D8 File Offset: 0x000155D8
		public List<ReplayFrame> interpolateReplay()
		{
			bool flag = this.replayFrames == null;
			List<ReplayFrame> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Console.WriteLine("Interpolating replay...");
				List<ReplayFrame> list = new List<ReplayFrame>();
				int i = 0;
				while (i < this.replayFrames.Count - 1)
				{
					ReplayFrame replayFrame = new ReplayFrame();
					replayFrame.X = (this.replayFrames[i].X + this.replayFrames[i + 1].X) / 2f;
					replayFrame.Y = (this.replayFrames[i].Y + this.replayFrames[i + 1].Y) / 2f;
					replayFrame.TimeDiff = this.replayFrames[i].TimeDiff;
					StandardKeys standardKeys = this.replayFrames[i].StandardKeys;
					StandardKeys standardKeys2 = standardKeys;
					if (standardKeys2 <= StandardKeys.K2)
					{
						if (standardKeys2 != StandardKeys.K1)
						{
							if (standardKeys2 != StandardKeys.K2)
							{
								goto IL_11F;
							}
							replayFrame.StandardKeys = StandardKeys.K2;
						}
						else
						{
							replayFrame.StandardKeys = StandardKeys.K1;
						}
					}
					else if (standardKeys2 != StandardKeys.BOTH)
					{
						if (standardKeys2 != StandardKeys.Smoke)
						{
							goto IL_11F;
						}
						replayFrame.StandardKeys = StandardKeys.Smoke;
					}
					else
					{
						replayFrame.StandardKeys = StandardKeys.BOTH;
					}
					IL_12A:
					ReplayFrame replayFrame2 = this.replayFrames[i];
					replayFrame2.TimeDiff /= 2;
					replayFrame.TimeDiff -= replayFrame2.TimeDiff;
					list.Add(replayFrame2);
					list.Add(replayFrame);
					i++;
					continue;
					IL_11F:
					replayFrame.StandardKeys = StandardKeys.None;
					goto IL_12A;
				}
				Console.WriteLine("Interpolated replay");
				Console.WriteLine("Original frame count: " + this.replayFrames.Count.ToString());
				Console.WriteLine("Interpolated frame count: " + (list.Count - this.replayFrames.Count).ToString());
				result = list;
			}
			return result;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000175D4 File Offset: 0x000157D4
		public List<ReplayFrame> flipReplay()
		{
			bool flag = this.replayFrames == null;
			List<ReplayFrame> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Console.WriteLine("Flipping replay...");
				List<ReplayFrame> list = new List<ReplayFrame>();
				foreach (ReplayFrame replayFrame in this.replayFrames)
				{
					ReplayFrame replayFrame2 = replayFrame;
					float num = 192f - replayFrame.Y;
					replayFrame2.Y = replayFrame.Y + num * 2f;
					list.Add(replayFrame2);
				}
				Console.WriteLine("Flipped replay");
				result = list;
			}
			return result;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00017690 File Offset: 0x00015890
		public void printReplayFrames()
		{
			foreach (ReplayFrame replayFrame in this.replayFrames)
			{
				Console.WriteLine(string.Concat(new string[]
				{
					"X: ",
					replayFrame.X.ToString(),
					", Y: ",
					replayFrame.Y.ToString(),
					", Keys: ",
					replayFrame.StandardKeys.ToString(),
					", Time diff: ",
					replayFrame.TimeDiff.ToString()
				}));
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00004622 File Offset: 0x00002822
		public List<ReplayFrame> getReplayFrames()
		{
			return this.replayFrames;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000462A File Offset: 0x0000282A
		public string getReplayPath()
		{
			return this.replayPath;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00004632 File Offset: 0x00002832
		public bool getPlayMouse()
		{
			return this.playMouse;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000463A File Offset: 0x0000283A
		public bool getPlayKeyboard()
		{
			return this.playKeyboard;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00004642 File Offset: 0x00002842
		public void setReplayFrames(List<ReplayFrame> newReplayFrames)
		{
			this.replayFrames = newReplayFrames;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000464C File Offset: 0x0000284C
		public void setShouldInterpolateReplay(bool status)
		{
			this.shouldInterpolateReplay = status;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00004656 File Offset: 0x00002856
		public void setPlayMouse(bool status)
		{
			this.playMouse = status;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00004660 File Offset: 0x00002860
		public void setPlayKeyboard(bool status)
		{
			this.playKeyboard = status;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000466A File Offset: 0x0000286A
		public void Stop()
		{
			this.enabled = false;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00017764 File Offset: 0x00015964
		[CompilerGenerated]
		private void AStartg__doMouseInput11_0(ref ReplayPlayer.Ac__DisplayClass11_0 A_1)
		{
			bool flag = this.playMouse;
			if (flag)
			{
				Vector2 mousePosition = this.osu.Player.Ruleset.MousePosition;
				Vector2 vector = this.osu.WindowManager.PlayfieldToScreen(new Vector2(A_1.frame.X, A_1.frame.Y));
				this.inputSimulator.Mouse.MoveMouseTo((double)((vector.X + (float)A_1.osuWindowRect.Left + (float)A_1.windowBorders) * 65536f / (float)A_1.monitorWidth), (double)((vector.Y + (float)A_1.osuWindowRect.Top + (float)A_1.titleBarHeight) * 65536f / (float)A_1.monitorHeight));
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00017828 File Offset: 0x00015A28
		[CompilerGenerated]
		private void AStartg__doKeyboardInput11_1(ref ReplayPlayer.Ac__DisplayClass11_0 A_1)
		{
			bool flag = this.playKeyboard;
			if (flag)
			{
				bool flag2 = A_1.frame.StandardKeys == StandardKeys.K1 || A_1.frame.StandardKeys == StandardKeys.BOTH;
				if (flag2)
				{
					this.inputSimulator.Keyboard.KeyDown(A_1.key1);
				}
				else
				{
					this.inputSimulator.Keyboard.KeyUp(A_1.key1);
				}
				bool flag3 = A_1.frame.StandardKeys == StandardKeys.K2 || A_1.frame.StandardKeys == StandardKeys.BOTH;
				if (flag3)
				{
					this.inputSimulator.Keyboard.KeyDown(A_1.key2);
				}
				else
				{
					this.inputSimulator.Keyboard.KeyUp(A_1.key2);
				}
				bool flag4 = A_1.frame.StandardKeys == StandardKeys.Smoke;
				if (flag4)
				{
					this.inputSimulator.Keyboard.KeyDown(A_1.smoke);
				}
				else
				{
					this.inputSimulator.Keyboard.KeyUp(A_1.smoke);
				}
			}
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00017934 File Offset: 0x00015B34
		[CompilerGenerated]
		private void AStartg__waitForMapStart11_2(ref ReplayPlayer.Ac__DisplayClass11_0 A_1)
		{
			while (A_1.currentTime >= A_1.totalElapsedFrameTime || A_1.frame.X < 0f || A_1.frame.X > 512f || A_1.frame.Y < 0f || A_1.frame.Y > 384f || A_1.frame.TimeDiff < 0)
			{
				int frameIndex = A_1.frameIndex;
				A_1.frameIndex = frameIndex + 1;
				bool flag = A_1.frameIndex < this.replayFrames.Count;
				if (flag)
				{
					A_1.frame = this.replayFrames[A_1.frameIndex];
				}
				A_1.totalElapsedFrameTime += A_1.frame.TimeDiff;
			}
			this.AStartg__doMouseInput11_0(ref A_1);
		}

		// Token: 0x04000467 RID: 1127
		private OsuManager osu;

		// Token: 0x04000468 RID: 1128
		private OsuBeatmap beatmap;

		// Token: 0x04000469 RID: 1129
		private bool enabled;

		// Token: 0x0400046A RID: 1130
		private Replay replay;

		// Token: 0x0400046B RID: 1131
		private List<ReplayFrame> replayFrames;

		// Token: 0x0400046C RID: 1132
		private string replayPath;

		// Token: 0x0400046D RID: 1133
		private InputSimulator inputSimulator;

		// Token: 0x0400046E RID: 1134
		private bool shouldInterpolateReplay = false;

		// Token: 0x0400046F RID: 1135
		private bool playMouse = true;

		// Token: 0x04000470 RID: 1136
		private bool playKeyboard = true;

		// Token: 0x020000B2 RID: 178
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct Ac__DisplayClass11_0
		{
			// Token: 0x04000471 RID: 1137
			public ReplayPlayer A4__this;

			// Token: 0x04000472 RID: 1138
			public ReplayFrame frame;

			// Token: 0x04000473 RID: 1139
			public Rect osuWindowRect;

			// Token: 0x04000474 RID: 1140
			public int windowBorders;

			// Token: 0x04000475 RID: 1141
			public int monitorWidth;

			// Token: 0x04000476 RID: 1142
			public int titleBarHeight;

			// Token: 0x04000477 RID: 1143
			public int monitorHeight;

			// Token: 0x04000478 RID: 1144
			public VirtualKeyCode key1;

			// Token: 0x04000479 RID: 1145
			public VirtualKeyCode key2;

			// Token: 0x0400047A RID: 1146
			public VirtualKeyCode smoke;

			// Token: 0x0400047B RID: 1147
			public int frameIndex;

			// Token: 0x0400047C RID: 1148
			public int totalElapsedFrameTime;

			// Token: 0x0400047D RID: 1149
			public int currentTime;
		}
	}
}
