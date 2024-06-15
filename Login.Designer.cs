namespace PetShopManagementSystem
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label1 = new Label();
            txtUser = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPass = new TextBox();
            btnReset = new Label();
            panel2 = new Panel();
            label5 = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 125);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 20);
            label1.Name = "label1";
            label1.Size = new Size(268, 27);
            label1.TabIndex = 0;
            label1.Text = "Pet Shop Management";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(64, 231);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(254, 32);
            txtUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label2.Location = new Point(64, 205);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 2;
            label2.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label3.Location = new Point(64, 284);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(64, 310);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(254, 32);
            txtPass.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.AutoSize = true;
            btnReset.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(160, 427);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(60, 21);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Crimson;
            panel2.Location = new Point(0, 470);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 18);
            panel2.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(137, 145);
            label5.Name = "label5";
            label5.Size = new Size(85, 27);
            label5.TabIndex = 8;
            label5.Text = "Sign In";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 35;
            guna2Elipse1.TargetControl = this;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 10;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.Crimson;
            btnLogin.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Indigo;
            btnLogin.Location = new Point(90, 366);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(196, 36);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(145, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 486);
            Controls.Add(btnLogin);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(btnReset);
            Controls.Add(label3);
            Controls.Add(txtPass);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtUser;
        private Label label2;
        private Label label3;
        private TextBox txtPass;
        private Label btnReset;
        private Panel panel2;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private PictureBox pictureBox1;
    }
}