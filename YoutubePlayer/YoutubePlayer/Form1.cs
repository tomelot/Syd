using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubePlayer
{
    public partial class Form1 : Form
    {
        bool IsPlaying = false;
        bool video = false;
        public bool IsVideo
        {
            get { return video; }
            set
            {
                video = value;
                TimeBar.Enabled = value;
                play.Enabled = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Navigate_Click(object sender, EventArgs e)
        {
            
            var youTube = YouTube.Default;
            try
            {
                var video = youTube.GetVideo(URLtb.Text);
                player.URL = video.GetUri();
                IsVideo = false;
            }
            catch
            {
                MessageBox.Show("We think theres an error in your YouTube URL!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.uiMode = "none";
            player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);
            TimeBar.MouseUp += new MouseEventHandler(TimeBar_MouseUp);
            TimeBar.MouseDown += new MouseEventHandler(TimeBar_MouseDown);
            IsVideo = false;

        }
        private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)//play
            {
                if (!IsVideo)
                {
                    FullTime.Text = SecToStr((int)player.currentMedia.duration);
                    TimeBar.Maximum = (int)(player.currentMedia.duration);
                    IsVideo = true;
                    Play();
                }
            }
            else if (e.newState == 1)//stopped
            {
                IsPlaying = false;
                play.Text = "▶";
            }
        }
        
        private void play_Click(object sender, EventArgs e)
        {
            if (IsPlaying)
                Stop();
            else
                Play();
        }

        private void TimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            player.Ctlcontrols.currentPosition = TimeBar.Value;
            UpdateTimeBar.Enabled = true;
            Play();
        }

        private void TimeBar_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateTimeBar.Enabled = false;
        }

        private void TimeBar_Scroll(object sender, EventArgs e)
        {
            Time.Text = SecToStr(TimeBar.Value);
        }

        private void UpdateTimeBar_Tick(object sender, EventArgs e)
        {
            Time.Text = SecToStr((int)(player.Ctlcontrols.currentPosition)) ;
            TimeBar.Value = (int)(player.Ctlcontrols.currentPosition);
        }

        void Play()
        {
            player.Ctlcontrols.play();
            IsPlaying = true;
            play.Text = "❙❙";
            UpdateTimeBar.Enabled = true;
        }
        void Stop()
        {
            player.Ctlcontrols.pause();
            IsPlaying = false;
            play.Text = "▶";
            UpdateTimeBar.Enabled = false;
        }


        string SecToStr(int seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
        }
    }
}
