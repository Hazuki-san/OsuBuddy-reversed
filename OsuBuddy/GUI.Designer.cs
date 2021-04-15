namespace OsuBuddy
{
	// Token: 0x020000AA RID: 170
	public partial class GUI : global::System.Windows.Forms.Form
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
			tabsPanel = new System.Windows.Forms.Panel();
			selectedPanel = new System.Windows.Forms.Panel();
			replayPlayerButton = new System.Windows.Forms.Button();
			relaxButton = new System.Windows.Forms.Button();
			aimAssistButton = new System.Windows.Forms.Button();
			loginButton = new System.Windows.Forms.Button();
			osuBuddyLabel = new System.Windows.Forms.Label();
			logoPanel = new System.Windows.Forms.Panel();
			contentPanel = new System.Windows.Forms.Panel();
			separator = new System.Windows.Forms.Panel();
			statusLabel = new System.Windows.Forms.Label();
			tabControl = new System.Windows.Forms.TabControl();
			loginTab = new System.Windows.Forms.TabPage();
			loginTextLabel = new System.Windows.Forms.Label();
			userSignUpButton = new System.Windows.Forms.Button();
			userLoginButton = new System.Windows.Forms.Button();
			passwordTextBox = new System.Windows.Forms.TextBox();
			usernameTextBox = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			aimAssistTab = new System.Windows.Forms.TabPage();
			button1 = new System.Windows.Forms.Button();
			aimAssistToggleButton = new System.Windows.Forms.Button();
			aimStopDistanceOutput = new System.Windows.Forms.TextBox();
			aimStartDistanceOutput = new System.Windows.Forms.TextBox();
			aimSpeedOutput = new System.Windows.Forms.TextBox();
			aimStopDistanceTrackBar = new System.Windows.Forms.TrackBar();
			aimStartDistanceTrackBar = new System.Windows.Forms.TrackBar();
			aimSpeedTrackBar = new System.Windows.Forms.TrackBar();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			relaxTab = new System.Windows.Forms.TabPage();
			percentToHitOutsideOffsetOutput = new System.Windows.Forms.TextBox();
			percentToHitOutsideOffsetTrackBar = new System.Windows.Forms.TrackBar();
			label4 = new System.Windows.Forms.Label();
			alternateTimeOutput = new System.Windows.Forms.TextBox();
			holdTimeOutput = new System.Windows.Forms.TextBox();
			offsetOutput = new System.Windows.Forms.TextBox();
			alternateTimeTrackBar = new System.Windows.Forms.TrackBar();
			holdTimeTrackBar = new System.Windows.Forms.TrackBar();
			offsetTrackBar = new System.Windows.Forms.TrackBar();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			relaxToggleButton = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			replayPlayerTab = new System.Windows.Forms.TabPage();
			button4 = new System.Windows.Forms.Button();
			playKeyboardButton = new System.Windows.Forms.Button();
			playMouseButton = new System.Windows.Forms.Button();
			flipReplayCheckBox = new System.Windows.Forms.CheckBox();
			interpolateReplayCheckBox = new System.Windows.Forms.CheckBox();
			selectReplayButton = new System.Windows.Forms.Button();
			currentReplayTextBox = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			replayPlayerToggleButton = new System.Windows.Forms.Button();
			tabsPanel.SuspendLayout();
			contentPanel.SuspendLayout();
			tabControl.SuspendLayout();
			loginTab.SuspendLayout();
			aimAssistTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)aimStopDistanceTrackBar).BeginInit();
			((System.ComponentModel.ISupportInitialize)aimStartDistanceTrackBar).BeginInit();
			((System.ComponentModel.ISupportInitialize)aimSpeedTrackBar).BeginInit();
			relaxTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)percentToHitOutsideOffsetTrackBar).BeginInit();
			((System.ComponentModel.ISupportInitialize)alternateTimeTrackBar).BeginInit();
			((System.ComponentModel.ISupportInitialize)holdTimeTrackBar).BeginInit();
			((System.ComponentModel.ISupportInitialize)offsetTrackBar).BeginInit();
			replayPlayerTab.SuspendLayout();
			SuspendLayout();
			tabsPanel.Controls.Add(selectedPanel);
			tabsPanel.Controls.Add(replayPlayerButton);
			tabsPanel.Controls.Add(relaxButton);
			tabsPanel.Controls.Add(aimAssistButton);
			tabsPanel.Controls.Add(loginButton);
			tabsPanel.Controls.Add(osuBuddyLabel);
			tabsPanel.Controls.Add(logoPanel);
			tabsPanel.Dock = System.Windows.Forms.DockStyle.Left;
			tabsPanel.Location = new System.Drawing.Point(0, 0);
			tabsPanel.Name = "tabsPanel";
			tabsPanel.Size = new System.Drawing.Size(150, 450);
			tabsPanel.TabIndex = 0;
			selectedPanel.BackColor = System.Drawing.Color.LightSeaGreen;
			selectedPanel.Location = new System.Drawing.Point(145, 100);
			selectedPanel.Name = "selectedPanel";
			selectedPanel.Size = new System.Drawing.Size(5, 75);
			selectedPanel.TabIndex = 0;
			replayPlayerButton.Enabled = false;
			replayPlayerButton.FlatAppearance.BorderSize = 0;
			replayPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			replayPlayerButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			replayPlayerButton.ForeColor = System.Drawing.Color.Teal;
			replayPlayerButton.Image = (System.Drawing.Image)resources.GetObject("replayPlayerButton.Image");
			replayPlayerButton.Location = new System.Drawing.Point(0, 325);
			replayPlayerButton.Name = "replayPlayerButton";
			replayPlayerButton.Size = new System.Drawing.Size(150, 75);
			replayPlayerButton.TabIndex = 4;
			replayPlayerButton.Text = "Replay Player";
			replayPlayerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			replayPlayerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			replayPlayerButton.UseVisualStyleBackColor = true;
			replayPlayerButton.Click += new System.EventHandler(replayPlayerButton_Click);
			relaxButton.Enabled = false;
			relaxButton.FlatAppearance.BorderSize = 0;
			relaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			relaxButton.Font = new System.Drawing.Font("Consolas", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			relaxButton.ForeColor = System.Drawing.Color.Teal;
			relaxButton.Image = (System.Drawing.Image)resources.GetObject("relaxButton.Image");
			relaxButton.Location = new System.Drawing.Point(0, 250);
			relaxButton.Name = "relaxButton";
			relaxButton.Size = new System.Drawing.Size(150, 75);
			relaxButton.TabIndex = 3;
			relaxButton.Text = "Relax";
			relaxButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			relaxButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			relaxButton.UseVisualStyleBackColor = true;
			relaxButton.Click += new System.EventHandler(relaxButton_Click);
			aimAssistButton.Enabled = false;
			aimAssistButton.FlatAppearance.BorderSize = 0;
			aimAssistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			aimAssistButton.Font = new System.Drawing.Font("Consolas", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			aimAssistButton.ForeColor = System.Drawing.Color.Teal;
			aimAssistButton.Image = (System.Drawing.Image)resources.GetObject("aimAssistButton.Image");
			aimAssistButton.Location = new System.Drawing.Point(0, 175);
			aimAssistButton.Name = "aimAssistButton";
			aimAssistButton.Size = new System.Drawing.Size(150, 75);
			aimAssistButton.TabIndex = 2;
			aimAssistButton.Text = "Aim Assist";
			aimAssistButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			aimAssistButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			aimAssistButton.UseVisualStyleBackColor = true;
			aimAssistButton.Click += new System.EventHandler(aimAssistButton_Click);
			loginButton.FlatAppearance.BorderSize = 0;
			loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			loginButton.Font = new System.Drawing.Font("Consolas", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			loginButton.ForeColor = System.Drawing.Color.Teal;
			loginButton.Image = (System.Drawing.Image)resources.GetObject("loginButton.Image");
			loginButton.Location = new System.Drawing.Point(0, 100);
			loginButton.Name = "loginButton";
			loginButton.Size = new System.Drawing.Size(150, 75);
			loginButton.TabIndex = 1;
			loginButton.Text = "Login";
			loginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			loginButton.UseVisualStyleBackColor = true;
			loginButton.Click += new System.EventHandler(loginButton_Click);
			osuBuddyLabel.AutoSize = true;
			osuBuddyLabel.BackColor = System.Drawing.Color.Transparent;
			osuBuddyLabel.Font = new System.Drawing.Font("Consolas", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			osuBuddyLabel.ForeColor = System.Drawing.Color.Teal;
			osuBuddyLabel.Location = new System.Drawing.Point(9, 68);
			osuBuddyLabel.Name = "osuBuddyLabel";
			osuBuddyLabel.Size = new System.Drawing.Size(135, 32);
			osuBuddyLabel.TabIndex = 0;
			osuBuddyLabel.Text = "OsuBuddy";
			osuBuddyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			logoPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("logoPanel.BackgroundImage");
			logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			logoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
			logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
			logoPanel.Location = new System.Drawing.Point(0, 0);
			logoPanel.Name = "logoPanel";
			logoPanel.Size = new System.Drawing.Size(150, 65);
			logoPanel.TabIndex = 0;
			logoPanel.Click += new System.EventHandler(logo_Click);
			contentPanel.Controls.Add(separator);
			contentPanel.Controls.Add(statusLabel);
			contentPanel.Controls.Add(tabControl);
			contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			contentPanel.Location = new System.Drawing.Point(150, 0);
			contentPanel.Name = "contentPanel";
			contentPanel.Size = new System.Drawing.Size(650, 450);
			contentPanel.TabIndex = 1;
			separator.BackColor = System.Drawing.SystemColors.ButtonFace;
			separator.Location = new System.Drawing.Point(0, 0);
			separator.Name = "separator";
			separator.Size = new System.Drawing.Size(4, 450);
			separator.TabIndex = 2;
			statusLabel.AutoSize = true;
			statusLabel.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusLabel.ForeColor = System.Drawing.Color.Teal;
			statusLabel.Location = new System.Drawing.Point(11, 9);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new System.Drawing.Size(189, 19);
			statusLabel.TabIndex = 1;
			statusLabel.Text = "Welcome to OsuBuddy!";
			tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			tabControl.Controls.Add(loginTab);
			tabControl.Controls.Add(aimAssistTab);
			tabControl.Controls.Add(relaxTab);
			tabControl.Controls.Add(replayPlayerTab);
			tabControl.ItemSize = new System.Drawing.Size(1, 0);
			tabControl.Location = new System.Drawing.Point(0, 40);
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			tabControl.Size = new System.Drawing.Size(655, 435);
			tabControl.TabIndex = 0;
			loginTab.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			loginTab.Controls.Add(loginTextLabel);
			loginTab.Controls.Add(userSignUpButton);
			loginTab.Controls.Add(userLoginButton);
			loginTab.Controls.Add(passwordTextBox);
			loginTab.Controls.Add(usernameTextBox);
			loginTab.Controls.Add(label10);
			loginTab.Controls.Add(label9);
			loginTab.Controls.Add(button2);
			loginTab.Location = new System.Drawing.Point(4, 4);
			loginTab.Name = "loginTab";
			loginTab.Padding = new System.Windows.Forms.Padding(3);
			loginTab.Size = new System.Drawing.Size(647, 409);
			loginTab.TabIndex = 0;
			loginTab.Text = "Login";
			loginTextLabel.BackColor = System.Drawing.Color.Transparent;
			loginTextLabel.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			loginTextLabel.ForeColor = System.Drawing.Color.Teal;
			loginTextLabel.Location = new System.Drawing.Point(3, 56);
			loginTextLabel.Name = "loginTextLabel";
			loginTextLabel.Size = new System.Drawing.Size(635, 75);
			loginTextLabel.TabIndex = 22;
			loginTextLabel.Text = "Please log in";
			loginTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			userSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			userSignUpButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			userSignUpButton.ForeColor = System.Drawing.Color.Teal;
			userSignUpButton.Location = new System.Drawing.Point(11, 287);
			userSignUpButton.Name = "userSignUpButton";
			userSignUpButton.Size = new System.Drawing.Size(623, 46);
			userSignUpButton.TabIndex = 21;
			userSignUpButton.Text = "Sign Up";
			userSignUpButton.UseVisualStyleBackColor = true;
			userSignUpButton.Click += new System.EventHandler(logo_Click);
			userLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			userLoginButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			userLoginButton.ForeColor = System.Drawing.Color.Teal;
			userLoginButton.Location = new System.Drawing.Point(11, 235);
			userLoginButton.Name = "userLoginButton";
			userLoginButton.Size = new System.Drawing.Size(623, 46);
			userLoginButton.TabIndex = 19;
			userLoginButton.Text = "Login";
			userLoginButton.UseVisualStyleBackColor = true;
			userLoginButton.Click += new System.EventHandler(login);
			passwordTextBox.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			passwordTextBox.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			passwordTextBox.ForeColor = System.Drawing.Color.Teal;
			passwordTextBox.Location = new System.Drawing.Point(103, 184);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.PasswordChar = '*';
			passwordTextBox.Size = new System.Drawing.Size(531, 26);
			passwordTextBox.TabIndex = 18;
			passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_KeyPress);
			usernameTextBox.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			usernameTextBox.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			usernameTextBox.ForeColor = System.Drawing.Color.Teal;
			usernameTextBox.Location = new System.Drawing.Point(103, 148);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new System.Drawing.Size(531, 26);
			usernameTextBox.TabIndex = 17;
			usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_KeyPress);
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.Teal;
			label10.Location = new System.Drawing.Point(7, 187);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(90, 19);
			label10.TabIndex = 16;
			label10.Text = "Password:";
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.ForeColor = System.Drawing.Color.Teal;
			label9.Location = new System.Drawing.Point(7, 151);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(90, 19);
			label9.TabIndex = 15;
			label9.Text = "Username:";
			button2.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Consolas", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.Teal;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button2.Location = new System.Drawing.Point(0, 0);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(196, 50);
			button2.TabIndex = 14;
			button2.Text = "Login";
			button2.UseVisualStyleBackColor = false;
			aimAssistTab.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			aimAssistTab.Controls.Add(button1);
			aimAssistTab.Controls.Add(aimAssistToggleButton);
			aimAssistTab.Controls.Add(aimStopDistanceOutput);
			aimAssistTab.Controls.Add(aimStartDistanceOutput);
			aimAssistTab.Controls.Add(aimSpeedOutput);
			aimAssistTab.Controls.Add(aimStopDistanceTrackBar);
			aimAssistTab.Controls.Add(aimStartDistanceTrackBar);
			aimAssistTab.Controls.Add(aimSpeedTrackBar);
			aimAssistTab.Controls.Add(label7);
			aimAssistTab.Controls.Add(label6);
			aimAssistTab.Controls.Add(label5);
			aimAssistTab.Location = new System.Drawing.Point(4, 4);
			aimAssistTab.Name = "aimAssistTab";
			aimAssistTab.Padding = new System.Windows.Forms.Padding(3);
			aimAssistTab.Size = new System.Drawing.Size(647, 409);
			aimAssistTab.TabIndex = 1;
			aimAssistTab.Text = "Aim Assist";
			button1.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Consolas", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.Teal;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.Location = new System.Drawing.Point(0, 0);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(300, 50);
			button1.TabIndex = 13;
			button1.Text = "Aim Assist";
			button1.UseVisualStyleBackColor = false;
			aimAssistToggleButton.BackColor = System.Drawing.Color.Red;
			aimAssistToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			aimAssistToggleButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			aimAssistToggleButton.Location = new System.Drawing.Point(19, 56);
			aimAssistToggleButton.Name = "aimAssistToggleButton";
			aimAssistToggleButton.Size = new System.Drawing.Size(141, 28);
			aimAssistToggleButton.TabIndex = 12;
			aimAssistToggleButton.Text = "Disabled";
			aimAssistToggleButton.UseVisualStyleBackColor = false;
			aimAssistToggleButton.Click += new System.EventHandler(aimAssistToggleButton_Click);
			aimStopDistanceOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			aimStopDistanceOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			aimStopDistanceOutput.ForeColor = System.Drawing.Color.Teal;
			aimStopDistanceOutput.Location = new System.Drawing.Point(375, 322);
			aimStopDistanceOutput.Name = "aimStopDistanceOutput";
			aimStopDistanceOutput.Size = new System.Drawing.Size(100, 36);
			aimStopDistanceOutput.TabIndex = 11;
			aimStartDistanceOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			aimStartDistanceOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			aimStartDistanceOutput.ForeColor = System.Drawing.Color.Teal;
			aimStartDistanceOutput.Location = new System.Drawing.Point(375, 222);
			aimStartDistanceOutput.Name = "aimStartDistanceOutput";
			aimStartDistanceOutput.Size = new System.Drawing.Size(100, 36);
			aimStartDistanceOutput.TabIndex = 10;
			aimSpeedOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			aimSpeedOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			aimSpeedOutput.ForeColor = System.Drawing.Color.Teal;
			aimSpeedOutput.Location = new System.Drawing.Point(375, 122);
			aimSpeedOutput.Name = "aimSpeedOutput";
			aimSpeedOutput.Size = new System.Drawing.Size(100, 36);
			aimSpeedOutput.TabIndex = 9;
			aimStopDistanceTrackBar.LargeChange = 10;
			aimStopDistanceTrackBar.Location = new System.Drawing.Point(19, 322);
			aimStopDistanceTrackBar.Maximum = 100;
			aimStopDistanceTrackBar.Name = "aimStopDistanceTrackBar";
			aimStopDistanceTrackBar.Size = new System.Drawing.Size(350, 45);
			aimStopDistanceTrackBar.TabIndex = 8;
			aimStopDistanceTrackBar.TickFrequency = 10;
			aimStopDistanceTrackBar.Scroll += new System.EventHandler(aimStopDistanceTrackbar_Scroll);
			aimStartDistanceTrackBar.LargeChange = 100;
			aimStartDistanceTrackBar.Location = new System.Drawing.Point(19, 222);
			aimStartDistanceTrackBar.Maximum = 1000;
			aimStartDistanceTrackBar.Name = "aimStartDistanceTrackBar";
			aimStartDistanceTrackBar.Size = new System.Drawing.Size(350, 45);
			aimStartDistanceTrackBar.TabIndex = 7;
			aimStartDistanceTrackBar.TickFrequency = 100;
			aimStartDistanceTrackBar.Scroll += new System.EventHandler(aimStartDistanceTrackbar_Scroll);
			aimSpeedTrackBar.LargeChange = 1;
			aimSpeedTrackBar.Location = new System.Drawing.Point(19, 122);
			aimSpeedTrackBar.Maximum = 20;
			aimSpeedTrackBar.Name = "aimSpeedTrackBar";
			aimSpeedTrackBar.Size = new System.Drawing.Size(350, 45);
			aimSpeedTrackBar.TabIndex = 6;
			aimSpeedTrackBar.Scroll += new System.EventHandler(aimSpeedTrackbar_Scroll);
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.ForeColor = System.Drawing.Color.Teal;
			label7.Location = new System.Drawing.Point(15, 300);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(162, 19);
			label7.TabIndex = 5;
			label7.Text = "Aim Stop Distance";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.Teal;
			label6.Location = new System.Drawing.Point(15, 200);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(171, 19);
			label6.TabIndex = 4;
			label6.Text = "Aim Start Distance";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.ForeColor = System.Drawing.Color.Teal;
			label5.Location = new System.Drawing.Point(15, 100);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 19);
			label5.TabIndex = 3;
			label5.Text = "Aim Speed";
			relaxTab.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			relaxTab.Controls.Add(percentToHitOutsideOffsetOutput);
			relaxTab.Controls.Add(percentToHitOutsideOffsetTrackBar);
			relaxTab.Controls.Add(label4);
			relaxTab.Controls.Add(alternateTimeOutput);
			relaxTab.Controls.Add(holdTimeOutput);
			relaxTab.Controls.Add(offsetOutput);
			relaxTab.Controls.Add(alternateTimeTrackBar);
			relaxTab.Controls.Add(holdTimeTrackBar);
			relaxTab.Controls.Add(offsetTrackBar);
			relaxTab.Controls.Add(label3);
			relaxTab.Controls.Add(label2);
			relaxTab.Controls.Add(label1);
			relaxTab.Controls.Add(relaxToggleButton);
			relaxTab.Controls.Add(button3);
			relaxTab.Location = new System.Drawing.Point(4, 4);
			relaxTab.Name = "relaxTab";
			relaxTab.Padding = new System.Windows.Forms.Padding(3);
			relaxTab.Size = new System.Drawing.Size(647, 409);
			relaxTab.TabIndex = 2;
			relaxTab.Text = "Relax";
			percentToHitOutsideOffsetOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			percentToHitOutsideOffsetOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			percentToHitOutsideOffsetOutput.ForeColor = System.Drawing.Color.Teal;
			percentToHitOutsideOffsetOutput.Location = new System.Drawing.Point(375, 332);
			percentToHitOutsideOffsetOutput.Name = "percentToHitOutsideOffsetOutput";
			percentToHitOutsideOffsetOutput.Size = new System.Drawing.Size(100, 36);
			percentToHitOutsideOffsetOutput.TabIndex = 27;
			percentToHitOutsideOffsetTrackBar.Location = new System.Drawing.Point(19, 332);
			percentToHitOutsideOffsetTrackBar.Maximum = 100;
			percentToHitOutsideOffsetTrackBar.Name = "percentToHitOutsideOffsetTrackBar";
			percentToHitOutsideOffsetTrackBar.Size = new System.Drawing.Size(350, 45);
			percentToHitOutsideOffsetTrackBar.TabIndex = 26;
			percentToHitOutsideOffsetTrackBar.TickFrequency = 5;
			percentToHitOutsideOffsetTrackBar.Scroll += new System.EventHandler(percentToHitOutsideOffsetTrackbar_Scroll);
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Teal;
			label4.Location = new System.Drawing.Point(15, 310);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(270, 19);
			label4.TabIndex = 25;
			label4.Text = "Percent to hit outside Offset";
			alternateTimeOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			alternateTimeOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			alternateTimeOutput.ForeColor = System.Drawing.Color.Teal;
			alternateTimeOutput.Location = new System.Drawing.Point(375, 262);
			alternateTimeOutput.Name = "alternateTimeOutput";
			alternateTimeOutput.Size = new System.Drawing.Size(100, 36);
			alternateTimeOutput.TabIndex = 24;
			holdTimeOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			holdTimeOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			holdTimeOutput.ForeColor = System.Drawing.Color.Teal;
			holdTimeOutput.Location = new System.Drawing.Point(375, 192);
			holdTimeOutput.Name = "holdTimeOutput";
			holdTimeOutput.Size = new System.Drawing.Size(100, 36);
			holdTimeOutput.TabIndex = 23;
			offsetOutput.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			offsetOutput.Font = new System.Drawing.Font("Consolas", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			offsetOutput.ForeColor = System.Drawing.Color.Teal;
			offsetOutput.Location = new System.Drawing.Point(375, 122);
			offsetOutput.Name = "offsetOutput";
			offsetOutput.Size = new System.Drawing.Size(100, 36);
			offsetOutput.TabIndex = 22;
			alternateTimeTrackBar.LargeChange = 100;
			alternateTimeTrackBar.Location = new System.Drawing.Point(19, 262);
			alternateTimeTrackBar.Maximum = 1000;
			alternateTimeTrackBar.Name = "alternateTimeTrackBar";
			alternateTimeTrackBar.Size = new System.Drawing.Size(350, 45);
			alternateTimeTrackBar.TabIndex = 21;
			alternateTimeTrackBar.TickFrequency = 100;
			alternateTimeTrackBar.Scroll += new System.EventHandler(alternateTimeTrackbar_Scroll);
			holdTimeTrackBar.Location = new System.Drawing.Point(19, 192);
			holdTimeTrackBar.Maximum = 100;
			holdTimeTrackBar.Minimum = 30;
			holdTimeTrackBar.Name = "holdTimeTrackBar";
			holdTimeTrackBar.Size = new System.Drawing.Size(350, 45);
			holdTimeTrackBar.TabIndex = 20;
			holdTimeTrackBar.TickFrequency = 5;
			holdTimeTrackBar.Value = 30;
			holdTimeTrackBar.Scroll += new System.EventHandler(holdTimeTrackbar_Scroll);
			offsetTrackBar.Location = new System.Drawing.Point(19, 122);
			offsetTrackBar.Maximum = 50;
			offsetTrackBar.Name = "offsetTrackBar";
			offsetTrackBar.Size = new System.Drawing.Size(350, 45);
			offsetTrackBar.TabIndex = 19;
			offsetTrackBar.TickFrequency = 5;
			offsetTrackBar.Scroll += new System.EventHandler(offsetTrackbar_Scroll);
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Teal;
			label3.Location = new System.Drawing.Point(15, 240);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(135, 19);
			label3.TabIndex = 18;
			label3.Text = "Alternate Time";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.Teal;
			label2.Location = new System.Drawing.Point(15, 170);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(90, 19);
			label2.TabIndex = 17;
			label2.Text = "Hold Time";
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Teal;
			label1.Location = new System.Drawing.Point(15, 100);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 19);
			label1.TabIndex = 16;
			label1.Text = "Offset";
			relaxToggleButton.BackColor = System.Drawing.Color.Red;
			relaxToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			relaxToggleButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			relaxToggleButton.Location = new System.Drawing.Point(19, 56);
			relaxToggleButton.Name = "relaxToggleButton";
			relaxToggleButton.Size = new System.Drawing.Size(141, 28);
			relaxToggleButton.TabIndex = 15;
			relaxToggleButton.Text = "Disabled";
			relaxToggleButton.UseVisualStyleBackColor = false;
			relaxToggleButton.Click += new System.EventHandler(relaxToggleButton_Click);
			button3.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button3.Font = new System.Drawing.Font("Consolas", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button3.ForeColor = System.Drawing.Color.Teal;
			button3.Image = (System.Drawing.Image)resources.GetObject("button3.Image");
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(0, 0);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(196, 50);
			button3.TabIndex = 14;
			button3.Text = "Relax";
			button3.UseVisualStyleBackColor = false;
			replayPlayerTab.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			replayPlayerTab.Controls.Add(button4);
			replayPlayerTab.Controls.Add(playKeyboardButton);
			replayPlayerTab.Controls.Add(playMouseButton);
			replayPlayerTab.Controls.Add(flipReplayCheckBox);
			replayPlayerTab.Controls.Add(interpolateReplayCheckBox);
			replayPlayerTab.Controls.Add(selectReplayButton);
			replayPlayerTab.Controls.Add(currentReplayTextBox);
			replayPlayerTab.Controls.Add(label8);
			replayPlayerTab.Controls.Add(replayPlayerToggleButton);
			replayPlayerTab.Location = new System.Drawing.Point(4, 4);
			replayPlayerTab.Name = "replayPlayerTab";
			replayPlayerTab.Padding = new System.Windows.Forms.Padding(3);
			replayPlayerTab.Size = new System.Drawing.Size(647, 409);
			replayPlayerTab.TabIndex = 3;
			replayPlayerTab.Text = "Replay Player";
			button4.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button4.Font = new System.Drawing.Font("Consolas", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button4.ForeColor = System.Drawing.Color.Teal;
			button4.Image = (System.Drawing.Image)resources.GetObject("button4.Image");
			button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button4.Location = new System.Drawing.Point(0, 0);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(363, 50);
			button4.TabIndex = 21;
			button4.Text = "Replay Player";
			button4.UseVisualStyleBackColor = false;
			playKeyboardButton.BackColor = System.Drawing.Color.Green;
			playKeyboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			playKeyboardButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			playKeyboardButton.Location = new System.Drawing.Point(180, 206);
			playKeyboardButton.Name = "playKeyboardButton";
			playKeyboardButton.Size = new System.Drawing.Size(271, 28);
			playKeyboardButton.TabIndex = 20;
			playKeyboardButton.Text = "Play Replay's Keyboard Input";
			playKeyboardButton.UseVisualStyleBackColor = false;
			playKeyboardButton.Click += new System.EventHandler(playKeyboardButton_Click);
			playMouseButton.BackColor = System.Drawing.Color.Green;
			playMouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			playMouseButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			playMouseButton.Location = new System.Drawing.Point(180, 172);
			playMouseButton.Name = "playMouseButton";
			playMouseButton.Size = new System.Drawing.Size(271, 28);
			playMouseButton.TabIndex = 19;
			playMouseButton.Text = "Play Replay's Mouse Input";
			playMouseButton.UseVisualStyleBackColor = false;
			playMouseButton.Click += new System.EventHandler(playMouseButton_Click);
			flipReplayCheckBox.AutoSize = true;
			flipReplayCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			flipReplayCheckBox.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			flipReplayCheckBox.ForeColor = System.Drawing.Color.Teal;
			flipReplayCheckBox.Location = new System.Drawing.Point(457, 302);
			flipReplayCheckBox.Name = "flipReplayCheckBox";
			flipReplayCheckBox.Size = new System.Drawing.Size(124, 23);
			flipReplayCheckBox.TabIndex = 18;
			flipReplayCheckBox.Text = "Flip Replay";
			flipReplayCheckBox.UseVisualStyleBackColor = true;
			flipReplayCheckBox.CheckedChanged += new System.EventHandler(flipReplayCheckBox_Click);
			interpolateReplayCheckBox.AutoSize = true;
			interpolateReplayCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			interpolateReplayCheckBox.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			interpolateReplayCheckBox.ForeColor = System.Drawing.Color.Teal;
			interpolateReplayCheckBox.Location = new System.Drawing.Point(457, 331);
			interpolateReplayCheckBox.Name = "interpolateReplayCheckBox";
			interpolateReplayCheckBox.Size = new System.Drawing.Size(187, 23);
			interpolateReplayCheckBox.TabIndex = 17;
			interpolateReplayCheckBox.Text = "Interpolate Replay";
			interpolateReplayCheckBox.UseVisualStyleBackColor = true;
			interpolateReplayCheckBox.CheckedChanged += new System.EventHandler(interpolateReplayCheckBox_Click);
			selectReplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			selectReplayButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			selectReplayButton.ForeColor = System.Drawing.Color.Teal;
			selectReplayButton.Location = new System.Drawing.Point(500, 363);
			selectReplayButton.Name = "selectReplayButton";
			selectReplayButton.Size = new System.Drawing.Size(144, 26);
			selectReplayButton.TabIndex = 16;
			selectReplayButton.Text = "Select Replay";
			selectReplayButton.UseVisualStyleBackColor = true;
			selectReplayButton.Click += new System.EventHandler(selectReplayButton_Click);
			currentReplayTextBox.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			currentReplayTextBox.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			currentReplayTextBox.ForeColor = System.Drawing.Color.Teal;
			currentReplayTextBox.Location = new System.Drawing.Point(160, 363);
			currentReplayTextBox.Name = "currentReplayTextBox";
			currentReplayTextBox.Size = new System.Drawing.Size(334, 26);
			currentReplayTextBox.TabIndex = 15;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.ForeColor = System.Drawing.Color.Teal;
			label8.Location = new System.Drawing.Point(15, 366);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(135, 19);
			label8.TabIndex = 14;
			label8.Text = "Current Replay";
			replayPlayerToggleButton.BackColor = System.Drawing.Color.Red;
			replayPlayerToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			replayPlayerToggleButton.Font = new System.Drawing.Font("Consolas", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			replayPlayerToggleButton.Location = new System.Drawing.Point(19, 56);
			replayPlayerToggleButton.Name = "replayPlayerToggleButton";
			replayPlayerToggleButton.Size = new System.Drawing.Size(141, 28);
			replayPlayerToggleButton.TabIndex = 13;
			replayPlayerToggleButton.Text = "Disabled";
			replayPlayerToggleButton.UseVisualStyleBackColor = false;
			replayPlayerToggleButton.Click += new System.EventHandler(replayPlayerToggleButton_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
			base.ClientSize = new System.Drawing.Size(800, 450);
			base.Controls.Add(contentPanel);
			base.Controls.Add(tabsPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "GUI";
			Text = "OsuBuddy";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(GUI_Closing);
			tabsPanel.ResumeLayout(false);
			tabsPanel.PerformLayout();
			contentPanel.ResumeLayout(false);
			contentPanel.PerformLayout();
			tabControl.ResumeLayout(false);
			loginTab.ResumeLayout(false);
			loginTab.PerformLayout();
			aimAssistTab.ResumeLayout(false);
			aimAssistTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)aimStopDistanceTrackBar).EndInit();
			((System.ComponentModel.ISupportInitialize)aimStartDistanceTrackBar).EndInit();
			((System.ComponentModel.ISupportInitialize)aimSpeedTrackBar).EndInit();
			relaxTab.ResumeLayout(false);
			relaxTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)percentToHitOutsideOffsetTrackBar).EndInit();
			((System.ComponentModel.ISupportInitialize)alternateTimeTrackBar).EndInit();
			((System.ComponentModel.ISupportInitialize)holdTimeTrackBar).EndInit();
			((System.ComponentModel.ISupportInitialize)offsetTrackBar).EndInit();
			replayPlayerTab.ResumeLayout(false);
			replayPlayerTab.PerformLayout();
			ResumeLayout(false);
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
