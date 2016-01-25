namespace BlueRoseWinForms
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
            this.btnAbout = new System.Windows.Forms.Button();
            this.fsoLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(137, 3);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // devBtn
            // 
            this.devBtn.Location = new System.Drawing.Point(137, 32);
            this.devBtn.Name = "devBtn";
            this.devBtn.Size = new System.Drawing.Size(75, 23);
            this.devBtn.TabIndex = 1;
            this.devBtn.Text = "Develop";
            this.devBtn.UseVisualStyleBackColor = true;
            this.devBtn.Click += new System.EventHandler(this.devBtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(136, 79);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(136, 108);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // fsoLogo
            // 
            this.fsoLogo.Image = ((System.Drawing.Image)(resources.GetObject("fsoLogo.Image")));
            this.fsoLogo.Location = new System.Drawing.Point(11, 4);
            this.fsoLogo.Name = "fsoLogo";
            this.fsoLogo.Size = new System.Drawing.Size(120, 127);
            this.fsoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fsoLogo.TabIndex = 9;
            this.fsoLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(223, 138);
            this.Controls.Add(this.fsoLogo);
            this.Controls.Add(this.btnAbout);
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
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.PictureBox fsoLogo;
    }
}

