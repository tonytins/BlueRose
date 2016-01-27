namespace BlueRose
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playBtn = new System.Windows.Forms.Button();
            this.devBtn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.fsoLogo = new System.Windows.Forms.PictureBox();
            this.btnUpdateLauncher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(110, 6);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(43, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // devBtn
            // 
            this.devBtn.Location = new System.Drawing.Point(159, 6);
            this.devBtn.Name = "devBtn";
            this.devBtn.Size = new System.Drawing.Size(58, 23);
            this.devBtn.TabIndex = 1;
            this.devBtn.Text = "Develop";
            this.devBtn.UseVisualStyleBackColor = true;
            this.devBtn.Click += new System.EventHandler(this.devBtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(110, 35);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Get build #";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // fsoLogo
            // 
            this.fsoLogo.BackColor = System.Drawing.Color.Transparent;
            this.fsoLogo.Image = ((System.Drawing.Image)(resources.GetObject("fsoLogo.Image")));
            this.fsoLogo.Location = new System.Drawing.Point(12, 6);
            this.fsoLogo.Name = "fsoLogo";
            this.fsoLogo.Size = new System.Drawing.Size(92, 81);
            this.fsoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fsoLogo.TabIndex = 9;
            this.fsoLogo.TabStop = false;
            // 
            // btnUpdateLauncher
            // 
            this.btnUpdateLauncher.Location = new System.Drawing.Point(110, 64);
            this.btnUpdateLauncher.Name = "btnUpdateLauncher";
            this.btnUpdateLauncher.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateLauncher.TabIndex = 10;
            this.btnUpdateLauncher.Text = "Update Launcher";
            this.btnUpdateLauncher.UseVisualStyleBackColor = true;
            this.btnUpdateLauncher.Click += new System.EventHandler(this.btnUpdateLauncher_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(225, 97);
            this.Controls.Add(this.btnUpdateLauncher);
            this.Controls.Add(this.fsoLogo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.devBtn);
            this.Controls.Add(this.playBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Rose";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button devBtn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox fsoLogo;
        private System.Windows.Forms.Button btnUpdateLauncher;
    }
}

