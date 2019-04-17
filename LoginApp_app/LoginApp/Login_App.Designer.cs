namespace LoginApp
{
    partial class Login_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_App));
            this.grpCreds = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.passIcon = new System.Windows.Forms.PictureBox();
            this.userIcon = new System.Windows.Forms.PictureBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpCreds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCreds
            // 
            this.grpCreds.BackColor = System.Drawing.SystemColors.Control;
            this.grpCreds.Controls.Add(this.txtPassword);
            this.grpCreds.Controls.Add(this.txtUsername);
            this.grpCreds.Controls.Add(this.passIcon);
            this.grpCreds.Controls.Add(this.userIcon);
            this.grpCreds.Location = new System.Drawing.Point(13, 13);
            this.grpCreds.Name = "grpCreds";
            this.grpCreds.Size = new System.Drawing.Size(381, 169);
            this.grpCreds.TabIndex = 0;
            this.grpCreds.TabStop = false;
            this.grpCreds.Text = "Login Credentials";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(282, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Location = new System.Drawing.Point(68, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(282, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // passIcon
            // 
            this.passIcon.Image = global::LoginApp.Properties.Resources.password;
            this.passIcon.Location = new System.Drawing.Point(7, 98);
            this.passIcon.Name = "passIcon";
            this.passIcon.Size = new System.Drawing.Size(41, 41);
            this.passIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passIcon.TabIndex = 1;
            this.passIcon.TabStop = false;
            // 
            // userIcon
            // 
            this.userIcon.Image = global::LoginApp.Properties.Resources.user;
            this.userIcon.InitialImage = global::LoginApp.Properties.Resources.user;
            this.userIcon.Location = new System.Drawing.Point(6, 36);
            this.userIcon.Name = "userIcon";
            this.userIcon.Size = new System.Drawing.Size(41, 41);
            this.userIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userIcon.TabIndex = 0;
            this.userIcon.TabStop = false;
            // 
            // grpStatus
            // 
            this.grpStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.grpStatus.Controls.Add(this.lblStatus);
            this.grpStatus.Location = new System.Drawing.Point(100, 189);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(139, 44);
            this.grpStatus.TabIndex = 3;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "STATUS";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Gothic", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(46, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 14);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "LOGGED OUT";
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAdmin.BackgroundImage = global::LoginApp.Properties.Resources.admin;
            this.btnAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdmin.Location = new System.Drawing.Point(337, 188);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(49, 45);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogout.BackgroundImage = global::LoginApp.Properties.Resources.logout;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Location = new System.Drawing.Point(264, 188);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(58, 45);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogin.BackgroundImage = global::LoginApp.Properties.Resources.login;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.Location = new System.Drawing.Point(20, 188);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(58, 45);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // Login_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(408, 253);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.grpCreds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(426, 300);
            this.MinimumSize = new System.Drawing.Size(426, 300);
            this.Name = "Login_App";
            this.Text = "Login Utility";
            this.grpCreds.ResumeLayout(false);
            this.grpCreds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCreds;
        private System.Windows.Forms.PictureBox userIcon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox passIcon;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAdmin;
    }
}

