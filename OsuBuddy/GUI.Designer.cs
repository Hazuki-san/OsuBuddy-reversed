using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace OsuBuddy
{
	// Token: 0x020000AA RID: 170
	public partial class GUI : Form
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00012FDC File Offset: 0x000111DC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00013014 File Offset: 0x00011214
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.tabsPanel = new System.Windows.Forms.Panel();
            this.selectedPanel = new System.Windows.Forms.Panel();
            this.replayPlayerButton = new System.Windows.Forms.Button();
            this.relaxButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.osuBuddyLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.separator = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.loginTextLabel = new System.Windows.Forms.Label();
            this.userSignUpButton = new System.Windows.Forms.Button();
            this.userLoginButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.aimAssistTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.aimAssistToggleButton = new System.Windows.Forms.Button();
            this.aimStopDistanceOutput = new System.Windows.Forms.TextBox();
            this.aimStartDistanceOutput = new System.Windows.Forms.TextBox();
            this.aimSpeedOutput = new System.Windows.Forms.TextBox();
            this.aimStopDistanceTrackBar = new System.Windows.Forms.TrackBar();
            this.aimStartDistanceTrackBar = new System.Windows.Forms.TrackBar();
            this.aimSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.relaxTab = new System.Windows.Forms.TabPage();
            this.percentToHitOutsideOffsetOutput = new System.Windows.Forms.TextBox();
            this.percentToHitOutsideOffsetTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.alternateTimeOutput = new System.Windows.Forms.TextBox();
            this.holdTimeOutput = new System.Windows.Forms.TextBox();
            this.offsetOutput = new System.Windows.Forms.TextBox();
            this.alternateTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.holdTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.offsetTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.relaxToggleButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.replayPlayerTab = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.playKeyboardButton = new System.Windows.Forms.Button();
            this.playMouseButton = new System.Windows.Forms.Button();
            this.flipReplayCheckBox = new System.Windows.Forms.CheckBox();
            this.interpolateReplayCheckBox = new System.Windows.Forms.CheckBox();
            this.selectReplayButton = new System.Windows.Forms.Button();
            this.currentReplayTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.replayPlayerToggleButton = new System.Windows.Forms.Button();
            this.aimAssistButton = new System.Windows.Forms.Button();
            this.tabsPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.aimAssistTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aimStopDistanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aimStartDistanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aimSpeedTrackBar)).BeginInit();
            this.relaxTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentToHitOutsideOffsetTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternateTimeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTimeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).BeginInit();
            this.replayPlayerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPanel
            // 
            this.tabsPanel.Controls.Add(this.selectedPanel);
            this.tabsPanel.Controls.Add(this.replayPlayerButton);
            this.tabsPanel.Controls.Add(this.relaxButton);
            this.tabsPanel.Controls.Add(this.aimAssistButton);
            this.tabsPanel.Controls.Add(this.loginButton);
            this.tabsPanel.Controls.Add(this.osuBuddyLabel);
            this.tabsPanel.Controls.Add(this.logoPanel);
            this.tabsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabsPanel.Location = new System.Drawing.Point(0, 0);
            this.tabsPanel.Name = "tabsPanel";
            this.tabsPanel.Size = new System.Drawing.Size(150, 450);
            this.tabsPanel.TabIndex = 0;
            // 
            // selectedPanel
            // 
            this.selectedPanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.selectedPanel.Location = new System.Drawing.Point(145, 100);
            this.selectedPanel.Name = "selectedPanel";
            this.selectedPanel.Size = new System.Drawing.Size(5, 75);
            this.selectedPanel.TabIndex = 0;
            // 
            // replayPlayerButton
            // 
            this.replayPlayerButton.Enabled = false;
            this.replayPlayerButton.FlatAppearance.BorderSize = 0;
            this.replayPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replayPlayerButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayPlayerButton.ForeColor = System.Drawing.Color.Teal;
            this.replayPlayerButton.Image = global::OsuBuddy.Properties.Resources.replayPlayerButton;
            this.replayPlayerButton.Location = new System.Drawing.Point(0, 325);
            this.replayPlayerButton.Name = "replayPlayerButton";
            this.replayPlayerButton.Size = new System.Drawing.Size(150, 75);
            this.replayPlayerButton.TabIndex = 4;
            this.replayPlayerButton.Text = "Replay Player";
            this.replayPlayerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.replayPlayerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.replayPlayerButton.UseVisualStyleBackColor = true;
            this.replayPlayerButton.Click += new System.EventHandler(this.replayPlayerButton_Click);
            // 
            // relaxButton
            // 
            this.relaxButton.Enabled = false;
            this.relaxButton.FlatAppearance.BorderSize = 0;
            this.relaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.relaxButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relaxButton.ForeColor = System.Drawing.Color.Teal;
            this.relaxButton.Image = global::OsuBuddy.Properties.Resources.relaxButton;
            this.relaxButton.Location = new System.Drawing.Point(0, 250);
            this.relaxButton.Name = "relaxButton";
            this.relaxButton.Size = new System.Drawing.Size(150, 75);
            this.relaxButton.TabIndex = 3;
            this.relaxButton.Text = "Relax";
            this.relaxButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.relaxButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.relaxButton.UseVisualStyleBackColor = true;
            this.relaxButton.Click += new System.EventHandler(this.relaxButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Teal;
            this.loginButton.Image = global::OsuBuddy.Properties.Resources.loginButton;
            this.loginButton.Location = new System.Drawing.Point(0, 100);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(150, 75);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // osuBuddyLabel
            // 
            this.osuBuddyLabel.AutoSize = true;
            this.osuBuddyLabel.BackColor = System.Drawing.Color.Transparent;
            this.osuBuddyLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osuBuddyLabel.ForeColor = System.Drawing.Color.Teal;
            this.osuBuddyLabel.Location = new System.Drawing.Point(9, 68);
            this.osuBuddyLabel.Name = "osuBuddyLabel";
            this.osuBuddyLabel.Size = new System.Drawing.Size(135, 32);
            this.osuBuddyLabel.TabIndex = 0;
            this.osuBuddyLabel.Text = "OsuBuddy";
            this.osuBuddyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = global::OsuBuddy.Properties.Resources.logoPanel;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(150, 65);
            this.logoPanel.TabIndex = 0;
            this.logoPanel.Click += new System.EventHandler(this.logo_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.separator);
            this.contentPanel.Controls.Add(this.statusLabel);
            this.contentPanel.Controls.Add(this.tabControl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(150, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(650, 450);
            this.contentPanel.TabIndex = 1;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.separator.Location = new System.Drawing.Point(0, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(4, 450);
            this.separator.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Teal;
            this.statusLabel.Location = new System.Drawing.Point(11, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(189, 19);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Welcome to OsuBuddy!";
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.loginTab);
            this.tabControl.Controls.Add(this.aimAssistTab);
            this.tabControl.Controls.Add(this.relaxTab);
            this.tabControl.Controls.Add(this.replayPlayerTab);
            this.tabControl.ItemSize = new System.Drawing.Size(1, 0);
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(655, 435);
            this.tabControl.TabIndex = 0;
            // 
            // loginTab
            // 
            this.loginTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.loginTab.Controls.Add(this.loginTextLabel);
            this.loginTab.Controls.Add(this.userSignUpButton);
            this.loginTab.Controls.Add(this.userLoginButton);
            this.loginTab.Controls.Add(this.passwordTextBox);
            this.loginTab.Controls.Add(this.usernameTextBox);
            this.loginTab.Controls.Add(this.label10);
            this.loginTab.Controls.Add(this.label9);
            this.loginTab.Controls.Add(this.button2);
            this.loginTab.Location = new System.Drawing.Point(4, 4);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(3);
            this.loginTab.Size = new System.Drawing.Size(647, 409);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Login";
            // 
            // loginTextLabel
            // 
            this.loginTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginTextLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTextLabel.ForeColor = System.Drawing.Color.Teal;
            this.loginTextLabel.Location = new System.Drawing.Point(3, 56);
            this.loginTextLabel.Name = "loginTextLabel";
            this.loginTextLabel.Size = new System.Drawing.Size(635, 75);
            this.loginTextLabel.TabIndex = 22;
            this.loginTextLabel.Text = "Please log in";
            this.loginTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userSignUpButton
            // 
            this.userSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userSignUpButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSignUpButton.ForeColor = System.Drawing.Color.Teal;
            this.userSignUpButton.Location = new System.Drawing.Point(11, 287);
            this.userSignUpButton.Name = "userSignUpButton";
            this.userSignUpButton.Size = new System.Drawing.Size(623, 46);
            this.userSignUpButton.TabIndex = 21;
            this.userSignUpButton.Text = "Sign Up";
            this.userSignUpButton.UseVisualStyleBackColor = true;
            this.userSignUpButton.Click += new System.EventHandler(this.logo_Click);
            // 
            // userLoginButton
            // 
            this.userLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userLoginButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLoginButton.ForeColor = System.Drawing.Color.Teal;
            this.userLoginButton.Location = new System.Drawing.Point(11, 235);
            this.userLoginButton.Name = "userLoginButton";
            this.userLoginButton.Size = new System.Drawing.Size(623, 46);
            this.userLoginButton.TabIndex = 19;
            this.userLoginButton.Text = "Login";
            this.userLoginButton.UseVisualStyleBackColor = true;
            this.userLoginButton.Click += new System.EventHandler(this.login);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Teal;
            this.passwordTextBox.Location = new System.Drawing.Point(103, 184);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(531, 26);
            this.passwordTextBox.TabIndex = 18;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyPress);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.Teal;
            this.usernameTextBox.Location = new System.Drawing.Point(103, 148);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(531, 26);
            this.usernameTextBox.TabIndex = 17;
            this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(7, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.Location = new System.Drawing.Point(7, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Username:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Image = global::OsuBuddy.Properties.Resources.button2;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 50);
            this.button2.TabIndex = 14;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // aimAssistTab
            // 
            this.aimAssistTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.aimAssistTab.Controls.Add(this.button1);
            this.aimAssistTab.Controls.Add(this.aimAssistToggleButton);
            this.aimAssistTab.Controls.Add(this.aimStopDistanceOutput);
            this.aimAssistTab.Controls.Add(this.aimStartDistanceOutput);
            this.aimAssistTab.Controls.Add(this.aimSpeedOutput);
            this.aimAssistTab.Controls.Add(this.aimStopDistanceTrackBar);
            this.aimAssistTab.Controls.Add(this.aimStartDistanceTrackBar);
            this.aimAssistTab.Controls.Add(this.aimSpeedTrackBar);
            this.aimAssistTab.Controls.Add(this.label7);
            this.aimAssistTab.Controls.Add(this.label6);
            this.aimAssistTab.Controls.Add(this.label5);
            this.aimAssistTab.Location = new System.Drawing.Point(4, 4);
            this.aimAssistTab.Name = "aimAssistTab";
            this.aimAssistTab.Padding = new System.Windows.Forms.Padding(3);
            this.aimAssistTab.Size = new System.Drawing.Size(647, 409);
            this.aimAssistTab.TabIndex = 1;
            this.aimAssistTab.Text = "Aim Assist";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Image = global::OsuBuddy.Properties.Resources.button1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "Aim Assist";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // aimAssistToggleButton
            // 
            this.aimAssistToggleButton.BackColor = System.Drawing.Color.Red;
            this.aimAssistToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aimAssistToggleButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aimAssistToggleButton.Location = new System.Drawing.Point(19, 56);
            this.aimAssistToggleButton.Name = "aimAssistToggleButton";
            this.aimAssistToggleButton.Size = new System.Drawing.Size(141, 28);
            this.aimAssistToggleButton.TabIndex = 12;
            this.aimAssistToggleButton.Text = "Disabled";
            this.aimAssistToggleButton.UseVisualStyleBackColor = false;
            this.aimAssistToggleButton.Click += new System.EventHandler(this.aimAssistToggleButton_Click);
            // 
            // aimStopDistanceOutput
            // 
            this.aimStopDistanceOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.aimStopDistanceOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aimStopDistanceOutput.ForeColor = System.Drawing.Color.Teal;
            this.aimStopDistanceOutput.Location = new System.Drawing.Point(375, 322);
            this.aimStopDistanceOutput.Name = "aimStopDistanceOutput";
            this.aimStopDistanceOutput.Size = new System.Drawing.Size(100, 36);
            this.aimStopDistanceOutput.TabIndex = 11;
            // 
            // aimStartDistanceOutput
            // 
            this.aimStartDistanceOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.aimStartDistanceOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aimStartDistanceOutput.ForeColor = System.Drawing.Color.Teal;
            this.aimStartDistanceOutput.Location = new System.Drawing.Point(375, 222);
            this.aimStartDistanceOutput.Name = "aimStartDistanceOutput";
            this.aimStartDistanceOutput.Size = new System.Drawing.Size(100, 36);
            this.aimStartDistanceOutput.TabIndex = 10;
            // 
            // aimSpeedOutput
            // 
            this.aimSpeedOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.aimSpeedOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aimSpeedOutput.ForeColor = System.Drawing.Color.Teal;
            this.aimSpeedOutput.Location = new System.Drawing.Point(375, 122);
            this.aimSpeedOutput.Name = "aimSpeedOutput";
            this.aimSpeedOutput.Size = new System.Drawing.Size(100, 36);
            this.aimSpeedOutput.TabIndex = 9;
            // 
            // aimStopDistanceTrackBar
            // 
            this.aimStopDistanceTrackBar.LargeChange = 10;
            this.aimStopDistanceTrackBar.Location = new System.Drawing.Point(19, 322);
            this.aimStopDistanceTrackBar.Maximum = 100;
            this.aimStopDistanceTrackBar.Name = "aimStopDistanceTrackBar";
            this.aimStopDistanceTrackBar.Size = new System.Drawing.Size(350, 45);
            this.aimStopDistanceTrackBar.TabIndex = 8;
            this.aimStopDistanceTrackBar.TickFrequency = 10;
            this.aimStopDistanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aimStopDistanceTrackBar.Scroll += new System.EventHandler(this.aimStopDistanceTrackbar_Scroll);
            // 
            // aimStartDistanceTrackBar
            // 
            this.aimStartDistanceTrackBar.LargeChange = 100;
            this.aimStartDistanceTrackBar.Location = new System.Drawing.Point(19, 222);
            this.aimStartDistanceTrackBar.Maximum = 1000;
            this.aimStartDistanceTrackBar.Name = "aimStartDistanceTrackBar";
            this.aimStartDistanceTrackBar.Size = new System.Drawing.Size(350, 45);
            this.aimStartDistanceTrackBar.TabIndex = 7;
            this.aimStartDistanceTrackBar.TickFrequency = 100;
            this.aimStartDistanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aimStartDistanceTrackBar.Scroll += new System.EventHandler(this.aimStartDistanceTrackbar_Scroll);
            // 
            // aimSpeedTrackBar
            // 
            this.aimSpeedTrackBar.LargeChange = 1;
            this.aimSpeedTrackBar.Location = new System.Drawing.Point(19, 122);
            this.aimSpeedTrackBar.Maximum = 20;
            this.aimSpeedTrackBar.Name = "aimSpeedTrackBar";
            this.aimSpeedTrackBar.Size = new System.Drawing.Size(350, 45);
            this.aimSpeedTrackBar.TabIndex = 6;
            this.aimSpeedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aimSpeedTrackBar.Scroll += new System.EventHandler(this.aimSpeedTrackbar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(15, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Aim Stop Distance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(15, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Aim Start Distance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(15, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Aim Speed";
            // 
            // relaxTab
            // 
            this.relaxTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.relaxTab.Controls.Add(this.percentToHitOutsideOffsetOutput);
            this.relaxTab.Controls.Add(this.percentToHitOutsideOffsetTrackBar);
            this.relaxTab.Controls.Add(this.label4);
            this.relaxTab.Controls.Add(this.alternateTimeOutput);
            this.relaxTab.Controls.Add(this.holdTimeOutput);
            this.relaxTab.Controls.Add(this.offsetOutput);
            this.relaxTab.Controls.Add(this.alternateTimeTrackBar);
            this.relaxTab.Controls.Add(this.holdTimeTrackBar);
            this.relaxTab.Controls.Add(this.offsetTrackBar);
            this.relaxTab.Controls.Add(this.label3);
            this.relaxTab.Controls.Add(this.label2);
            this.relaxTab.Controls.Add(this.label1);
            this.relaxTab.Controls.Add(this.relaxToggleButton);
            this.relaxTab.Controls.Add(this.button3);
            this.relaxTab.Location = new System.Drawing.Point(4, 4);
            this.relaxTab.Name = "relaxTab";
            this.relaxTab.Padding = new System.Windows.Forms.Padding(3);
            this.relaxTab.Size = new System.Drawing.Size(647, 409);
            this.relaxTab.TabIndex = 2;
            this.relaxTab.Text = "Relax";
            // 
            // percentToHitOutsideOffsetOutput
            // 
            this.percentToHitOutsideOffsetOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.percentToHitOutsideOffsetOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentToHitOutsideOffsetOutput.ForeColor = System.Drawing.Color.Teal;
            this.percentToHitOutsideOffsetOutput.Location = new System.Drawing.Point(375, 332);
            this.percentToHitOutsideOffsetOutput.Name = "percentToHitOutsideOffsetOutput";
            this.percentToHitOutsideOffsetOutput.Size = new System.Drawing.Size(100, 36);
            this.percentToHitOutsideOffsetOutput.TabIndex = 27;
            // 
            // percentToHitOutsideOffsetTrackBar
            // 
            this.percentToHitOutsideOffsetTrackBar.Location = new System.Drawing.Point(19, 332);
            this.percentToHitOutsideOffsetTrackBar.Maximum = 100;
            this.percentToHitOutsideOffsetTrackBar.Name = "percentToHitOutsideOffsetTrackBar";
            this.percentToHitOutsideOffsetTrackBar.Size = new System.Drawing.Size(350, 45);
            this.percentToHitOutsideOffsetTrackBar.TabIndex = 26;
            this.percentToHitOutsideOffsetTrackBar.TickFrequency = 5;
            this.percentToHitOutsideOffsetTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.percentToHitOutsideOffsetTrackBar.Scroll += new System.EventHandler(this.percentToHitOutsideOffsetTrackbar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(15, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Percent to hit outside Offset";
            // 
            // alternateTimeOutput
            // 
            this.alternateTimeOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.alternateTimeOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternateTimeOutput.ForeColor = System.Drawing.Color.Teal;
            this.alternateTimeOutput.Location = new System.Drawing.Point(375, 262);
            this.alternateTimeOutput.Name = "alternateTimeOutput";
            this.alternateTimeOutput.Size = new System.Drawing.Size(100, 36);
            this.alternateTimeOutput.TabIndex = 24;
            // 
            // holdTimeOutput
            // 
            this.holdTimeOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.holdTimeOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holdTimeOutput.ForeColor = System.Drawing.Color.Teal;
            this.holdTimeOutput.Location = new System.Drawing.Point(375, 192);
            this.holdTimeOutput.Name = "holdTimeOutput";
            this.holdTimeOutput.Size = new System.Drawing.Size(100, 36);
            this.holdTimeOutput.TabIndex = 23;
            // 
            // offsetOutput
            // 
            this.offsetOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.offsetOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetOutput.ForeColor = System.Drawing.Color.Teal;
            this.offsetOutput.Location = new System.Drawing.Point(375, 122);
            this.offsetOutput.Name = "offsetOutput";
            this.offsetOutput.Size = new System.Drawing.Size(100, 36);
            this.offsetOutput.TabIndex = 22;
            // 
            // alternateTimeTrackBar
            // 
            this.alternateTimeTrackBar.LargeChange = 100;
            this.alternateTimeTrackBar.Location = new System.Drawing.Point(19, 262);
            this.alternateTimeTrackBar.Maximum = 1000;
            this.alternateTimeTrackBar.Name = "alternateTimeTrackBar";
            this.alternateTimeTrackBar.Size = new System.Drawing.Size(350, 45);
            this.alternateTimeTrackBar.TabIndex = 21;
            this.alternateTimeTrackBar.TickFrequency = 100;
            this.alternateTimeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.alternateTimeTrackBar.Scroll += new System.EventHandler(this.alternateTimeTrackbar_Scroll);
            // 
            // holdTimeTrackBar
            // 
            this.holdTimeTrackBar.Location = new System.Drawing.Point(19, 192);
            this.holdTimeTrackBar.Maximum = 100;
            this.holdTimeTrackBar.Minimum = 30;
            this.holdTimeTrackBar.Name = "holdTimeTrackBar";
            this.holdTimeTrackBar.Size = new System.Drawing.Size(350, 45);
            this.holdTimeTrackBar.TabIndex = 20;
            this.holdTimeTrackBar.TickFrequency = 5;
            this.holdTimeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.holdTimeTrackBar.Value = 30;
            this.holdTimeTrackBar.Scroll += new System.EventHandler(this.holdTimeTrackbar_Scroll);
            // 
            // offsetTrackBar
            // 
            this.offsetTrackBar.Location = new System.Drawing.Point(19, 122);
            this.offsetTrackBar.Maximum = 50;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(350, 45);
            this.offsetTrackBar.TabIndex = 19;
            this.offsetTrackBar.TickFrequency = 5;
            this.offsetTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.offsetTrackBar.Scroll += new System.EventHandler(this.offsetTrackbar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(15, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Alternate Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(15, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hold Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Offset";
            // 
            // relaxToggleButton
            // 
            this.relaxToggleButton.BackColor = System.Drawing.Color.Red;
            this.relaxToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.relaxToggleButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relaxToggleButton.Location = new System.Drawing.Point(19, 56);
            this.relaxToggleButton.Name = "relaxToggleButton";
            this.relaxToggleButton.Size = new System.Drawing.Size(141, 28);
            this.relaxToggleButton.TabIndex = 15;
            this.relaxToggleButton.Text = "Disabled";
            this.relaxToggleButton.UseVisualStyleBackColor = false;
            this.relaxToggleButton.Click += new System.EventHandler(this.relaxToggleButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Image = global::OsuBuddy.Properties.Resources.button3;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 50);
            this.button3.TabIndex = 14;
            this.button3.Text = "Relax";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // replayPlayerTab
            // 
            this.replayPlayerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.replayPlayerTab.Controls.Add(this.button4);
            this.replayPlayerTab.Controls.Add(this.playKeyboardButton);
            this.replayPlayerTab.Controls.Add(this.playMouseButton);
            this.replayPlayerTab.Controls.Add(this.flipReplayCheckBox);
            this.replayPlayerTab.Controls.Add(this.interpolateReplayCheckBox);
            this.replayPlayerTab.Controls.Add(this.selectReplayButton);
            this.replayPlayerTab.Controls.Add(this.currentReplayTextBox);
            this.replayPlayerTab.Controls.Add(this.label8);
            this.replayPlayerTab.Controls.Add(this.replayPlayerToggleButton);
            this.replayPlayerTab.Location = new System.Drawing.Point(4, 4);
            this.replayPlayerTab.Name = "replayPlayerTab";
            this.replayPlayerTab.Padding = new System.Windows.Forms.Padding(3);
            this.replayPlayerTab.Size = new System.Drawing.Size(647, 409);
            this.replayPlayerTab.TabIndex = 3;
            this.replayPlayerTab.Text = "Replay Player";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Teal;
            this.button4.Image = global::OsuBuddy.Properties.Resources.button4;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(363, 50);
            this.button4.TabIndex = 21;
            this.button4.Text = "Replay Player";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // playKeyboardButton
            // 
            this.playKeyboardButton.BackColor = System.Drawing.Color.Green;
            this.playKeyboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playKeyboardButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playKeyboardButton.Location = new System.Drawing.Point(180, 206);
            this.playKeyboardButton.Name = "playKeyboardButton";
            this.playKeyboardButton.Size = new System.Drawing.Size(271, 28);
            this.playKeyboardButton.TabIndex = 20;
            this.playKeyboardButton.Text = "Play Replay\'s Keyboard Input";
            this.playKeyboardButton.UseVisualStyleBackColor = false;
            this.playKeyboardButton.Click += new System.EventHandler(this.playKeyboardButton_Click);
            // 
            // playMouseButton
            // 
            this.playMouseButton.BackColor = System.Drawing.Color.Green;
            this.playMouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playMouseButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playMouseButton.Location = new System.Drawing.Point(180, 172);
            this.playMouseButton.Name = "playMouseButton";
            this.playMouseButton.Size = new System.Drawing.Size(271, 28);
            this.playMouseButton.TabIndex = 19;
            this.playMouseButton.Text = "Play Replay\'s Mouse Input";
            this.playMouseButton.UseVisualStyleBackColor = false;
            this.playMouseButton.Click += new System.EventHandler(this.playMouseButton_Click);
            // 
            // flipReplayCheckBox
            // 
            this.flipReplayCheckBox.AutoSize = true;
            this.flipReplayCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flipReplayCheckBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipReplayCheckBox.ForeColor = System.Drawing.Color.Teal;
            this.flipReplayCheckBox.Location = new System.Drawing.Point(457, 302);
            this.flipReplayCheckBox.Name = "flipReplayCheckBox";
            this.flipReplayCheckBox.Size = new System.Drawing.Size(124, 23);
            this.flipReplayCheckBox.TabIndex = 18;
            this.flipReplayCheckBox.Text = "Flip Replay";
            this.flipReplayCheckBox.UseVisualStyleBackColor = true;
            this.flipReplayCheckBox.CheckedChanged += new System.EventHandler(this.flipReplayCheckBox_Click);
            // 
            // interpolateReplayCheckBox
            // 
            this.interpolateReplayCheckBox.AutoSize = true;
            this.interpolateReplayCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.interpolateReplayCheckBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interpolateReplayCheckBox.ForeColor = System.Drawing.Color.Teal;
            this.interpolateReplayCheckBox.Location = new System.Drawing.Point(457, 331);
            this.interpolateReplayCheckBox.Name = "interpolateReplayCheckBox";
            this.interpolateReplayCheckBox.Size = new System.Drawing.Size(187, 23);
            this.interpolateReplayCheckBox.TabIndex = 17;
            this.interpolateReplayCheckBox.Text = "Interpolate Replay";
            this.interpolateReplayCheckBox.UseVisualStyleBackColor = true;
            this.interpolateReplayCheckBox.CheckedChanged += new System.EventHandler(this.interpolateReplayCheckBox_Click);
            // 
            // selectReplayButton
            // 
            this.selectReplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectReplayButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectReplayButton.ForeColor = System.Drawing.Color.Teal;
            this.selectReplayButton.Location = new System.Drawing.Point(500, 363);
            this.selectReplayButton.Name = "selectReplayButton";
            this.selectReplayButton.Size = new System.Drawing.Size(144, 26);
            this.selectReplayButton.TabIndex = 16;
            this.selectReplayButton.Text = "Select Replay";
            this.selectReplayButton.UseVisualStyleBackColor = true;
            this.selectReplayButton.Click += new System.EventHandler(this.selectReplayButton_Click);
            // 
            // currentReplayTextBox
            // 
            this.currentReplayTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.currentReplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentReplayTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentReplayTextBox.ForeColor = System.Drawing.Color.Teal;
            this.currentReplayTextBox.Location = new System.Drawing.Point(160, 363);
            this.currentReplayTextBox.Name = "currentReplayTextBox";
            this.currentReplayTextBox.Size = new System.Drawing.Size(334, 26);
            this.currentReplayTextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(15, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Current Replay";
            // 
            // replayPlayerToggleButton
            // 
            this.replayPlayerToggleButton.BackColor = System.Drawing.Color.Red;
            this.replayPlayerToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replayPlayerToggleButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayPlayerToggleButton.Location = new System.Drawing.Point(19, 56);
            this.replayPlayerToggleButton.Name = "replayPlayerToggleButton";
            this.replayPlayerToggleButton.Size = new System.Drawing.Size(141, 28);
            this.replayPlayerToggleButton.TabIndex = 13;
            this.replayPlayerToggleButton.Text = "Disabled";
            this.replayPlayerToggleButton.UseVisualStyleBackColor = false;
            this.replayPlayerToggleButton.Click += new System.EventHandler(this.replayPlayerToggleButton_Click);
            // 
            // aimAssistButton
            // 
            this.aimAssistButton.Enabled = false;
            this.aimAssistButton.FlatAppearance.BorderSize = 0;
            this.aimAssistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aimAssistButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aimAssistButton.ForeColor = System.Drawing.Color.Teal;
            this.aimAssistButton.Image = global::OsuBuddy.Properties.Resources.aimAssistButton;
            this.aimAssistButton.Location = new System.Drawing.Point(0, 175);
            this.aimAssistButton.Name = "aimAssistButton";
            this.aimAssistButton.Size = new System.Drawing.Size(150, 75);
            this.aimAssistButton.TabIndex = 2;
            this.aimAssistButton.Text = "Aim Assist";
            this.aimAssistButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aimAssistButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aimAssistButton.UseVisualStyleBackColor = true;
            this.aimAssistButton.Click += new System.EventHandler(this.aimAssistButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.tabsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUI";
            this.Text = "OsuBuddy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_Closing);
            this.tabsPanel.ResumeLayout(false);
            this.tabsPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.aimAssistTab.ResumeLayout(false);
            this.aimAssistTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aimStopDistanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aimStartDistanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aimSpeedTrackBar)).EndInit();
            this.relaxTab.ResumeLayout(false);
            this.relaxTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentToHitOutsideOffsetTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alternateTimeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTimeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).EndInit();
            this.replayPlayerTab.ResumeLayout(false);
            this.replayPlayerTab.PerformLayout();
            this.ResumeLayout(false);

		}


		// Token: 0x040003F6 RID: 1014
		private IContainer components = null;

		// Token: 0x040003F7 RID: 1015
		private Panel tabsPanel;

		// Token: 0x040003F8 RID: 1016
		private Label osuBuddyLabel;

		// Token: 0x040003F9 RID: 1017
		private Button replayPlayerButton;

		// Token: 0x040003FA RID: 1018
		private Button relaxButton;

		// Token: 0x040003FB RID: 1019
		private Button aimAssistButton;

		// Token: 0x040003FC RID: 1020
		private Button loginButton;

		// Token: 0x040003FD RID: 1021
		private Panel logoPanel;

		// Token: 0x040003FE RID: 1022
		private Panel selectedPanel;

		// Token: 0x040003FF RID: 1023
		private Panel contentPanel;

		// Token: 0x04000400 RID: 1024
		private TabControl tabControl;

		// Token: 0x04000401 RID: 1025
		private TabPage loginTab;

		// Token: 0x04000402 RID: 1026
		private TabPage aimAssistTab;

		// Token: 0x04000403 RID: 1027
		private TabPage relaxTab;

		// Token: 0x04000404 RID: 1028
		private TabPage replayPlayerTab;

		// Token: 0x04000405 RID: 1029
		private TextBox aimStopDistanceOutput;

		// Token: 0x04000406 RID: 1030
		private TextBox aimStartDistanceOutput;

		// Token: 0x04000407 RID: 1031
		private TextBox aimSpeedOutput;

		// Token: 0x04000408 RID: 1032
		private TrackBar aimStopDistanceTrackBar;

		// Token: 0x04000409 RID: 1033
		private TrackBar aimStartDistanceTrackBar;

		// Token: 0x0400040A RID: 1034
		private TrackBar aimSpeedTrackBar;

		// Token: 0x0400040B RID: 1035
		private Label label7;

		// Token: 0x0400040C RID: 1036
		private Label label6;

		// Token: 0x0400040D RID: 1037
		private Label label5;

		// Token: 0x0400040E RID: 1038
		private Label statusLabel;

		// Token: 0x0400040F RID: 1039
		private Panel separator;

		// Token: 0x04000410 RID: 1040
		private Button aimAssistToggleButton;

		// Token: 0x04000411 RID: 1041
		private Button replayPlayerToggleButton;

		// Token: 0x04000412 RID: 1042
		private Button selectReplayButton;

		// Token: 0x04000413 RID: 1043
		private TextBox currentReplayTextBox;

		// Token: 0x04000414 RID: 1044
		private Label label8;

		// Token: 0x04000415 RID: 1045
		private CheckBox interpolateReplayCheckBox;

		// Token: 0x04000416 RID: 1046
		private CheckBox flipReplayCheckBox;

		// Token: 0x04000417 RID: 1047
		private Button playKeyboardButton;

		// Token: 0x04000418 RID: 1048
		private Button playMouseButton;

		// Token: 0x04000419 RID: 1049
		private Button button1;

		// Token: 0x0400041A RID: 1050
		private Button button2;

		// Token: 0x0400041B RID: 1051
		private Button button3;

		// Token: 0x0400041C RID: 1052
		private Button button4;

		// Token: 0x0400041D RID: 1053
		private Button relaxToggleButton;

		// Token: 0x0400041E RID: 1054
		private TextBox alternateTimeOutput;

		// Token: 0x0400041F RID: 1055
		private TextBox holdTimeOutput;

		// Token: 0x04000420 RID: 1056
		private TextBox offsetOutput;

		// Token: 0x04000421 RID: 1057
		private TrackBar alternateTimeTrackBar;

		// Token: 0x04000422 RID: 1058
		private TrackBar holdTimeTrackBar;

		// Token: 0x04000423 RID: 1059
		private TrackBar offsetTrackBar;

		// Token: 0x04000424 RID: 1060
		private Label label3;

		// Token: 0x04000425 RID: 1061
		private Label label2;

		// Token: 0x04000426 RID: 1062
		private Label label1;

		// Token: 0x04000427 RID: 1063
		private TrackBar percentToHitOutsideOffsetTrackBar;

		// Token: 0x04000428 RID: 1064
		private Label label4;

		// Token: 0x04000429 RID: 1065
		private TextBox percentToHitOutsideOffsetOutput;

		// Token: 0x0400042A RID: 1066
		private Label label9;

		// Token: 0x0400042B RID: 1067
		private TextBox usernameTextBox;

		// Token: 0x0400042C RID: 1068
		private Label label10;

		// Token: 0x0400042D RID: 1069
		private TextBox passwordTextBox;

		// Token: 0x0400042E RID: 1070
		private Button userSignUpButton;

		// Token: 0x0400042F RID: 1071
		private Button userLoginButton;

		// Token: 0x04000430 RID: 1072
		private Label loginTextLabel;
	}
}
