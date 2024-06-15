namespace PetShopManagementSystem
{
    partial class Splash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            loadPercent = new Label();
            label3 = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            myProcess = new Guna.UI2.WinForms.Guna2ProgressBar();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 190);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 53);
            label1.Name = "label1";
            label1.Size = new Size(427, 34);
            label1.TabIndex = 2;
            label1.Text = "Pet Shop Management System";
            // 
            // loadPercent
            // 
            loadPercent.AutoSize = true;
            loadPercent.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadPercent.Location = new Point(263, 120);
            loadPercent.Name = "loadPercent";
            loadPercent.Size = new Size(44, 23);
            loadPercent.TabIndex = 3;
            loadPercent.Text = "%%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(165, 206);
            label3.Name = "label3";
            label3.Size = new Size(153, 21);
            label3.TabIndex = 4;
            label3.Text = "Loading Modules";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 35;
            guna2Elipse1.TargetControl = this;
            // 
            // myProcess
            // 
            myProcess.BorderRadius = 8;
            myProcess.CustomizableEdges = customizableEdges1;
            myProcess.Location = new Point(166, 240);
            myProcess.Name = "myProcess";
            myProcess.ShadowDecoration.CustomizableEdges = customizableEdges2;
            myProcess.Size = new Size(375, 20);
            myProcess.TabIndex = 5;
            myProcess.Text = "guna2ProgressBar1";
            myProcess.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(572, 307);
            Controls.Add(myProcess);
            Controls.Add(label3);
            Controls.Add(loadPercent);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Splash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label loadPercent;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ProgressBar myProcess;
        private System.Windows.Forms.Timer timer;
    }
}
