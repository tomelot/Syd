using System;
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
        public AxAXVLC.AxVLCPlugin2 player;
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
        public Player(AxAXVLC.AxVLCPlugin2 player, Button play, TrackBar TimeBar, Label Time, Label FullTime, Button labelAudio, TrackBar AudioLevel)
        {
            this.player = player;
            this.play = play;
            this.TimeBar = TimeBar;
            this.Time = Time;
            this.FullTime = FullTime;
            this.labelAudio = labelAudio;
            this.AudioLevel = AudioLevel;
            UpdateTimeBar = new Timer();
            UpdateTimeBar.Enabled = true;
            this.player.CtlVisible = false;
            IsVideo = false;
            //add events
            this.TimeBar.MouseUp += new MouseEventHandler(TimeBar_MouseUp);
            this.TimeBar.MouseDown += new MouseEventHandler(TimeBar_MouseDown);
            this.TimeBar.Scroll += new EventHandler(TimeBar_Scroll);
            this.AudioLevel.Scroll += new EventHandler(AudioLevel_Scroll);
            this.UpdateTimeBar.Tick += new EventHandler(UpdateTimeBar_Tick);
            this.play.Click += new EventHandler(play_Click);
            this.labelAudio.Click += new EventHandler(labelAudio_Click);
            this.AudioLevel.MouseLeave += new EventHandler(AudioLevel_MouseLeave);
        }


        private void play_Click(object sender, EventArgs e)
        {
            if (IsPlaying)
                Stop();
            else
                Play();
        }
        private void labelAudio_Click(object sender, EventArgs e)
        {
            AudioLevel.Visible = true;
        }
        private void AudioLevel_MouseLeave(object sender, EventArgs e)
        {
            AudioLevel.Visible = false;
        }
        private void AudioLevel_Scroll(object sender, EventArgs e)
        {
            player.volume = AudioLevel.Value * 20;
        }
        private void TimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            player.input.time = TimeBar.Value*1000;
            Play();
            TimeWasChanged(TimeBar.Value);
            UpdateTimeBar.Enabled = true;
        }
        private void TimeBar_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateTimeBar.Enabled = false;
            double width = TimeBar.Width-16;
            double max = TimeBar.Maximum;
            double mx = e.X-8;
            TimeBar.Value = (int)Math.Round(mx / (width / max));
        }

        private void TimeBar_Scroll(object sender, EventArgs e)
        {
            Time.Text = SecToStr(TimeBar.Value);
        }
        private void UpdateTimeBar_Tick(object sender, EventArgs e)
        {
            if (IsVideo)
            {
                Time.Text = SecToStr((int)(player.input.time / 1000));
                TimeBar.Value = (int)(player.input.time / 1000);
            }
            else
            {
                if (player.input.length>0)
                {
                    FullTime.Text = SecToStr((int)player.input.length / 1000);
                    TimeBar.Maximum = (int)(player.input.length / 1000);
                    IsVideo = true;
                    Play();
                }
            }
        }
        //functions

        public void SearchThis(Syd.YouTubeSearch view,string sch)
        {

            if (Syd.YouTubeSearch.IsURL(sch))
            {
                PlayURL(sch);
            }
            else
            {
                view.SearchVideos(sch);
            }
        }

        public void PlayURL(string url)
        {
            URLWasChanged(url);
            
            player.playlist.add(url);
            player.playlist.playItem(player.playlist.itemCount-1);
            Play();
        }

        

        void TimeWasChanged(int TimeNow)
        {

        }
        void ChangeTimeTo(int time)//in seconds
        {
            player.input.time = time;
            Time.Text = SecToStr(time);
            TimeBar.Value = time;
        }
        void Play()
        {
            player.playlist.play();
            IsPlaying = true;
            play.Text = "❙❙";

            //send to server play
        }
        void Stop()
        {
            player.playlist.pause();
            IsPlaying = false;
            play.Text = "▶";

            //send to server stop
        }

        void URLWasChanged(string url)
        {
            IsVideo = false;
            Stop();
            player.playlist.stop();
        }



        string SecToStr(int seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
        }
    }
}
