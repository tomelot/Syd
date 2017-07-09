namespace YoutubePlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.URLtb = new System.Windows.Forms.TextBox();
            this.Navigate = new System.Windows.Forms.Button();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.play = new System.Windows.Forms.Button();
            this.FullTime = new System.Windows.Forms.Label();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.UpdateTimeBar = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.slash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // URLtb
            // 
            this.URLtb.Location = new System.Drawing.Point(12, 407);
            this.URLtb.Name = "URLtb";
            this.URLtb.Size = new System.Drawing.Size(569, 20);
            this.URLtb.TabIndex = 1;
            this.URLtb.Text = "https://www.youtube.com/watch?v=yg-MFXf0UKs";
            // 
            // Navigate
            // 
            this.Navigate.Location = new System.Drawing.Point(587, 406);
            this.Navigate.Name = "Navigate";
            this.Navigate.Size = new System.Drawing.Size(65, 23);
            this.Navigate.TabIndex = 2;
            this.Navigate.Text = "Go";
            this.Navigate.UseVisualStyleBackColor = true;
            this.Navigate.Click += new System.EventHandler(this.Navigate_Click);
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(12, 12);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(640, 360);
            this.player.TabIndex = 3;
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(12, 378);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 23);
            this.play.TabIndex = 5;
            this.play.Text = "▶";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // FullTime
            // 
            this.FullTime.AutoSize = true;
            this.FullTime.Location = new System.Drawing.Point(603, 383);
            this.FullTime.Name = "FullTime";
            this.FullTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FullTime.Size = new System.Drawing.Size(49, 13);
            this.FullTime.TabIndex = 7;
            this.FullTime.Text = "00:00:00";
            this.FullTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeBar
            // 
            this.TimeBar.LargeChange = 0;
            this.TimeBar.Location = new System.Drawing.Point(41, 378);
            this.TimeBar.Maximum = 100;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(501, 45);
            this.TimeBar.SmallChange = 0;
            this.TimeBar.TabIndex = 9;
            this.TimeBar.TickFrequency = 0;
            this.TimeBar.Scroll += new System.EventHandler(this.TimeBar_Scroll);
            // 
            // UpdateTimeBar
            // 
            this.UpdateTimeBar.Interval = 1000;
            this.UpdateTimeBar.Tick += new System.EventHandler(this.UpdateTimeBar_Tick);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(548, 383);
            this.Time.Name = "Time";
            this.Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Time.Size = new System.Drawing.Size(49, 13);
            this.Time.TabIndex = 10;
            this.Time.Text = "00:00:00";
            this.Time.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // slash
            // 
            this.slash.AutoSize = true;
            this.slash.Location = new System.Drawing.Point(594, 383);
            this.slash.Name = "slash";
            this.slash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.slash.Size = new System.Drawing.Size(12, 13);
            this.slash.TabIndex = 11;
            this.slash.Text = "/";
            this.slash.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 448);
            this.Controls.Add(this.slash);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.FullTime);
            this.Controls.Add(this.play);
            this.Controls.Add(this.player);
            this.Controls.Add(this.Navigate);
            this.Controls.Add(this.URLtb);
            this.Controls.Add(this.TimeBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox URLtb;
        private System.Windows.Forms.Button Navigate;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label FullTime;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.Timer UpdateTimeBar;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label slash;
    }
}

