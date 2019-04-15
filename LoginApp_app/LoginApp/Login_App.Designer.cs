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
            this.userIcon = new System.Windows.Forms.PictureBox();
            this.passIcon = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpCreds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCreds
            // 
            this.grpCreds.Controls.Add(this.txtPassword);
            this.grpCreds.Controls.Add(this.txtUsername);
            this.grpCreds.Controls.Add(this.passIcon);
            this.grpCreds.Controls.Add(this.userIcon);
            this.grpCreds.Location = new System.Drawing.Point(13, 13);
            this.grpCreds.Name = "grpCreds";
            this.grpCreds.Size = new System.Drawing.Size(370, 169);
            this.grpCreds.TabIndex = 0;
            this.grpCreds.TabStop = false;
            this.grpCreds.Text = "Login Credentials";
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
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(68, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(282, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(282, 22);
            this.txtPassword.TabIndex = 3;
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
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogout.BackgroundImage = global::LoginApp.Properties.Resources.logout;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Location = new System.Drawing.Point(97, 188);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(58, 45);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Visible = false;
            // 
            // Login_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.grpCreds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login_App";
            this.Text = "Login Utility";
            this.grpCreds.ResumeLayout(false);
            this.grpCreds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passIcon)).EndInit();
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
    }
}

