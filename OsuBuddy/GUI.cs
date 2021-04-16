using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OsuBuddy
{
	// Token: 0x020000AA RID: 170
	public partial class GUI : Form
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x0000442C File Offset: 0x0000262C
		public GUI(OsuBuddy osuBuddy)
		{
			this.osuBuddy = osuBuddy;
			Application.EnableVisualStyles();
			this.InitializeComponent();
			this.initValues();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00012568 File Offset: 0x00010768
		public void initValues()
		{
			this.aimSpeedTrackBar.Minimum = this.osuBuddy.getAimAssist().AIM_SPEED_MIN;
			this.aimSpeedTrackBar.Maximum = this.osuBuddy.getAimAssist().AIM_SPEED_MAX;
			this.aimSpeedTrackBar.Value = this.osuBuddy.getAimAssist().getAimSpeed();
			this.aimSpeedOutput.Text = this.osuBuddy.getAimAssist().getAimSpeed().ToString();
			this.aimStartDistanceTrackBar.Minimum = this.osuBuddy.getAimAssist().AIM_STARTING_DISTANCE_MIN;
			this.aimStartDistanceTrackBar.Maximum = this.osuBuddy.getAimAssist().AIM_STARTING_DISTANCE_MAX;
			this.aimStartDistanceTrackBar.Value = this.osuBuddy.getAimAssist().getAimStartingDistance();
			this.aimStartDistanceOutput.Text = this.osuBuddy.getAimAssist().getAimStartingDistance().ToString();
			this.aimStopDistanceTrackBar.Minimum = this.osuBuddy.getAimAssist().AIM_STOPPING_DISTANCE_MIN;
			this.aimStopDistanceTrackBar.Maximum = this.osuBuddy.getAimAssist().AIM_STOPPING_DISTANCE_MAX;
			this.aimStopDistanceTrackBar.Value = this.osuBuddy.getAimAssist().getAimStoppingDistance();
			this.aimStopDistanceOutput.Text = this.osuBuddy.getAimAssist().getAimStoppingDistance().ToString();
			this.offsetTrackBar.Minimum = this.osuBuddy.getRelax().OFFSET_MIN;
			this.offsetTrackBar.Maximum = this.osuBuddy.getRelax().OFFSET_MAX;
			this.offsetTrackBar.Value = this.osuBuddy.getRelax().getOffset();
			this.offsetOutput.Text = this.osuBuddy.getRelax().getOffset().ToString();
			this.holdTimeTrackBar.Minimum = this.osuBuddy.getRelax().HOLD_TIME_MIN;
			this.holdTimeTrackBar.Maximum = this.osuBuddy.getRelax().HOLD_TIME_MAX;
			this.holdTimeTrackBar.Value = this.osuBuddy.getRelax().getHoldTime();
			this.holdTimeOutput.Text = this.osuBuddy.getRelax().getHoldTime().ToString();
			this.alternateTimeTrackBar.Minimum = this.osuBuddy.getRelax().ALTERNATE_TIME_MIN;
			this.alternateTimeTrackBar.Maximum = this.osuBuddy.getRelax().ALTERNATE_TIME_MAX;
			this.alternateTimeTrackBar.Value = this.osuBuddy.getRelax().getAlternateTime();
			this.alternateTimeOutput.Text = this.osuBuddy.getRelax().getAlternateTime().ToString();
			this.percentToHitOutsideOffsetTrackBar.Minimum = this.osuBuddy.getRelax().PERCENT_TO_HIT_OUTSIDE_OFFSET_MIN;
			this.percentToHitOutsideOffsetTrackBar.Maximum = this.osuBuddy.getRelax().PERCENT_TO_HIT_OUTSIDE_OFFSET_MAX;
			this.percentToHitOutsideOffsetTrackBar.Value = this.osuBuddy.getRelax().getPercentToHitOutsideOffset();
			this.percentToHitOutsideOffsetOutput.Text = this.osuBuddy.getRelax().getPercentToHitOutsideOffset().ToString();
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00004452 File Offset: 0x00002652
		public void logo_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.taikobuddy.com");
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000128C0 File Offset: 0x00010AC0
		public void setStatus(string status)
		{
			GUI.Ac__DisplayClass4_0 ac__DisplayClass4_ = new GUI.Ac__DisplayClass4_0();
			ac__DisplayClass4_.A4__this = this;
			ac__DisplayClass4_.status = status;
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.BeginInvoke(new Action(ac__DisplayClass4_.AsetStatusb__0));
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00004460 File Offset: 0x00002660
		public void setLoginStatus(string status)
		{
			this.loginTextLabel.Text = status;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00004470 File Offset: 0x00002670
		private void GUI_Closing(object sender, FormClosingEventArgs e)
		{
			OsuBuddy.exit();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00012904 File Offset: 0x00010B04
		private void textBox_KeyPress(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return && this.userLoginButton.Enabled;
			if (flag)
			{
				this.login(this, new EventArgs());
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00012940 File Offset: 0x00010B40
		private void login(object sender, EventArgs e)
		{
			string text = this.usernameTextBox.Text;
			string text2 = this.passwordTextBox.Text;
			bool flag = string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2);
			if (flag)
			{
				this.setStatus("Login error - Invalid login, Incorrect username or password");
			}
			else
			{
				this.osuBuddy.login(text, text2);
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00012998 File Offset: 0x00010B98
		public void updateLoginGui(string username, string expirationDate)
		{
			this.loginTextLabel.Text = "Welcome " + username + "!\n Subscription expires: " + expirationDate;
			this.userLoginButton.Enabled = false;
			this.usernameTextBox.Enabled = false;
			this.passwordTextBox.Enabled = false;
			this.aimAssistButton.Enabled = true;
			this.relaxButton.Enabled = true;
			this.replayPlayerButton.Enabled = true;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00004479 File Offset: 0x00002679
		private void loginButton_Click(object sender, EventArgs e)
		{
			this.selectedPanel.Top = this.loginButton.Top;
			this.tabControl.SelectedIndex = 0;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000044A0 File Offset: 0x000026A0
		private void aimAssistButton_Click(object sender, EventArgs e)
		{
			this.selectedPanel.Top = this.aimAssistButton.Top;
			this.tabControl.SelectedIndex = 1;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000044C7 File Offset: 0x000026C7
		private void relaxButton_Click(object sender, EventArgs e)
		{
			this.selectedPanel.Top = this.relaxButton.Top;
			this.tabControl.SelectedIndex = 2;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000044EE File Offset: 0x000026EE
		private void replayPlayerButton_Click(object sender, EventArgs e)
		{
			this.selectedPanel.Top = this.replayPlayerButton.Top;
			this.tabControl.SelectedIndex = 3;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00012A14 File Offset: 0x00010C14
		private void aimAssistToggleButton_Click(object sender, EventArgs e)
		{
			this.osuBuddy.aimAssistEnabled = !this.osuBuddy.aimAssistEnabled;
			bool flag = !this.osuBuddy.aimAssistEnabled;
			if (flag)
			{
				this.osuBuddy.getAimAssist().Stop();
				this.aimAssistToggleButton.BackColor = Color.Red;
				this.aimAssistToggleButton.Text = "Disabled";
			}
			else
			{
				this.aimAssistToggleButton.BackColor = Color.Green;
				this.aimAssistToggleButton.Text = "Enabled";
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00012AA8 File Offset: 0x00010CA8
		private void relaxToggleButton_Click(object sender, EventArgs e)
		{
			this.osuBuddy.relaxEnabled = !this.osuBuddy.relaxEnabled;
			bool flag = !this.osuBuddy.relaxEnabled;
			if (flag)
			{
				this.osuBuddy.getRelax().Stop();
				this.relaxToggleButton.BackColor = Color.Red;
				this.relaxToggleButton.Text = "Disabled";
			}
			else
			{
				this.relaxToggleButton.BackColor = Color.Green;
				this.relaxToggleButton.Text = "Enabled";
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00012B3C File Offset: 0x00010D3C
		private void replayPlayerToggleButton_Click(object sender, EventArgs e)
		{
			this.osuBuddy.replayPlayerEnabled = !this.osuBuddy.replayPlayerEnabled;
			bool flag = !this.osuBuddy.replayPlayerEnabled;
			if (flag)
			{
				this.osuBuddy.getReplayPlayer().Stop();
				this.replayPlayerToggleButton.BackColor = Color.Red;
				this.replayPlayerToggleButton.Text = "Disabled";
			}
			else
			{
				this.replayPlayerToggleButton.BackColor = Color.Green;
				this.replayPlayerToggleButton.Text = "Enabled";
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00012BD0 File Offset: 0x00010DD0
		private void aimSpeedTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getAimAssist().setAimSpeed(this.aimSpeedTrackBar.Value);
			this.aimSpeedOutput.Text = this.osuBuddy.getAimAssist().getAimSpeed().ToString();
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00012C20 File Offset: 0x00010E20
		private void aimStartDistanceTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getAimAssist().setAimStartingDistance(this.aimStartDistanceTrackBar.Value);
			bool flag = this.osuBuddy.getAimAssist().getAimStartingDistance() >= 1000;
			if (flag)
			{
				this.aimStartDistanceOutput.Text = "1000+";
			}
			else
			{
				this.aimStartDistanceOutput.Text = this.osuBuddy.getAimAssist().getAimStartingDistance().ToString();
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00012CA0 File Offset: 0x00010EA0
		private void aimStopDistanceTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getAimAssist().setAimStoppingDistance(this.aimStopDistanceTrackBar.Value);
			this.aimStopDistanceOutput.Text = this.osuBuddy.getAimAssist().getAimStoppingDistance().ToString();
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00012CF0 File Offset: 0x00010EF0
		private void offsetTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getRelax().setOffset(this.offsetTrackBar.Value);
			this.offsetOutput.Text = this.osuBuddy.getRelax().getOffset().ToString();
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00012D40 File Offset: 0x00010F40
		private void holdTimeTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getRelax().setHoldTime(this.holdTimeTrackBar.Value);
			this.holdTimeOutput.Text = this.osuBuddy.getRelax().getHoldTime().ToString();
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00012D90 File Offset: 0x00010F90
		private void alternateTimeTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getRelax().setAlternateTime(this.alternateTimeTrackBar.Value);
			bool flag = this.osuBuddy.getRelax().getAlternateTime() >= 1000;
			if (flag)
			{
				this.alternateTimeOutput.Text = "1000+";
			}
			else
			{
				this.alternateTimeOutput.Text = this.osuBuddy.getRelax().getAlternateTime().ToString();
			}
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00012E10 File Offset: 0x00011010
		private void percentToHitOutsideOffsetTrackbar_Scroll(object sender, EventArgs e)
		{
			this.osuBuddy.getRelax().setPercentToHitOutsideOffset(this.percentToHitOutsideOffsetTrackBar.Value);
			this.percentToHitOutsideOffsetOutput.Text = this.osuBuddy.getRelax().getPercentToHitOutsideOffset().ToString();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00004515 File Offset: 0x00002715
		private void flipReplayCheckBox_Click(object sender, EventArgs e)
		{
			this.osuBuddy.getReplayPlayer().setReplayFrames(this.osuBuddy.getReplayPlayer().flipReplay());
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00004539 File Offset: 0x00002739
		private void interpolateReplayCheckBox_Click(object sender, EventArgs e)
		{
			this.osuBuddy.getReplayPlayer().setShouldInterpolateReplay(this.interpolateReplayCheckBox.Checked);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00012E60 File Offset: 0x00011060
		private void selectReplayButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string replayPath = null;
			Console.WriteLine("Select an osu! Replay...");
			openFileDialog.Title = "Select an osu! Replay";
			openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = "osu! Replay files (*.osr*)|*.osr*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				replayPath = openFileDialog.FileName;
			}
			this.osuBuddy.getReplayPlayer().selectReplay(replayPath);
			this.currentReplayTextBox.Text = this.osuBuddy.getReplayPlayer().getReplayPath();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00012EFC File Offset: 0x000110FC
		private void playMouseButton_Click(object sender, EventArgs e)
		{
			this.osuBuddy.getReplayPlayer().setPlayMouse(!this.osuBuddy.getReplayPlayer().getPlayMouse());
			bool flag = !this.osuBuddy.getReplayPlayer().getPlayMouse();
			if (flag)
			{
				this.playMouseButton.BackColor = Color.Red;
			}
			else
			{
				this.playMouseButton.BackColor = Color.Green;
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00012F6C File Offset: 0x0001116C
		private void playKeyboardButton_Click(object sender, EventArgs e)
		{
			this.osuBuddy.getReplayPlayer().setPlayKeyboard(!this.osuBuddy.getReplayPlayer().getPlayKeyboard());
			bool flag = !this.osuBuddy.getReplayPlayer().getPlayKeyboard();
			if (flag)
			{
				this.playKeyboardButton.BackColor = Color.Red;
			}
			else
			{
				this.playKeyboardButton.BackColor = Color.Green;
			}
		}

		// Token: 0x040003F5 RID: 1013
		public OsuBuddy osuBuddy;

		// Token: 0x020000AB RID: 171
		[CompilerGenerated]
		private sealed class Ac__DisplayClass4_0
		{
			// Token: 0x06000469 RID: 1129 RVA: 0x00004558 File Offset: 0x00002758
			internal void AsetStatusb__0()
			{
				this.A4__this.statusLabel.Text = this.status;
			}

			// Token: 0x04000431 RID: 1073
			public GUI A4__this;

			// Token: 0x04000432 RID: 1074
			public string status;
		}
	}
}
