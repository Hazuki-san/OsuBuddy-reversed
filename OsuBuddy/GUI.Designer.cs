namespace OsuBuddy
{
	// Token: 0x020000AA RID: 170
	public partial class GUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00012FDC File Offset: 0x00012FDC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00013014 File Offset: 0x00013014
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OsuBuddy.GUI));
			this.tabsPanel = new global::System.Windows.Forms.Panel();
			this.selectedPanel = new global::System.Windows.Forms.Panel();
			this.replayPlayerButton = new global::System.Windows.Forms.Button();
			this.relaxButton = new global::System.Windows.Forms.Button();
			this.aimAssistButton = new global::System.Windows.Forms.Button();
			this.loginButton = new global::System.Windows.Forms.Button();
			this.osuBuddyLabel = new global::System.Windows.Forms.Label();
			this.logoPanel = new global::System.Windows.Forms.Panel();
			this.contentPanel = new global::System.Windows.Forms.Panel();
			this.separator = new global::System.Windows.Forms.Panel();
			this.statusLabel = new global::System.Windows.Forms.Label();
			this.tabControl = new global::System.Windows.Forms.TabControl();
			this.loginTab = new global::System.Windows.Forms.TabPage();
			this.loginTextLabel = new global::System.Windows.Forms.Label();
			this.userSignUpButton = new global::System.Windows.Forms.Button();
			this.userLoginButton = new global::System.Windows.Forms.Button();
			this.passwordTextBox = new global::System.Windows.Forms.TextBox();
			this.usernameTextBox = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.button2 = new global::System.Windows.Forms.Button();
			this.aimAssistTab = new global::System.Windows.Forms.TabPage();
			this.button1 = new global::System.Windows.Forms.Button();
			this.aimAssistToggleButton = new global::System.Windows.Forms.Button();
			this.aimStopDistanceOutput = new global::System.Windows.Forms.TextBox();
			this.aimStartDistanceOutput = new global::System.Windows.Forms.TextBox();
			this.aimSpeedOutput = new global::System.Windows.Forms.TextBox();
			this.aimStopDistanceTrackBar = new global::System.Windows.Forms.TrackBar();
			this.aimStartDistanceTrackBar = new global::System.Windows.Forms.TrackBar();
			this.aimSpeedTrackBar = new global::System.Windows.Forms.TrackBar();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.relaxTab = new global::System.Windows.Forms.TabPage();
			this.percentToHitOutsideOffsetOutput = new global::System.Windows.Forms.TextBox();
			this.percentToHitOutsideOffsetTrackBar = new global::System.Windows.Forms.TrackBar();
			this.label4 = new global::System.Windows.Forms.Label();
			this.alternateTimeOutput = new global::System.Windows.Forms.TextBox();
			this.holdTimeOutput = new global::System.Windows.Forms.TextBox();
			this.offsetOutput = new global::System.Windows.Forms.TextBox();
			this.alternateTimeTrackBar = new global::System.Windows.Forms.TrackBar();
			this.holdTimeTrackBar = new global::System.Windows.Forms.TrackBar();
			this.offsetTrackBar = new global::System.Windows.Forms.TrackBar();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.relaxToggleButton = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.replayPlayerTab = new global::System.Windows.Forms.TabPage();
			this.button4 = new global::System.Windows.Forms.Button();
			this.playKeyboardButton = new global::System.Windows.Forms.Button();
			this.playMouseButton = new global::System.Windows.Forms.Button();
			this.flipReplayCheckBox = new global::System.Windows.Forms.CheckBox();
			this.interpolateReplayCheckBox = new global::System.Windows.Forms.CheckBox();
			this.selectReplayButton = new global::System.Windows.Forms.Button();
			this.currentReplayTextBox = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.replayPlayerToggleButton = new global::System.Windows.Forms.Button();
			this.tabsPanel.SuspendLayout();
			this.contentPanel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.loginTab.SuspendLayout();
			this.aimAssistTab.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.aimStopDistanceTrackBar).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.aimStartDistanceTrackBar).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.aimSpeedTrackBar).BeginInit();
			this.relaxTab.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.percentToHitOutsideOffsetTrackBar).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.alternateTimeTrackBar).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.holdTimeTrackBar).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.offsetTrackBar).BeginInit();
			this.replayPlayerTab.SuspendLayout();
			base.SuspendLayout();
			this.tabsPanel.Controls.Add(this.selectedPanel);
			this.tabsPanel.Controls.Add(this.replayPlayerButton);
			this.tabsPanel.Controls.Add(this.relaxButton);
			this.tabsPanel.Controls.Add(this.aimAssistButton);
			this.tabsPanel.Controls.Add(this.loginButton);
			this.tabsPanel.Controls.Add(this.osuBuddyLabel);
			this.tabsPanel.Controls.Add(this.logoPanel);
			this.tabsPanel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tabsPanel.Location = new global::System.Drawing.Point(0, 0);
			this.tabsPanel.Name = "tabsPanel";
			this.tabsPanel.Size = new global::System.Drawing.Size(150, 450);
			this.tabsPanel.TabIndex = 0;
			this.selectedPanel.BackColor = global::System.Drawing.Color.LightSeaGreen;
			this.selectedPanel.Location = new global::System.Drawing.Point(145, 100);
			this.selectedPanel.Name = "selectedPanel";
			this.selectedPanel.Size = new global::System.Drawing.Size(5, 75);
			this.selectedPanel.TabIndex = 0;
			this.replayPlayerButton.Enabled = false;
			this.replayPlayerButton.FlatAppearance.BorderSize = 0;
			this.replayPlayerButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.replayPlayerButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.replayPlayerButton.ForeColor = global::System.Drawing.Color.Teal;
			this.replayPlayerButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("replayPlayerButton.Image");
			this.replayPlayerButton.Location = new global::System.Drawing.Point(0, 325);
			this.replayPlayerButton.Name = "replayPlayerButton";
			this.replayPlayerButton.Size = new global::System.Drawing.Size(150, 75);
			this.replayPlayerButton.TabIndex = 4;
			this.replayPlayerButton.Text = "Replay Player";
			this.replayPlayerButton.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.replayPlayerButton.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.replayPlayerButton.UseVisualStyleBackColor = true;
			this.replayPlayerButton.Click += new global::System.EventHandler(this.replayPlayerButton_Click);
			this.relaxButton.Enabled = false;
			this.relaxButton.FlatAppearance.BorderSize = 0;
			this.relaxButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.relaxButton.Font = new global::System.Drawing.Font("Consolas", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.relaxButton.ForeColor = global::System.Drawing.Color.Teal;
			this.relaxButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("relaxButton.Image");
			this.relaxButton.Location = new global::System.Drawing.Point(0, 250);
			this.relaxButton.Name = "relaxButton";
			this.relaxButton.Size = new global::System.Drawing.Size(150, 75);
			this.relaxButton.TabIndex = 3;
			this.relaxButton.Text = "Relax";
			this.relaxButton.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.relaxButton.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.relaxButton.UseVisualStyleBackColor = true;
			this.relaxButton.Click += new global::System.EventHandler(this.relaxButton_Click);
			this.aimAssistButton.Enabled = false;
			this.aimAssistButton.FlatAppearance.BorderSize = 0;
			this.aimAssistButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.aimAssistButton.Font = new global::System.Drawing.Font("Consolas", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.aimAssistButton.ForeColor = global::System.Drawing.Color.Teal;
			this.aimAssistButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("aimAssistButton.Image");
			this.aimAssistButton.Location = new global::System.Drawing.Point(0, 175);
			this.aimAssistButton.Name = "aimAssistButton";
			this.aimAssistButton.Size = new global::System.Drawing.Size(150, 75);
			this.aimAssistButton.TabIndex = 2;
			this.aimAssistButton.Text = "Aim Assist";
			this.aimAssistButton.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.aimAssistButton.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.aimAssistButton.UseVisualStyleBackColor = true;
			this.aimAssistButton.Click += new global::System.EventHandler(this.aimAssistButton_Click);
			this.loginButton.FlatAppearance.BorderSize = 0;
			this.loginButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.loginButton.Font = new global::System.Drawing.Font("Consolas", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.loginButton.ForeColor = global::System.Drawing.Color.Teal;
			this.loginButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("loginButton.Image");
			this.loginButton.Location = new global::System.Drawing.Point(0, 100);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new global::System.Drawing.Size(150, 75);
			this.loginButton.TabIndex = 1;
			this.loginButton.Text = "Login";
			this.loginButton.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.loginButton.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new global::System.EventHandler(this.loginButton_Click);
			this.osuBuddyLabel.AutoSize = true;
			this.osuBuddyLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.osuBuddyLabel.Font = new global::System.Drawing.Font("Consolas", 20.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.osuBuddyLabel.ForeColor = global::System.Drawing.Color.Teal;
			this.osuBuddyLabel.Location = new global::System.Drawing.Point(9, 68);
			this.osuBuddyLabel.Name = "osuBuddyLabel";
			this.osuBuddyLabel.Size = new global::System.Drawing.Size(135, 32);
			this.osuBuddyLabel.TabIndex = 0;
			this.osuBuddyLabel.Text = "OsuBuddy";
			this.osuBuddyLabel.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.logoPanel.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("logoPanel.BackgroundImage");
			this.logoPanel.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.logoPanel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.logoPanel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.logoPanel.Location = new global::System.Drawing.Point(0, 0);
			this.logoPanel.Name = "logoPanel";
			this.logoPanel.Size = new global::System.Drawing.Size(150, 65);
			this.logoPanel.TabIndex = 0;
			this.logoPanel.Click += new global::System.EventHandler(this.logo_Click);
			this.contentPanel.Controls.Add(this.separator);
			this.contentPanel.Controls.Add(this.statusLabel);
			this.contentPanel.Controls.Add(this.tabControl);
			this.contentPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.contentPanel.Location = new global::System.Drawing.Point(150, 0);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new global::System.Drawing.Size(650, 450);
			this.contentPanel.TabIndex = 1;
			this.separator.BackColor = global::System.Drawing.SystemColors.ButtonFace;
			this.separator.Location = new global::System.Drawing.Point(0, 0);
			this.separator.Name = "separator";
			this.separator.Size = new global::System.Drawing.Size(4, 450);
			this.separator.TabIndex = 2;
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.statusLabel.ForeColor = global::System.Drawing.Color.Teal;
			this.statusLabel.Location = new global::System.Drawing.Point(11, 9);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new global::System.Drawing.Size(189, 19);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.Text = "Welcome to OsuBuddy!";
			this.tabControl.Alignment = global::System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl.Controls.Add(this.loginTab);
			this.tabControl.Controls.Add(this.aimAssistTab);
			this.tabControl.Controls.Add(this.relaxTab);
			this.tabControl.Controls.Add(this.replayPlayerTab);
			this.tabControl.ItemSize = new global::System.Drawing.Size(1, 0);
			this.tabControl.Location = new global::System.Drawing.Point(0, 40);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new global::System.Drawing.Size(655, 435);
			this.tabControl.TabIndex = 0;
			this.loginTab.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.loginTab.Controls.Add(this.loginTextLabel);
			this.loginTab.Controls.Add(this.userSignUpButton);
			this.loginTab.Controls.Add(this.userLoginButton);
			this.loginTab.Controls.Add(this.passwordTextBox);
			this.loginTab.Controls.Add(this.usernameTextBox);
			this.loginTab.Controls.Add(this.label10);
			this.loginTab.Controls.Add(this.label9);
			this.loginTab.Controls.Add(this.button2);
			this.loginTab.Location = new global::System.Drawing.Point(4, 4);
			this.loginTab.Name = "loginTab";
			this.loginTab.Padding = new global::System.Windows.Forms.Padding(3);
			this.loginTab.Size = new global::System.Drawing.Size(647, 409);
			this.loginTab.TabIndex = 0;
			this.loginTab.Text = "Login";
			this.loginTextLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.loginTextLabel.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.loginTextLabel.ForeColor = global::System.Drawing.Color.Teal;
			this.loginTextLabel.Location = new global::System.Drawing.Point(3, 56);
			this.loginTextLabel.Name = "loginTextLabel";
			this.loginTextLabel.Size = new global::System.Drawing.Size(635, 75);
			this.loginTextLabel.TabIndex = 22;
			this.loginTextLabel.Text = "Please log in";
			this.loginTextLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.userSignUpButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.userSignUpButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.userSignUpButton.ForeColor = global::System.Drawing.Color.Teal;
			this.userSignUpButton.Location = new global::System.Drawing.Point(11, 287);
			this.userSignUpButton.Name = "userSignUpButton";
			this.userSignUpButton.Size = new global::System.Drawing.Size(623, 46);
			this.userSignUpButton.TabIndex = 21;
			this.userSignUpButton.Text = "Sign Up";
			this.userSignUpButton.UseVisualStyleBackColor = true;
			this.userSignUpButton.Click += new global::System.EventHandler(this.logo_Click);
			this.userLoginButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.userLoginButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.userLoginButton.ForeColor = global::System.Drawing.Color.Teal;
			this.userLoginButton.Location = new global::System.Drawing.Point(11, 235);
			this.userLoginButton.Name = "userLoginButton";
			this.userLoginButton.Size = new global::System.Drawing.Size(623, 46);
			this.userLoginButton.TabIndex = 19;
			this.userLoginButton.Text = "Login";
			this.userLoginButton.UseVisualStyleBackColor = true;
			this.userLoginButton.Click += new global::System.EventHandler(this.login);
			this.passwordTextBox.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.passwordTextBox.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.passwordTextBox.ForeColor = global::System.Drawing.Color.Teal;
			this.passwordTextBox.Location = new global::System.Drawing.Point(103, 184);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new global::System.Drawing.Size(531, 26);
			this.passwordTextBox.TabIndex = 18;
			this.passwordTextBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.textBox_KeyPress);
			this.usernameTextBox.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.usernameTextBox.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.usernameTextBox.ForeColor = global::System.Drawing.Color.Teal;
			this.usernameTextBox.Location = new global::System.Drawing.Point(103, 148);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new global::System.Drawing.Size(531, 26);
			this.usernameTextBox.TabIndex = 17;
			this.usernameTextBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.textBox_KeyPress);
			this.label10.AutoSize = true;
			this.label10.BackColor = global::System.Drawing.Color.Transparent;
			this.label10.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Teal;
			this.label10.Location = new global::System.Drawing.Point(7, 187);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(90, 19);
			this.label10.TabIndex = 16;
			this.label10.Text = "Password:";
			this.label9.AutoSize = true;
			this.label9.BackColor = global::System.Drawing.Color.Transparent;
			this.label9.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Teal;
			this.label9.Location = new global::System.Drawing.Point(7, 151);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(90, 19);
			this.label9.TabIndex = 15;
			this.label9.Text = "Username:";
			this.button2.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.button2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new global::System.Drawing.Font("Consolas", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Teal;
			this.button2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("button2.Image");
			this.button2.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new global::System.Drawing.Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(196, 50);
			this.button2.TabIndex = 14;
			this.button2.Text = "Login";
			this.button2.UseVisualStyleBackColor = false;
			this.aimAssistTab.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
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
			this.aimAssistTab.Location = new global::System.Drawing.Point(4, 4);
			this.aimAssistTab.Name = "aimAssistTab";
			this.aimAssistTab.Padding = new global::System.Windows.Forms.Padding(3);
			this.aimAssistTab.Size = new global::System.Drawing.Size(647, 409);
			this.aimAssistTab.TabIndex = 1;
			this.aimAssistTab.Text = "Aim Assist";
			this.button1.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.button1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Consolas", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.Teal;
			this.button1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("button1.Image");
			this.button1.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new global::System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(300, 50);
			this.button1.TabIndex = 13;
			this.button1.Text = "Aim Assist";
			this.button1.UseVisualStyleBackColor = false;
			this.aimAssistToggleButton.BackColor = global::System.Drawing.Color.Red;
			this.aimAssistToggleButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.aimAssistToggleButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.aimAssistToggleButton.Location = new global::System.Drawing.Point(19, 56);
			this.aimAssistToggleButton.Name = "aimAssistToggleButton";
			this.aimAssistToggleButton.Size = new global::System.Drawing.Size(141, 28);
			this.aimAssistToggleButton.TabIndex = 12;
			this.aimAssistToggleButton.Text = "Disabled";
			this.aimAssistToggleButton.UseVisualStyleBackColor = false;
			this.aimAssistToggleButton.Click += new global::System.EventHandler(this.aimAssistToggleButton_Click);
			this.aimStopDistanceOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.aimStopDistanceOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.aimStopDistanceOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.aimStopDistanceOutput.Location = new global::System.Drawing.Point(375, 322);
			this.aimStopDistanceOutput.Name = "aimStopDistanceOutput";
			this.aimStopDistanceOutput.Size = new global::System.Drawing.Size(100, 36);
			this.aimStopDistanceOutput.TabIndex = 11;
			this.aimStartDistanceOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.aimStartDistanceOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.aimStartDistanceOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.aimStartDistanceOutput.Location = new global::System.Drawing.Point(375, 222);
			this.aimStartDistanceOutput.Name = "aimStartDistanceOutput";
			this.aimStartDistanceOutput.Size = new global::System.Drawing.Size(100, 36);
			this.aimStartDistanceOutput.TabIndex = 10;
			this.aimSpeedOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.aimSpeedOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.aimSpeedOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.aimSpeedOutput.Location = new global::System.Drawing.Point(375, 122);
			this.aimSpeedOutput.Name = "aimSpeedOutput";
			this.aimSpeedOutput.Size = new global::System.Drawing.Size(100, 36);
			this.aimSpeedOutput.TabIndex = 9;
			this.aimStopDistanceTrackBar.LargeChange = 10;
			this.aimStopDistanceTrackBar.Location = new global::System.Drawing.Point(19, 322);
			this.aimStopDistanceTrackBar.Maximum = 100;
			this.aimStopDistanceTrackBar.Name = "aimStopDistanceTrackBar";
			this.aimStopDistanceTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.aimStopDistanceTrackBar.TabIndex = 8;
			this.aimStopDistanceTrackBar.TickFrequency = 10;
			this.aimStopDistanceTrackBar.Scroll += new global::System.EventHandler(this.aimStopDistanceTrackbar_Scroll);
			this.aimStartDistanceTrackBar.LargeChange = 100;
			this.aimStartDistanceTrackBar.Location = new global::System.Drawing.Point(19, 222);
			this.aimStartDistanceTrackBar.Maximum = 1000;
			this.aimStartDistanceTrackBar.Name = "aimStartDistanceTrackBar";
			this.aimStartDistanceTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.aimStartDistanceTrackBar.TabIndex = 7;
			this.aimStartDistanceTrackBar.TickFrequency = 100;
			this.aimStartDistanceTrackBar.Scroll += new global::System.EventHandler(this.aimStartDistanceTrackbar_Scroll);
			this.aimSpeedTrackBar.LargeChange = 1;
			this.aimSpeedTrackBar.Location = new global::System.Drawing.Point(19, 122);
			this.aimSpeedTrackBar.Maximum = 20;
			this.aimSpeedTrackBar.Name = "aimSpeedTrackBar";
			this.aimSpeedTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.aimSpeedTrackBar.TabIndex = 6;
			this.aimSpeedTrackBar.Scroll += new global::System.EventHandler(this.aimSpeedTrackbar_Scroll);
			this.label7.AutoSize = true;
			this.label7.BackColor = global::System.Drawing.Color.Transparent;
			this.label7.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Teal;
			this.label7.Location = new global::System.Drawing.Point(15, 300);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(162, 19);
			this.label7.TabIndex = 5;
			this.label7.Text = "Aim Stop Distance";
			this.label6.AutoSize = true;
			this.label6.BackColor = global::System.Drawing.Color.Transparent;
			this.label6.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Teal;
			this.label6.Location = new global::System.Drawing.Point(15, 200);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(171, 19);
			this.label6.TabIndex = 4;
			this.label6.Text = "Aim Start Distance";
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.Transparent;
			this.label5.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Teal;
			this.label5.Location = new global::System.Drawing.Point(15, 100);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(90, 19);
			this.label5.TabIndex = 3;
			this.label5.Text = "Aim Speed";
			this.relaxTab.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
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
			this.relaxTab.Location = new global::System.Drawing.Point(4, 4);
			this.relaxTab.Name = "relaxTab";
			this.relaxTab.Padding = new global::System.Windows.Forms.Padding(3);
			this.relaxTab.Size = new global::System.Drawing.Size(647, 409);
			this.relaxTab.TabIndex = 2;
			this.relaxTab.Text = "Relax";
			this.percentToHitOutsideOffsetOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.percentToHitOutsideOffsetOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.percentToHitOutsideOffsetOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.percentToHitOutsideOffsetOutput.Location = new global::System.Drawing.Point(375, 332);
			this.percentToHitOutsideOffsetOutput.Name = "percentToHitOutsideOffsetOutput";
			this.percentToHitOutsideOffsetOutput.Size = new global::System.Drawing.Size(100, 36);
			this.percentToHitOutsideOffsetOutput.TabIndex = 27;
			this.percentToHitOutsideOffsetTrackBar.Location = new global::System.Drawing.Point(19, 332);
			this.percentToHitOutsideOffsetTrackBar.Maximum = 100;
			this.percentToHitOutsideOffsetTrackBar.Name = "percentToHitOutsideOffsetTrackBar";
			this.percentToHitOutsideOffsetTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.percentToHitOutsideOffsetTrackBar.TabIndex = 26;
			this.percentToHitOutsideOffsetTrackBar.TickFrequency = 5;
			this.percentToHitOutsideOffsetTrackBar.Scroll += new global::System.EventHandler(this.percentToHitOutsideOffsetTrackbar_Scroll);
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Teal;
			this.label4.Location = new global::System.Drawing.Point(15, 310);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(270, 19);
			this.label4.TabIndex = 25;
			this.label4.Text = "Percent to hit outside Offset";
			this.alternateTimeOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.alternateTimeOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.alternateTimeOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.alternateTimeOutput.Location = new global::System.Drawing.Point(375, 262);
			this.alternateTimeOutput.Name = "alternateTimeOutput";
			this.alternateTimeOutput.Size = new global::System.Drawing.Size(100, 36);
			this.alternateTimeOutput.TabIndex = 24;
			this.holdTimeOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.holdTimeOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.holdTimeOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.holdTimeOutput.Location = new global::System.Drawing.Point(375, 192);
			this.holdTimeOutput.Name = "holdTimeOutput";
			this.holdTimeOutput.Size = new global::System.Drawing.Size(100, 36);
			this.holdTimeOutput.TabIndex = 23;
			this.offsetOutput.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.offsetOutput.Font = new global::System.Drawing.Font("Consolas", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.offsetOutput.ForeColor = global::System.Drawing.Color.Teal;
			this.offsetOutput.Location = new global::System.Drawing.Point(375, 122);
			this.offsetOutput.Name = "offsetOutput";
			this.offsetOutput.Size = new global::System.Drawing.Size(100, 36);
			this.offsetOutput.TabIndex = 22;
			this.alternateTimeTrackBar.LargeChange = 100;
			this.alternateTimeTrackBar.Location = new global::System.Drawing.Point(19, 262);
			this.alternateTimeTrackBar.Maximum = 1000;
			this.alternateTimeTrackBar.Name = "alternateTimeTrackBar";
			this.alternateTimeTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.alternateTimeTrackBar.TabIndex = 21;
			this.alternateTimeTrackBar.TickFrequency = 100;
			this.alternateTimeTrackBar.Scroll += new global::System.EventHandler(this.alternateTimeTrackbar_Scroll);
			this.holdTimeTrackBar.Location = new global::System.Drawing.Point(19, 192);
			this.holdTimeTrackBar.Maximum = 100;
			this.holdTimeTrackBar.Minimum = 30;
			this.holdTimeTrackBar.Name = "holdTimeTrackBar";
			this.holdTimeTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.holdTimeTrackBar.TabIndex = 20;
			this.holdTimeTrackBar.TickFrequency = 5;
			this.holdTimeTrackBar.Value = 30;
			this.holdTimeTrackBar.Scroll += new global::System.EventHandler(this.holdTimeTrackbar_Scroll);
			this.offsetTrackBar.Location = new global::System.Drawing.Point(19, 122);
			this.offsetTrackBar.Maximum = 50;
			this.offsetTrackBar.Name = "offsetTrackBar";
			this.offsetTrackBar.Size = new global::System.Drawing.Size(350, 45);
			this.offsetTrackBar.TabIndex = 19;
			this.offsetTrackBar.TickFrequency = 5;
			this.offsetTrackBar.Scroll += new global::System.EventHandler(this.offsetTrackbar_Scroll);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Teal;
			this.label3.Location = new global::System.Drawing.Point(15, 240);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(135, 19);
			this.label3.TabIndex = 18;
			this.label3.Text = "Alternate Time";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Teal;
			this.label2.Location = new global::System.Drawing.Point(15, 170);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(90, 19);
			this.label2.TabIndex = 17;
			this.label2.Text = "Hold Time";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Teal;
			this.label1.Location = new global::System.Drawing.Point(15, 100);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(63, 19);
			this.label1.TabIndex = 16;
			this.label1.Text = "Offset";
			this.relaxToggleButton.BackColor = global::System.Drawing.Color.Red;
			this.relaxToggleButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.relaxToggleButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.relaxToggleButton.Location = new global::System.Drawing.Point(19, 56);
			this.relaxToggleButton.Name = "relaxToggleButton";
			this.relaxToggleButton.Size = new global::System.Drawing.Size(141, 28);
			this.relaxToggleButton.TabIndex = 15;
			this.relaxToggleButton.Text = "Disabled";
			this.relaxToggleButton.UseVisualStyleBackColor = false;
			this.relaxToggleButton.Click += new global::System.EventHandler(this.relaxToggleButton_Click);
			this.button3.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.button3.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new global::System.Drawing.Font("Consolas", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.Teal;
			this.button3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("button3.Image");
			this.button3.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new global::System.Drawing.Point(0, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(196, 50);
			this.button3.TabIndex = 14;
			this.button3.Text = "Relax";
			this.button3.UseVisualStyleBackColor = false;
			this.replayPlayerTab.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.replayPlayerTab.Controls.Add(this.button4);
			this.replayPlayerTab.Controls.Add(this.playKeyboardButton);
			this.replayPlayerTab.Controls.Add(this.playMouseButton);
			this.replayPlayerTab.Controls.Add(this.flipReplayCheckBox);
			this.replayPlayerTab.Controls.Add(this.interpolateReplayCheckBox);
			this.replayPlayerTab.Controls.Add(this.selectReplayButton);
			this.replayPlayerTab.Controls.Add(this.currentReplayTextBox);
			this.replayPlayerTab.Controls.Add(this.label8);
			this.replayPlayerTab.Controls.Add(this.replayPlayerToggleButton);
			this.replayPlayerTab.Location = new global::System.Drawing.Point(4, 4);
			this.replayPlayerTab.Name = "replayPlayerTab";
			this.replayPlayerTab.Padding = new global::System.Windows.Forms.Padding(3);
			this.replayPlayerTab.Size = new global::System.Drawing.Size(647, 409);
			this.replayPlayerTab.TabIndex = 3;
			this.replayPlayerTab.Text = "Replay Player";
			this.button4.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.button4.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new global::System.Drawing.Font("Consolas", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.Teal;
			this.button4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("button4.Image");
			this.button4.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new global::System.Drawing.Point(0, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(363, 50);
			this.button4.TabIndex = 21;
			this.button4.Text = "Replay Player";
			this.button4.UseVisualStyleBackColor = false;
			this.playKeyboardButton.BackColor = global::System.Drawing.Color.Green;
			this.playKeyboardButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.playKeyboardButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.playKeyboardButton.Location = new global::System.Drawing.Point(180, 206);
			this.playKeyboardButton.Name = "playKeyboardButton";
			this.playKeyboardButton.Size = new global::System.Drawing.Size(271, 28);
			this.playKeyboardButton.TabIndex = 20;
			this.playKeyboardButton.Text = "Play Replay's Keyboard Input";
			this.playKeyboardButton.UseVisualStyleBackColor = false;
			this.playKeyboardButton.Click += new global::System.EventHandler(this.playKeyboardButton_Click);
			this.playMouseButton.BackColor = global::System.Drawing.Color.Green;
			this.playMouseButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.playMouseButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.playMouseButton.Location = new global::System.Drawing.Point(180, 172);
			this.playMouseButton.Name = "playMouseButton";
			this.playMouseButton.Size = new global::System.Drawing.Size(271, 28);
			this.playMouseButton.TabIndex = 19;
			this.playMouseButton.Text = "Play Replay's Mouse Input";
			this.playMouseButton.UseVisualStyleBackColor = false;
			this.playMouseButton.Click += new global::System.EventHandler(this.playMouseButton_Click);
			this.flipReplayCheckBox.AutoSize = true;
			this.flipReplayCheckBox.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.flipReplayCheckBox.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flipReplayCheckBox.ForeColor = global::System.Drawing.Color.Teal;
			this.flipReplayCheckBox.Location = new global::System.Drawing.Point(457, 302);
			this.flipReplayCheckBox.Name = "flipReplayCheckBox";
			this.flipReplayCheckBox.Size = new global::System.Drawing.Size(124, 23);
			this.flipReplayCheckBox.TabIndex = 18;
			this.flipReplayCheckBox.Text = "Flip Replay";
			this.flipReplayCheckBox.UseVisualStyleBackColor = true;
			this.flipReplayCheckBox.CheckedChanged += new global::System.EventHandler(this.flipReplayCheckBox_Click);
			this.interpolateReplayCheckBox.AutoSize = true;
			this.interpolateReplayCheckBox.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.interpolateReplayCheckBox.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.interpolateReplayCheckBox.ForeColor = global::System.Drawing.Color.Teal;
			this.interpolateReplayCheckBox.Location = new global::System.Drawing.Point(457, 331);
			this.interpolateReplayCheckBox.Name = "interpolateReplayCheckBox";
			this.interpolateReplayCheckBox.Size = new global::System.Drawing.Size(187, 23);
			this.interpolateReplayCheckBox.TabIndex = 17;
			this.interpolateReplayCheckBox.Text = "Interpolate Replay";
			this.interpolateReplayCheckBox.UseVisualStyleBackColor = true;
			this.interpolateReplayCheckBox.CheckedChanged += new global::System.EventHandler(this.interpolateReplayCheckBox_Click);
			this.selectReplayButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.selectReplayButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.selectReplayButton.ForeColor = global::System.Drawing.Color.Teal;
			this.selectReplayButton.Location = new global::System.Drawing.Point(500, 363);
			this.selectReplayButton.Name = "selectReplayButton";
			this.selectReplayButton.Size = new global::System.Drawing.Size(144, 26);
			this.selectReplayButton.TabIndex = 16;
			this.selectReplayButton.Text = "Select Replay";
			this.selectReplayButton.UseVisualStyleBackColor = true;
			this.selectReplayButton.Click += new global::System.EventHandler(this.selectReplayButton_Click);
			this.currentReplayTextBox.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			this.currentReplayTextBox.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.currentReplayTextBox.ForeColor = global::System.Drawing.Color.Teal;
			this.currentReplayTextBox.Location = new global::System.Drawing.Point(160, 363);
			this.currentReplayTextBox.Name = "currentReplayTextBox";
			this.currentReplayTextBox.Size = new global::System.Drawing.Size(334, 26);
			this.currentReplayTextBox.TabIndex = 15;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Teal;
			this.label8.Location = new global::System.Drawing.Point(15, 366);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(135, 19);
			this.label8.TabIndex = 14;
			this.label8.Text = "Current Replay";
			this.replayPlayerToggleButton.BackColor = global::System.Drawing.Color.Red;
			this.replayPlayerToggleButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.replayPlayerToggleButton.Font = new global::System.Drawing.Font("Consolas", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.replayPlayerToggleButton.Location = new global::System.Drawing.Point(19, 56);
			this.replayPlayerToggleButton.Name = "replayPlayerToggleButton";
			this.replayPlayerToggleButton.Size = new global::System.Drawing.Size(141, 28);
			this.replayPlayerToggleButton.TabIndex = 13;
			this.replayPlayerToggleButton.Text = "Disabled";
			this.replayPlayerToggleButton.UseVisualStyleBackColor = false;
			this.replayPlayerToggleButton.Click += new global::System.EventHandler(this.replayPlayerToggleButton_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(44, 44, 44);
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.contentPanel);
			base.Controls.Add(this.tabsPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "GUI";
			this.Text = "OsuBuddy";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.GUI_Closing);
			this.tabsPanel.ResumeLayout(false);
			this.tabsPanel.PerformLayout();
			this.contentPanel.ResumeLayout(false);
			this.contentPanel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.loginTab.ResumeLayout(false);
			this.loginTab.PerformLayout();
			this.aimAssistTab.ResumeLayout(false);
			this.aimAssistTab.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.aimStopDistanceTrackBar).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.aimStartDistanceTrackBar).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.aimSpeedTrackBar).EndInit();
			this.relaxTab.ResumeLayout(false);
			this.relaxTab.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.percentToHitOutsideOffsetTrackBar).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.alternateTimeTrackBar).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.holdTimeTrackBar).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.offsetTrackBar).EndInit();
			this.replayPlayerTab.ResumeLayout(false);
			this.replayPlayerTab.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003F6 RID: 1014
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040003F7 RID: 1015
		private global::System.Windows.Forms.Panel tabsPanel;

		// Token: 0x040003F8 RID: 1016
		private global::System.Windows.Forms.Label osuBuddyLabel;

		// Token: 0x040003F9 RID: 1017
		private global::System.Windows.Forms.Button replayPlayerButton;

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.Button relaxButton;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.Button aimAssistButton;

		// Token: 0x040003FC RID: 1020
		private global::System.Windows.Forms.Button loginButton;

		// Token: 0x040003FD RID: 1021
		private global::System.Windows.Forms.Panel logoPanel;

		// Token: 0x040003FE RID: 1022
		private global::System.Windows.Forms.Panel selectedPanel;

		// Token: 0x040003FF RID: 1023
		private global::System.Windows.Forms.Panel contentPanel;

		// Token: 0x04000400 RID: 1024
		private global::System.Windows.Forms.TabControl tabControl;

		// Token: 0x04000401 RID: 1025
		private global::System.Windows.Forms.TabPage loginTab;

		// Token: 0x04000402 RID: 1026
		private global::System.Windows.Forms.TabPage aimAssistTab;

		// Token: 0x04000403 RID: 1027
		private global::System.Windows.Forms.TabPage relaxTab;

		// Token: 0x04000404 RID: 1028
		private global::System.Windows.Forms.TabPage replayPlayerTab;

		// Token: 0x04000405 RID: 1029
		private global::System.Windows.Forms.TextBox aimStopDistanceOutput;

		// Token: 0x04000406 RID: 1030
		private global::System.Windows.Forms.TextBox aimStartDistanceOutput;

		// Token: 0x04000407 RID: 1031
		private global::System.Windows.Forms.TextBox aimSpeedOutput;

		// Token: 0x04000408 RID: 1032
		private global::System.Windows.Forms.TrackBar aimStopDistanceTrackBar;

		// Token: 0x04000409 RID: 1033
		private global::System.Windows.Forms.TrackBar aimStartDistanceTrackBar;

		// Token: 0x0400040A RID: 1034
		private global::System.Windows.Forms.TrackBar aimSpeedTrackBar;

		// Token: 0x0400040B RID: 1035
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400040C RID: 1036
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400040D RID: 1037
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400040E RID: 1038
		private global::System.Windows.Forms.Label statusLabel;

		// Token: 0x0400040F RID: 1039
		private global::System.Windows.Forms.Panel separator;

		// Token: 0x04000410 RID: 1040
		private global::System.Windows.Forms.Button aimAssistToggleButton;

		// Token: 0x04000411 RID: 1041
		private global::System.Windows.Forms.Button replayPlayerToggleButton;

		// Token: 0x04000412 RID: 1042
		private global::System.Windows.Forms.Button selectReplayButton;

		// Token: 0x04000413 RID: 1043
		private global::System.Windows.Forms.TextBox currentReplayTextBox;

		// Token: 0x04000414 RID: 1044
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000415 RID: 1045
		private global::System.Windows.Forms.CheckBox interpolateReplayCheckBox;

		// Token: 0x04000416 RID: 1046
		private global::System.Windows.Forms.CheckBox flipReplayCheckBox;

		// Token: 0x04000417 RID: 1047
		private global::System.Windows.Forms.Button playKeyboardButton;

		// Token: 0x04000418 RID: 1048
		private global::System.Windows.Forms.Button playMouseButton;

		// Token: 0x04000419 RID: 1049
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400041A RID: 1050
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400041B RID: 1051
		private global::System.Windows.Forms.Button button3;

		// Token: 0x0400041C RID: 1052
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400041D RID: 1053
		private global::System.Windows.Forms.Button relaxToggleButton;

		// Token: 0x0400041E RID: 1054
		private global::System.Windows.Forms.TextBox alternateTimeOutput;

		// Token: 0x0400041F RID: 1055
		private global::System.Windows.Forms.TextBox holdTimeOutput;

		// Token: 0x04000420 RID: 1056
		private global::System.Windows.Forms.TextBox offsetOutput;

		// Token: 0x04000421 RID: 1057
		private global::System.Windows.Forms.TrackBar alternateTimeTrackBar;

		// Token: 0x04000422 RID: 1058
		private global::System.Windows.Forms.TrackBar holdTimeTrackBar;

		// Token: 0x04000423 RID: 1059
		private global::System.Windows.Forms.TrackBar offsetTrackBar;

		// Token: 0x04000424 RID: 1060
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000425 RID: 1061
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000426 RID: 1062
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000427 RID: 1063
		private global::System.Windows.Forms.TrackBar percentToHitOutsideOffsetTrackBar;

		// Token: 0x04000428 RID: 1064
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000429 RID: 1065
		private global::System.Windows.Forms.TextBox percentToHitOutsideOffsetOutput;

		// Token: 0x0400042A RID: 1066
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400042B RID: 1067
		private global::System.Windows.Forms.TextBox usernameTextBox;

		// Token: 0x0400042C RID: 1068
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400042D RID: 1069
		private global::System.Windows.Forms.TextBox passwordTextBox;

		// Token: 0x0400042E RID: 1070
		private global::System.Windows.Forms.Button userSignUpButton;

		// Token: 0x0400042F RID: 1071
		private global::System.Windows.Forms.Button userLoginButton;

		// Token: 0x04000430 RID: 1072
		private global::System.Windows.Forms.Label loginTextLabel;
	}
}
