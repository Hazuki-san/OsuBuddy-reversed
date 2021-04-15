using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
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
		// Token: 0x0600048B RID: 1163 RVA: 0x000045ED File Offset: 0x000045ED
		public ReplayPlayer()
		{
			this.osu = DependencyContainer.Get<OsuManager>();
			this.inputSimulator = new InputSimulator();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001705C File Offset: 0x0001705C
		public void Start(OsuBeatmap beatmap)
		{
			ReplayPlayer.<>c__DisplayClass11_0 CS$<>8__locals1;
			CS$<>8__locals1.<>4__this = this;
			this.beatmap = beatmap;
			this.enabled = true;
			bool flag = this.replayFrames == null;
			if (!flag)
			{
				CS$<>8__locals1.key1 = (VirtualKeyCode)this.osu.BindingManager.GetKeyCode(Bindings.OsuLeft);
				CS$<>8__locals1.key2 = (VirtualKeyCode)this.osu.BindingManager.GetKeyCode(Bindings.OsuRight);
				CS$<>8__locals1.smoke = (VirtualKeyCode)this.osu.BindingManager.GetKeyCode(Bindings.OsuSmoke);
				CS$<>8__locals1.osuWindowRect = this.osu.OsuProcess.getOsuWindowRect();
				Rect osuClientRect = this.osu.OsuProcess.getOsuClientRect();
				CS$<>8__locals1.monitorWidth = Screen.PrimaryScreen.Bounds.Width;
				CS$<>8__locals1.monitorHeight = Screen.PrimaryScreen.Bounds.Height;
				CS$<>8__locals1.windowBorders = (CS$<>8__locals1.osuWindowRect.Right - CS$<>8__locals1.osuWindowRect.Left - osuClientRect.Right) / 2;
				CS$<>8__locals1.titleBarHeight = CS$<>8__locals1.osuWindowRect.Bottom - CS$<>8__locals1.osuWindowRect.Top - osuClientRect.Bottom - CS$<>8__locals1.windowBorders;
				CS$<>8__locals1.frameIndex = 0;
				CS$<>8__locals1.frame = this.replayFrames[CS$<>8__locals1.frameIndex];
				CS$<>8__locals1.totalElapsedFrameTime = 0;
				CS$<>8__locals1.currentTime = this.osu.CurrentTime;
				this.<Start>g__waitForMapStart|11_2(ref CS$<>8__locals1);
				while (this.osu.CanPlay && this.enabled && CS$<>8__locals1.frameIndex < this.replayFrames.Count + 1)
				{
					CS$<>8__locals1.currentTime = this.osu.CurrentTime;
					bool isPaused = this.osu.IsPaused;
					if (isPaused)
					{
						Thread.Sleep(5);
					}
					else
					{
						bool flag2 = CS$<>8__locals1.currentTime >= CS$<>8__locals1.totalElapsedFrameTime;
						if (flag2)
						{
							this.<Start>g__doMouseInput|11_0(ref CS$<>8__locals1);
							this.<Start>g__doKeyboardInput|11_1(ref CS$<>8__locals1);
							int frameIndex = CS$<>8__locals1.frameIndex;
							CS$<>8__locals1.frameIndex = frameIndex + 1;
							bool flag3 = CS$<>8__locals1.frameIndex < this.replayFrames.Count;
							if (flag3)
							{
								CS$<>8__locals1.frame = this.replayFrames[CS$<>8__locals1.frameIndex];
							}
							CS$<>8__locals1.totalElapsedFrameTime += CS$<>8__locals1.frame.TimeDiff;
						}
					}
				}
				Console.WriteLine("Replay Ended.");
				while (this.osu.CanPlay && this.enabled)
				{
					Thread.Sleep(5);
				}
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000172F8 File Offset: 0x000172F8
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

		// Token: 0x0600048E RID: 1166 RVA: 0x000173D8 File Offset: 0x000173D8
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

		// Token: 0x0600048F RID: 1167 RVA: 0x000175D4 File Offset: 0x000175D4
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

		// Token: 0x06000490 RID: 1168 RVA: 0x00017690 File Offset: 0x00017690
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

		// Token: 0x06000491 RID: 1169 RVA: 0x00004622 File Offset: 0x00004622
		public List<ReplayFrame> getReplayFrames()
		{
			return this.replayFrames;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000462A File Offset: 0x0000462A
		public string getReplayPath()
		{
			return this.replayPath;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00004632 File Offset: 0x00004632
		public bool getPlayMouse()
		{
			return this.playMouse;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000463A File Offset: 0x0000463A
		public bool getPlayKeyboard()
		{
			return this.playKeyboard;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00004642 File Offset: 0x00004642
		public void setReplayFrames(List<ReplayFrame> newReplayFrames)
		{
			this.replayFrames = newReplayFrames;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000464C File Offset: 0x0000464C
		public void setShouldInterpolateReplay(bool status)
		{
			this.shouldInterpolateReplay = status;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00004656 File Offset: 0x00004656
		public void setPlayMouse(bool status)
		{
			this.playMouse = status;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00004660 File Offset: 0x00004660
		public void setPlayKeyboard(bool status)
		{
			this.playKeyboard = status;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000466A File Offset: 0x0000466A
		public void Stop()
		{
			this.enabled = false;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00017764 File Offset: 0x00017764
		[CompilerGenerated]
		private void <Start>g__doMouseInput|11_0(ref ReplayPlayer.<>c__DisplayClass11_0 A_1)
		{
			bool flag = this.playMouse;
			if (flag)
			{
				Vector2 mousePosition = this.osu.Player.Ruleset.MousePosition;
				Vector2 vector = this.osu.WindowManager.PlayfieldToScreen(new Vector2(A_1.frame.X, A_1.frame.Y));
				this.inputSimulator.Mouse.MoveMouseTo((double)((vector.X + (float)A_1.osuWindowRect.Left + (float)A_1.windowBorders) * 65536f / (float)A_1.monitorWidth), (double)((vector.Y + (float)A_1.osuWindowRect.Top + (float)A_1.titleBarHeight) * 65536f / (float)A_1.monitorHeight));
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00017828 File Offset: 0x00017828
		[CompilerGenerated]
		private void <Start>g__doKeyboardInput|11_1(ref ReplayPlayer.<>c__DisplayClass11_0 A_1)
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

		// Token: 0x0600049C RID: 1180 RVA: 0x00017934 File Offset: 0x00017934
		[CompilerGenerated]
		private void <Start>g__waitForMapStart|11_2(ref ReplayPlayer.<>c__DisplayClass11_0 A_1)
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
			this.<Start>g__doMouseInput|11_0(ref A_1);
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
	}
}
