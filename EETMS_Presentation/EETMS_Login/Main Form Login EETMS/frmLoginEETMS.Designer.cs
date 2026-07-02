namespace EETMS_Presentation
{
    partial class frmLoginEETMS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginEETMS));
            this.GBorderLessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GTextBoxUserNameOrEmailUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.GPictureBoxShowHidePassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.GTextBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblShowMessageInLoginScreen = new System.Windows.Forms.Label();
            this.GGButtonLoginToEETMS = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label7 = new System.Windows.Forms.Label();
            this.GControlBoxExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GPictureBoxShowHidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBorderLessForm
            // 
            this.GBorderLessForm.AnimateWindow = true;
            this.GBorderLessForm.BorderRadius = 35;
            this.GBorderLessForm.ContainerControl = this;
            this.GBorderLessForm.DockIndicatorTransparencyValue = 0.6D;
            this.GBorderLessForm.TransparentWhileDrag = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 69.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 106);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sign In";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(22, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter your credentials to access your account.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(22, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email or Username";
            // 
            // GTextBoxUserNameOrEmailUser
            // 
            this.GTextBoxUserNameOrEmailUser.Animated = true;
            this.GTextBoxUserNameOrEmailUser.BackColor = System.Drawing.Color.Transparent;
            this.GTextBoxUserNameOrEmailUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.GTextBoxUserNameOrEmailUser.BorderRadius = 10;
            this.GTextBoxUserNameOrEmailUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxUserNameOrEmailUser.DefaultText = "";
            this.GTextBoxUserNameOrEmailUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxUserNameOrEmailUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxUserNameOrEmailUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxUserNameOrEmailUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxUserNameOrEmailUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.GTextBoxUserNameOrEmailUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxUserNameOrEmailUser.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.GTextBoxUserNameOrEmailUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxUserNameOrEmailUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxUserNameOrEmailUser.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.GTextBoxUserNameOrEmailUser.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxUserNameOrEmailUser.IconLeft")));
            this.GTextBoxUserNameOrEmailUser.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxUserNameOrEmailUser.Location = new System.Drawing.Point(25, 209);
            this.GTextBoxUserNameOrEmailUser.Name = "GTextBoxUserNameOrEmailUser";
            this.GTextBoxUserNameOrEmailUser.PlaceholderText = "admin@EETMS.com";
            this.GTextBoxUserNameOrEmailUser.SelectedText = "";
            this.GTextBoxUserNameOrEmailUser.Size = new System.Drawing.Size(510, 44);
            this.GTextBoxUserNameOrEmailUser.TabIndex = 0;
            // 
            // GPictureBoxShowHidePassword
            // 
            this.GPictureBoxShowHidePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.GPictureBoxShowHidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GPictureBoxShowHidePassword.Image = global::EETMS_Presentation.Properties.Resources.eye_show_gif_Image;
            this.GPictureBoxShowHidePassword.ImageRotate = 0F;
            this.GPictureBoxShowHidePassword.Location = new System.Drawing.Point(491, 319);
            this.GPictureBoxShowHidePassword.Name = "GPictureBoxShowHidePassword";
            this.GPictureBoxShowHidePassword.Size = new System.Drawing.Size(30, 25);
            this.GPictureBoxShowHidePassword.TabIndex = 4;
            this.GPictureBoxShowHidePassword.TabStop = false;
            this.GPictureBoxShowHidePassword.Click += new System.EventHandler(this.GPictureBoxShowPassword_Click);
            // 
            // GTextBoxPassword
            // 
            this.GTextBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.GTextBoxPassword.BorderRadius = 10;
            this.GTextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxPassword.DefaultText = "";
            this.GTextBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.GTextBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxPassword.IconLeft")));
            this.GTextBoxPassword.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxPassword.Location = new System.Drawing.Point(29, 311);
            this.GTextBoxPassword.Name = "GTextBoxPassword";
            this.GTextBoxPassword.PasswordChar = '•';
            this.GTextBoxPassword.PlaceholderText = "•••••••";
            this.GTextBoxPassword.SelectedText = "";
            this.GTextBoxPassword.Size = new System.Drawing.Size(506, 44);
            this.GTextBoxPassword.TabIndex = 1;
            // 
            // lblShowMessageInLoginScreen
            // 
            this.lblShowMessageInLoginScreen.AutoSize = true;
            this.lblShowMessageInLoginScreen.BackColor = System.Drawing.Color.Transparent;
            this.lblShowMessageInLoginScreen.Font = new System.Drawing.Font("Calisto MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowMessageInLoginScreen.ForeColor = System.Drawing.Color.White;
            this.lblShowMessageInLoginScreen.Location = new System.Drawing.Point(40, 375);
            this.lblShowMessageInLoginScreen.Name = "lblShowMessageInLoginScreen";
            this.lblShowMessageInLoginScreen.Size = new System.Drawing.Size(0, 17);
            this.lblShowMessageInLoginScreen.TabIndex = 6;
            // 
            // GGButtonLoginToEETMS
            // 
            this.GGButtonLoginToEETMS.Animated = true;
            this.GGButtonLoginToEETMS.AnimatedGIF = true;
            this.GGButtonLoginToEETMS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonLoginToEETMS.BorderRadius = 7;
            this.GGButtonLoginToEETMS.BorderThickness = 3;
            this.GGButtonLoginToEETMS.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonLoginToEETMS.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.GGButtonLoginToEETMS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonLoginToEETMS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonLoginToEETMS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonLoginToEETMS.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonLoginToEETMS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonLoginToEETMS.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonLoginToEETMS.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonLoginToEETMS.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonLoginToEETMS.ForeColor = System.Drawing.Color.White;
            this.GGButtonLoginToEETMS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonLoginToEETMS.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonLoginToEETMS.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonLoginToEETMS.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonLoginToEETMS.HoverState.ForeColor = System.Drawing.Color.White;
            this.GGButtonLoginToEETMS.Image = ((System.Drawing.Image)(resources.GetObject("GGButtonLoginToEETMS.Image")));
            this.GGButtonLoginToEETMS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GGButtonLoginToEETMS.ImageOffset = new System.Drawing.Point(130, 0);
            this.GGButtonLoginToEETMS.Location = new System.Drawing.Point(30, 408);
            this.GGButtonLoginToEETMS.Name = "GGButtonLoginToEETMS";
            this.GGButtonLoginToEETMS.Size = new System.Drawing.Size(516, 47);
            this.GGButtonLoginToEETMS.TabIndex = 2;
            this.GGButtonLoginToEETMS.Text = "Login To EETMS";
            this.GGButtonLoginToEETMS.Click += new System.EventHandler(this.GGButtonLoginToEETMS_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(26, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password";
            // 
            // GControlBoxExit
            // 
            this.GControlBoxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GControlBoxExit.Animated = true;
            this.GControlBoxExit.BorderRadius = 3;
            this.GControlBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GControlBoxExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GControlBoxExit.IconColor = System.Drawing.Color.White;
            this.GControlBoxExit.Location = new System.Drawing.Point(1308, 26);
            this.GControlBoxExit.Name = "GControlBoxExit";
            this.GControlBoxExit.Size = new System.Drawing.Size(30, 30);
            this.GControlBoxExit.TabIndex = 4;
            this.GControlBoxExit.Click += new System.EventHandler(this.GControlBoxExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(713, 852);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.GPictureBoxShowHidePassword);
            this.panel1.Controls.Add(this.GTextBoxPassword);
            this.panel1.Controls.Add(this.lblShowMessageInLoginScreen);
            this.panel1.Controls.Add(this.GGButtonLoginToEETMS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.GTextBoxUserNameOrEmailUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(766, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 531);
            this.panel1.TabIndex = 3;
            // 
            // frmLoginEETMS
            // 
            this.AcceptButton = this.GGButtonLoginToEETMS;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1371, 848);
            this.Controls.Add(this.GControlBoxExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginEETMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EETMS_Login";
            this.Load += new System.EventHandler(this.frmLoginEETMS_Load);
            this.Move += new System.EventHandler(this.frmLoginEETMS_Move);
            this.Resize += new System.EventHandler(this.frmLoginEETMS_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GPictureBoxShowHidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm GBorderLessForm;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxUserNameOrEmailUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonLoginToEETMS;
        private System.Windows.Forms.Label lblShowMessageInLoginScreen;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxPassword;
        private Guna.UI2.WinForms.Guna2PictureBox GPictureBoxShowHidePassword;
        private Guna.UI2.WinForms.Guna2ControlBox GControlBoxExit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
    }
}

