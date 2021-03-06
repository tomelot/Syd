﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubePlayer
{
    class Player
    {
        public bool IsPlaying = false;
        bool video = false;
        AxWMPLib.AxWindowsMediaPlayer player;
        Button play;
        TrackBar TimeBar;
        Label Time;
        Label FullTime;
        Timer UpdateTimeBar;
        Button labelAudio;
        TrackBar AudioLevel;
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
        public Player(AxWMPLib.AxWindowsMediaPlayer player, Button play, TrackBar TimeBar, Label Time, Label FullTime)
        {
            this.player = player;
            this.play = play;
            this.TimeBar = TimeBar;
            this.Time = Time;
            this.FullTime = FullTime;
            this.labelAudio = labelAudio;
            this.AudioLevel = AudioLevel;
            UpdateTimeBar = new Timer();
            this.player.uiMode = "none";
            IsVideo = false;
            //add events
            this.player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);
            this.TimeBar.MouseUp += new MouseEventHandler(TimeBar_MouseUp);
            this.TimeBar.MouseDown += new MouseEventHandler(TimeBar_MouseDown);
            this.TimeBar.Scroll += new EventHandler(TimeBar_Scroll);
            this.UpdateTimeBar.Tick += new EventHandler(UpdateTimeBar_Tick);
            this.play.Click += new EventHandler(play_Click);
        }

        //state of player changed
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
        private void labelAudio_MouseHover(object sender, EventArgs e)
        {
            AudioLevel.Visible = true;
        }
        private void AudioLevel_MouseLeave(object sender, EventArgs e)
        {
            AudioLevel.Visible = false;
        }
        private void TimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            player.Ctlcontrols.currentPosition = TimeBar.Value;
            UpdateTimeBar.Enabled = true;
            Play();
            TimeWasChanged(TimeBar.Value);
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
            Time.Text = SecToStr((int)(player.Ctlcontrols.currentPosition));
            TimeBar.Value = (int)(player.Ctlcontrols.currentPosition);
        }

        //functions
        
        public void PlayURL(string url)
        {
            var youTube = YouTube.Default;
            try
            {
                var video = youTube.GetVideo(url);
                player.URL = video.GetUri();
                IsVideo = false;
                URLWasChanged(video.GetUri());
            }
            catch
            {
                MessageBox.Show("We think theres an error in your YouTube URL!");
            }
        }

        

        void TimeWasChanged(int TimeNow)
        {

        }
        void ChangeTimeTo(int time)//in seconds
        {
            player.Ctlcontrols.currentPosition = time;
            Time.Text = SecToStr(time);
            TimeBar.Value = time;
        }
        void Play()
        {
            player.Ctlcontrols.play();
            IsPlaying = true;
            play.Text = "❙❙";
            UpdateTimeBar.Enabled = true;
            

            //send to server play
        }
        void Stop()
        {
            player.Ctlcontrols.pause();
            IsPlaying = false;
            play.Text = "▶";
            UpdateTimeBar.Enabled = false;

            //send to server stop
        }

        void URLWasChanged(string url)
        {

        }



        string SecToStr(int seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
        }
    }
}
