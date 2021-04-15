using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using osu;
using osu.Enums;
using osu.Memory.Objects.Player.Beatmaps;
using SimpleDependencyInjection;

namespace OsuBuddy
{
	// Token: 0x020000B3 RID: 179
	public class OsuBuddy
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x00017A18 File Offset: 0x00015C18
		public void run()
		{
			OsuBuddy.osu = new OsuManager();
			this.getOsu();
			DependencyContainer.Cache<OsuManager>(OsuBuddy.osu);
			this.aimAssist = new AimAssist();
			this.relax = new Relax();
			this.replayPlayer = new ReplayPlayer();
			this.gui = new GUI(this);
			this.user = new User("", "");
			this.gui.Text = "OsuBuddyCrack - " + this.user.getUsername();
			this.gui.updateLoginGui(this.user.getUsername(), this.user.getSubscriptionExpirationDate());
			Thread thread = new Thread(new ThreadStart(this.Arunb__0_0));
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			this.StartTasks();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00017AE8 File Offset: 0x00015CE8
		private void getOsu()
		{
			Process process = OsuBuddy.osu.tryGetProcess();
			if (process == null)
			{
				MessageBox.Show(new Form
				{
					TopMost = true
				}, "Please open osu! and then click OK", "OsuBuddy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				while (process == null)
				{
					process = OsuBuddy.osu.tryGetProcess();
					Thread.Sleep(1000);
				}
			}
			if (OsuBuddy.osu.Initialize(process))
			{
				return;
			}
			Console.Clear();
			Console.WriteLine("OsuBuddy failed startup...\n");
			Console.WriteLine("Could not gather osu memory.");
			for (;;)
			{
				Thread.Sleep(1000);
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00017B74 File Offset: 0x00015D74
		private void StartTasks()
		{
			bool flag = true;
			while (flag)
			{
				OsuBuddy.Ac__DisplayClass2_0 ac__DisplayClass2_ = new OsuBuddy.Ac__DisplayClass2_0();
				ac__DisplayClass2_.A4__this = this;
				this.gui.setStatus("Waiting for beatmap selection...");
				Console.WriteLine("Waiting for beatmap selection...");
				while (!OsuBuddy.osu.CanLoad && flag)
				{
					Thread.Sleep(5);
				}
				if (!flag)
				{
					break;
				}
				ac__DisplayClass2_.beatmap = OsuBuddy.osu.Player.Beatmap;
				this.gui.setStatus(string.Concat(new string[]
				{
					"Playing ",
					ac__DisplayClass2_.beatmap.Artist,
					" - ",
					ac__DisplayClass2_.beatmap.Title,
					" [",
					ac__DisplayClass2_.beatmap.Version,
					"] Mapped by ",
					ac__DisplayClass2_.beatmap.Creator
				}));
				Console.WriteLine(string.Concat(new string[]
				{
					"Playing ",
					ac__DisplayClass2_.beatmap.Artist,
					" - ",
					ac__DisplayClass2_.beatmap.Title,
					" [",
					ac__DisplayClass2_.beatmap.Version,
					"] Mapped by ",
					ac__DisplayClass2_.beatmap.Creator
				}));
				while (!this.aimAssistEnabled && !this.relaxEnabled && (!this.replayPlayerEnabled || this.replayPlayer.getReplayFrames() == null))
				{
					this.aimAssist.Stop();
					this.relax.Stop();
					this.replayPlayer.Stop();
					Thread.Sleep(5);
					if (!OsuBuddy.osu.CanLoad)
					{
						break;
					}
				}
				if (this.user != null)
				{
					if (!this.user.isSubscribed())
					{
						OsuBuddy.exit();
					}
				}
				else
				{
					OsuBuddy.exit();
				}
				Task task = Task.Factory.StartNew(new Action(ac__DisplayClass2_.AStartTasksb__0));
				Task task2 = Task.Factory.StartNew(new Action(ac__DisplayClass2_.AStartTasksb__1));
				Task task3 = Task.Factory.StartNew(new Action(ac__DisplayClass2_.AStartTasksb__2));
				Task.WaitAll(new Task[]
				{
					task,
					task2,
					task3
				});
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00004673 File Offset: 0x00002873
		public void login(string username, string password)
		{
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00004675 File Offset: 0x00002875
		public static void exit()
		{
			Application.Exit();
			Environment.Exit(1);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00004682 File Offset: 0x00002882
		public User getUser()
		{
			return this.user;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000468A File Offset: 0x0000288A
		public AimAssist getAimAssist()
		{
			return this.aimAssist;
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00004692 File Offset: 0x00002892
		public Relax getRelax()
		{
			return this.relax;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000469A File Offset: 0x0000289A
		public ReplayPlayer getReplayPlayer()
		{
			return this.replayPlayer;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000046B2 File Offset: 0x000028B2
		[CompilerGenerated]
		private void Arunb__0_0()
		{
			this.gui.ShowDialog();
		}

		// Token: 0x0400047E RID: 1150
		private User user;

		// Token: 0x0400047F RID: 1151
		private GUI gui;

		// Token: 0x04000480 RID: 1152
		private static OsuManager osu;

		// Token: 0x04000481 RID: 1153
		private AimAssist aimAssist;

		// Token: 0x04000482 RID: 1154
		private Relax relax;

		// Token: 0x04000483 RID: 1155
		private ReplayPlayer replayPlayer;

		// Token: 0x04000484 RID: 1156
		private int failedLoginAttempts;

		// Token: 0x04000485 RID: 1157
		private int loginTimeoutTime = 30;

		// Token: 0x04000486 RID: 1158
		private long loginTimeoutStartTime;

		// Token: 0x04000487 RID: 1159
		private long loginTimeoutEndTime;

		// Token: 0x04000488 RID: 1160
		private bool timedOut;

		// Token: 0x04000489 RID: 1161
		public bool aimAssistEnabled;

		// Token: 0x0400048A RID: 1162
		public bool relaxEnabled;

		// Token: 0x0400048B RID: 1163
		public bool replayPlayerEnabled;

		// Token: 0x020000B4 RID: 180
		[CompilerGenerated]
		private sealed class Ac__DisplayClass2_0
		{
			// Token: 0x060004A9 RID: 1193 RVA: 0x000046C8 File Offset: 0x000028C8
			internal void AStartTasksb__0()
			{
				if (this.A4__this.aimAssistEnabled && OsuBuddy.osu.Player.CurrentRuleset == Ruleset.Standard)
				{
					this.A4__this.aimAssist.Start(this.beatmap);
				}
			}

			// Token: 0x060004AA RID: 1194 RVA: 0x00004704 File Offset: 0x00002904
			internal void AStartTasksb__1()
			{
				if (this.A4__this.relaxEnabled && OsuBuddy.osu.Player.CurrentRuleset == Ruleset.Standard)
				{
					this.A4__this.relax.Start(this.beatmap);
				}
			}

			// Token: 0x060004AB RID: 1195 RVA: 0x00004740 File Offset: 0x00002940
			internal void AStartTasksb__2()
			{
				if (this.A4__this.replayPlayerEnabled && OsuBuddy.osu.Player.CurrentRuleset == Ruleset.Standard)
				{
					this.A4__this.replayPlayer.Start(this.beatmap);
				}
			}

			// Token: 0x0400048C RID: 1164
			public OsuBeatmap beatmap;

			// Token: 0x0400048D RID: 1165
			public OsuBuddy A4__this;
		}
	}
}
