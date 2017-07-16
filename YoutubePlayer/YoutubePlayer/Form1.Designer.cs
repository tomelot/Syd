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
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.URLtb = new System.Windows.Forms.TextBox();
            this.Navigate = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.FullTime = new System.Windows.Forms.Label();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.UpdateTimeBar = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.slash = new System.Windows.Forms.Label();
            this.AudioLevel = new System.Windows.Forms.TrackBar();
            this.buttonAudio = new System.Windows.Forms.Button();
            this.ViewSearch = new System.Windows.Forms.ListView();
            this.VideoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.URL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YouTubeImageList = new System.Windows.Forms.ImageList(this.components);
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // URLtb
            // 
            this.URLtb.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
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
            // play
            // 
            this.play.Location = new System.Drawing.Point(12, 378);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 23);
            this.play.TabIndex = 5;
            this.play.Text = "▶";
            this.play.UseVisualStyleBackColor = true;
            // 
            // FullTime
            // 
            this.FullTime.AutoSize = true;
            this.FullTime.Location = new System.Drawing.Point(552, 383);
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
            this.TimeBar.Size = new System.Drawing.Size(450, 45);
            this.TimeBar.SmallChange = 0;
            this.TimeBar.TabIndex = 9;
            this.TimeBar.TickFrequency = 0;
            // 
            // UpdateTimeBar
            // 
            this.UpdateTimeBar.Enabled = true;
            this.UpdateTimeBar.Interval = 1000;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(497, 383);
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
            this.slash.Location = new System.Drawing.Point(543, 383);
            this.slash.Name = "slash";
            this.slash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.slash.Size = new System.Drawing.Size(12, 13);
            this.slash.TabIndex = 11;
            this.slash.Text = "/";
            this.slash.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AudioLevel
            // 
            this.AudioLevel.LargeChange = 0;
            this.AudioLevel.Location = new System.Drawing.Point(607, 314);
            this.AudioLevel.Maximum = 5;
            this.AudioLevel.Name = "AudioLevel";
            this.AudioLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.AudioLevel.Size = new System.Drawing.Size(45, 86);
            this.AudioLevel.TabIndex = 12;
            this.AudioLevel.Value = 3;
            this.AudioLevel.Visible = false;
            // 
            // buttonAudio
            // 
            this.buttonAudio.Location = new System.Drawing.Point(607, 378);
            this.buttonAudio.Name = "buttonAudio";
            this.buttonAudio.Size = new System.Drawing.Size(45, 23);
            this.buttonAudio.TabIndex = 14;
            this.buttonAudio.Text = "🔊";
            this.buttonAudio.UseVisualStyleBackColor = true;
            // 
            // ViewSearch
            // 
            this.ViewSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VideoName,
            this.URL});
            this.ViewSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup1";
            listViewGroup5.Header = "ListViewGroup";
            listViewGroup5.Name = "listViewGroup2";
            listViewGroup6.Header = "ListViewGroup";
            listViewGroup6.Name = "listViewGroup3";
            this.ViewSearch.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.ViewSearch.LargeImageList = this.YouTubeImageList;
            this.ViewSearch.Location = new System.Drawing.Point(12, 433);
            this.ViewSearch.MultiSelect = false;
            this.ViewSearch.Name = "ViewSearch";
            this.ViewSearch.Size = new System.Drawing.Size(867, 317);
            this.ViewSearch.TabIndex = 16;
            this.ViewSearch.UseCompatibleStateImageBehavior = false;
            // 
            // VideoName
            // 
            this.VideoName.Text = "Video Name";
            // 
            // URL
            // 
            this.URL.Text = "URL";
            // 
            // YouTubeImageList
            // 
            this.YouTubeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("YouTubeImageList.ImageStream")));
            this.YouTubeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.YouTubeImageList.Images.SetKeyName(0, "AutoSave_5258b_7e123800_2e7aa1d.png");
            this.YouTubeImageList.Images.SetKeyName(1, "AutoSave_5258b_7e123800_2f7b261.png");
            this.YouTubeImageList.Images.SetKeyName(2, "AutoSave_5258b_7e123800_32d8e67.png");
            this.YouTubeImageList.Images.SetKeyName(3, "AutoSave_5258b_7e123800_30279ff.png");
            this.YouTubeImageList.Images.SetKeyName(4, "AutoSave_52581_7e05e800_34b1b00.png");
            this.YouTubeImageList.Images.SetKeyName(5, "AutoSave_52581_7e05e800_360ec0a.png");
            this.YouTubeImageList.Images.SetKeyName(6, "CheckPoint_5258b_7e123800_31d8cea.png");
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(12, 12);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(640, 360);
            this.player.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 776);
            this.Controls.Add(this.AudioLevel);
            this.Controls.Add(this.player);
            this.Controls.Add(this.ViewSearch);
            this.Controls.Add(this.buttonAudio);
            this.Controls.Add(this.slash);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.FullTime);
            this.Controls.Add(this.play);
            this.Controls.Add(this.Navigate);
            this.Controls.Add(this.URLtb);
            this.Controls.Add(this.TimeBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Navigate;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label FullTime;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.Timer UpdateTimeBar;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label slash;
        private System.Windows.Forms.TrackBar AudioLevel;
        private System.Windows.Forms.Button buttonAudio;
        private System.Windows.Forms.ListView ViewSearch;
        private System.Windows.Forms.ImageList YouTubeImageList;
        private System.Windows.Forms.TextBox URLtb;
        private System.Windows.Forms.ColumnHeader VideoName;
        private System.Windows.Forms.ColumnHeader URL;
        private AxWMPLib.AxWindowsMediaPlayer player;
    }
}

