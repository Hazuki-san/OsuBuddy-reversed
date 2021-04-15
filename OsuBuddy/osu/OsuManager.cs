using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using osu.Enums;
using osu.Helpers;
using osu.Memory;
using osu.Memory.Objects.Bindings;
using osu.Memory.Objects.Player;
using osu.Memory.Objects.Window;
using osu.Memory.Processes;
using SimpleDependencyInjection;

namespace osu
{
	// Token: 0x02000085 RID: 133
	public class OsuManager
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00003BBB File Offset: 0x00001DBB
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00003BC3 File Offset: 0x00001DC3
		public string DebugInfo { get; private set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00003BCC File Offset: 0x00001DCC
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public OsuProcess OsuProcess { get; private set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00003BDD File Offset: 0x00001DDD
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00003BE5 File Offset: 0x00001DE5
		public OsuWindowManager WindowManager { get; private set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00003BEE File Offset: 0x00001DEE
		// (set) Token: 0x06000385 RID: 901 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public BindingManager BindingManager { get; private set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00003BFF File Offset: 0x00001DFF
		// (set) Token: 0x06000387 RID: 903 RVA: 0x00003C07 File Offset: 0x00001E07
		public OsuPlayer Player { get; private set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00003C10 File Offset: 0x00001E10
		public int CurrentTime
		{
			get
			{
				return this.OsuProcess.ReadInt32(this.timeAddress);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00003C23 File Offset: 0x00001E23
		public bool IsPaused
		{
			get
			{
				return !this.OsuProcess.ReadBool(this.timeAddress + 48);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00003C40 File Offset: 0x00001E40
		public OsuModes CurrentMode
		{
			get
			{
				return (OsuModes)this.OsuProcess.ReadInt32(this.modeAddress);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00003C53 File Offset: 0x00001E53
		public bool CanLoad
		{
			get
			{
				return this.CurrentMode == OsuModes.Play && this.Player.IsLoaded && !this.Player.ReplayMode;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00003C7C File Offset: 0x00001E7C
		public bool CanPlay
		{
			get
			{
				return this.CurrentMode == OsuModes.Play && this.Player.SingleComponentLoaded;
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00003C95 File Offset: 0x00001E95
		public float HitObjectScalingFactor(float circleSize)
		{
			return 1f - 0.7f * (float)this.AdjustDifficulty((double)circleSize);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00010C00 File Offset: 0x0000EE00
		public float HitObjectRadius(float circleSize)
		{
			float num = this.WindowManager.PlayfieldSize.X / 8f * this.HitObjectScalingFactor(circleSize);
			return num / 2f / this.WindowManager.PlayfieldRatio * 1.00041f;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00003CAC File Offset: 0x00001EAC
		public int HitWindow300(double od)
		{
			return (int)this.DifficultyRange(od, 80.0, 50.0, 20.0);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00003CD1 File Offset: 0x00001ED1
		public int HitWindow100(double od)
		{
			return (int)this.DifficultyRange(od, 140.0, 100.0, 60.0);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00003CF6 File Offset: 0x00001EF6
		public int HitWindow50(double od)
		{
			return (int)this.DifficultyRange(od, 200.0, 150.0, 100.0);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00003D1B File Offset: 0x00001F1B
		public double AdjustDifficulty(double difficulty)
		{
			return (this.ApplyModsToDifficulty(difficulty, 1.3) - 5.0) / 5.0;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00010C50 File Offset: 0x0000EE50
		public double ApplyModsToDifficulty(double difficulty, double hardrockFactor)
		{
			bool flag = this.Player.HitObjectManager.CurrentMods.HasFlag(Mods.Easy);
			if (flag)
			{
				difficulty = Math.Max(0.0, difficulty / 2.0);
			}
			bool flag2 = this.Player.HitObjectManager.CurrentMods.HasFlag(Mods.HardRock);
			if (flag2)
			{
				difficulty = Math.Min(10.0, difficulty * hardrockFactor);
			}
			return difficulty;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00010CDC File Offset: 0x0000EEDC
		public double DifficultyRange(double difficulty, double min, double mid, double max)
		{
			difficulty = this.ApplyModsToDifficulty(difficulty, 1.4);
			bool flag = difficulty > 5.0;
			double result;
			if (flag)
			{
				result = mid + (max - mid) * (difficulty - 5.0) / 5.0;
			}
			else
			{
				bool flag2 = difficulty < 5.0;
				if (flag2)
				{
					result = mid - (mid - min) * (5.0 - difficulty) / 5.0;
				}
				else
				{
					result = mid;
				}
			}
			return result;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00010D60 File Offset: 0x0000EF60
		public bool Initialize(Process osuProcess)
		{
			osuProcess.EnableRaisingEvents = true;
			osuProcess.Exited += OsuManager.Ac.A9.AInitializeb__40_0;
			this.OsuProcess = new OsuProcess(osuProcess);
			DependencyContainer.Cache<OsuProcess>(this.OsuProcess);
			return this.scanMemory();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00010DC0 File Offset: 0x0000EFC0
		public Process tryGetProcess()
		{
			Process process = Process.GetProcessesByName("osu!").FirstOrDefault<Process>();
			bool flag = process != null;
			if (flag)
			{
				IntPtr mainWindowHandle = process.MainWindowHandle;
				string windowTitleByHandle = process.GetWindowTitleByHandle(mainWindowHandle);
				bool flag2 = windowTitleByHandle.StartsWith("osu!") && windowTitleByHandle != "osu! updater";
				if (flag2)
				{
					return process;
				}
			}
			return null;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00010E24 File Offset: 0x0000F024
		private bool scanMemory()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			try
			{
				Console.WriteLine("\nScanning for memory addresses...");
				UIntPtr pointer;
				flag = this.OsuProcess.FindPattern(Signatures.Time.Pattern, out pointer);
				UIntPtr pointer2;
				flag2 = this.OsuProcess.FindPattern(Signatures.Mode.Pattern, out pointer2);
				UIntPtr pointer3;
				flag3 = this.OsuProcess.FindPattern(Signatures.Viewport.Pattern, out pointer3);
				UIntPtr pointer4;
				flag4 = this.OsuProcess.FindPattern(Signatures.BindingManager.Pattern, out pointer4);
				UIntPtr pointer5;
				flag5 = this.OsuProcess.FindPattern(Signatures.Player.Pattern, out pointer5);
				bool flag6 = flag && flag2 && flag3 && flag4 && flag5;
				if (flag6)
				{
					this.timeAddress = (UIntPtr)this.OsuProcess.ReadUInt32(pointer + Signatures.Time.Offset);
					this.modeAddress = (UIntPtr)this.OsuProcess.ReadUInt32(pointer2 + Signatures.Mode.Offset);
					this.WindowManager = new OsuWindowManager((UIntPtr)this.OsuProcess.ReadUInt32(pointer3 + Signatures.Viewport.Offset));
					this.BindingManager = new BindingManager((UIntPtr)this.OsuProcess.ReadUInt32(pointer4 + Signatures.BindingManager.Offset));
					this.Player = new OsuPlayer((UIntPtr)this.OsuProcess.ReadUInt32(pointer5 + Signatures.Player.Offset));
				}
			}
			catch
			{
			}
			bool flag7 = this.timeAddress == UIntPtr.Zero || this.modeAddress == UIntPtr.Zero || this.WindowManager == null || this.BindingManager == null || this.Player == null;
			bool result;
			if (flag7)
			{
				this.DebugInfo = string.Concat(new string[]
				{
					"Time result: ",
					flag ? "success" : "fail",
					"\nMode result: ",
					flag2 ? "success" : "fail",
					"\nViewport result: ",
					flag3 ? "success" : "fail",
					"\nBindingManager result: ",
					flag4 ? "success" : "fail",
					"\nPlayer result: ",
					flag5 ? "success" : "fail"
				});
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x04000300 RID: 768
		private UIntPtr timeAddress;

		// Token: 0x04000301 RID: 769
		private UIntPtr modeAddress;

		// Token: 0x04000302 RID: 770
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ADebugInfok__BackingField;

		// Token: 0x04000303 RID: 771
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OsuProcess AOsuProcessk__BackingField;

		// Token: 0x04000304 RID: 772
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OsuWindowManager AWindowManagerk__BackingField;

		// Token: 0x04000305 RID: 773
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BindingManager ABindingManagerk__BackingField;

		// Token: 0x04000306 RID: 774
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OsuPlayer APlayerk__BackingField;

		// Token: 0x02000086 RID: 134
		[CompilerGenerated]
		[Serializable]
		private sealed class Ac
		{
			// Token: 0x0600039B RID: 923 RVA: 0x00003D4D File Offset: 0x00001F4D
			internal void AInitializeb__40_0(object o, EventArgs e)
			{
				Environment.Exit(0);
			}

			// Token: 0x04000307 RID: 775
			public static readonly OsuManager.Ac A9 = new OsuManager.Ac();

			// Token: 0x04000308 RID: 776
			public static EventHandler A9__40_0;
		}
	}
}
