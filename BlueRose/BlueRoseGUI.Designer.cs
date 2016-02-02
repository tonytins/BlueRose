﻿namespace BlueRose
{
    partial class BlueRoseGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueRoseGUI));
            this.playBtn = new System.Windows.Forms.Button();
            this.devBtn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.fsoLogo = new System.Windows.Forms.PictureBox();
            this.btnUpdateLauncher = new System.Windows.Forms.Button();
            this.localBuild = new System.Windows.Forms.Label();
            this.versionIS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(8, 89);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(50, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // devBtn
            // 
            this.devBtn.Location = new System.Drawing.Point(64, 89);
            this.devBtn.Name = "devBtn";
            this.devBtn.Size = new System.Drawing.Size(60, 23);
            this.devBtn.TabIndex = 1;
            this.devBtn.Text = "Develop";
            this.devBtn.UseVisualStyleBackColor = true;
            this.devBtn.Click += new System.EventHandler(this.devBtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(8, 118);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update to #";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // fsoLogo
            // 
            this.fsoLogo.BackColor = System.Drawing.Color.Transparent;
            this.fsoLogo.Image = ((System.Drawing.Image)(resources.GetObject("fsoLogo.Image")));
            this.fsoLogo.Location = new System.Drawing.Point(8, 9);
            this.fsoLogo.Name = "fsoLogo";
            this.fsoLogo.Size = new System.Drawing.Size(116, 57);
            this.fsoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fsoLogo.TabIndex = 9;
            this.fsoLogo.TabStop = false;
            // 
            // btnUpdateLauncher
            // 
            this.btnUpdateLauncher.Location = new System.Drawing.Point(8, 147);
            this.btnUpdateLauncher.Name = "btnUpdateLauncher";
            this.btnUpdateLauncher.Size = new System.Drawing.Size(116, 23);
            this.btnUpdateLauncher.TabIndex = 10;
            this.btnUpdateLauncher.Text = "Update Launcher";
            this.btnUpdateLauncher.UseVisualStyleBackColor = true;
            this.btnUpdateLauncher.Click += new System.EventHandler(this.btnUpdateLauncher_Click);
            // 
            // localBuild
            // 
            this.localBuild.AutoSize = true;
            this.localBuild.Location = new System.Drawing.Point(85, 73);
            this.localBuild.Name = "localBuild";
            this.localBuild.Size = new System.Drawing.Size(35, 13);
            this.localBuild.TabIndex = 11;
            this.localBuild.Text = "label1";
            this.localBuild.Click += new System.EventHandler(this.localBuild_Click);
            // 
            // versionIS
            // 
            this.versionIS.AutoSize = true;
            this.versionIS.Location = new System.Drawing.Point(5, 73);
            this.versionIS.Name = "versionIS";
            this.versionIS.Size = new System.Drawing.Size(74, 13);
            this.versionIS.TabIndex = 12;
            this.versionIS.Text = "Installed build:";
            this.versionIS.Click += new System.EventHandler(this.versionIS_Click);
            // 
            // BlueRoseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(132, 182);
            this.Controls.Add(this.versionIS);
            this.Controls.Add(this.localBuild);
            this.Controls.Add(this.btnUpdateLauncher);
            this.Controls.Add(this.fsoLogo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.devBtn);
            this.Controls.Add(this.playBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BlueRoseGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Rose";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button devBtn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox fsoLogo;
        private System.Windows.Forms.Button btnUpdateLauncher;
        private System.Windows.Forms.Label localBuild;
        private System.Windows.Forms.Label versionIS;
    }
}
