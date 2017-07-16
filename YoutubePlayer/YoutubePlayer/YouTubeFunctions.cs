using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YoutubeSearch;
using System.Net;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace YoutubePlayer
{
    class YouTubeSearch
    {
        ListView view;
        List<string> URLs;
        Player player;
        public YouTubeSearch(ListView view, Player player)
        {
            this.player = player;
            this.view = view;
            this.view.MouseDoubleClick += new MouseEventHandler(view_DoubleClick);
            this.URLs = new List<string>();
        }
        public void SearchVideos(string sch)
        {
            this.view.Clear();
            this.URLs.Clear();
            List<object> input = new List<object>();
            input.Add(view);
            input.Add(URLs);
            input.Add(sch);
            BackgroundWorker SY = new BackgroundWorker();
            SY.DoWork += new DoWorkEventHandler(SY_DoWork);
            SY.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SY_Complete);
            SY.RunWorkerAsync(input);
        }
        private static void SY_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> input = e.Argument as List<object>;
            ListView view = input[0] as ListView;
            List<string> URLs = input[1] as List<string>;
            string sch = input[2] as string;
            List<string> Label = new List<string>();
            ImageList Thumbnails = new ImageList();
            Thumbnails.ImageSize = new Size(160, 90);
            Thumbnails.ColorDepth = ColorDepth.Depth32Bit;
            VideoSearch items = new VideoSearch();
            foreach (var item in items.SearchQuery(sch, 2))
            {
                //show: item.Title;
                //url: item.Url;
                Byte[] image = new WebClient().DownloadData(item.Thumbnail);
                using (MemoryStream ms = new MemoryStream(image))
                {
                    Thumbnails.Images.Add(Image.FromStream(ms));
                    byte[] bytes = Encoding.Default.GetBytes(System.Net.WebUtility.HtmlDecode(item.Title));
                    Label.Add(Encoding.UTF8.GetString(bytes));
                    URLs.Add(item.Url);
                }

            }
            input.Add(Thumbnails);
            input.Add(Label);
            e.Result = input;
        }
        private static void SY_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            List<object> input = e.Result as List<object>;
            ListView view = input[0] as ListView;
            ImageList Thumbnails = input[3] as ImageList;
            List<string> Label = input[4] as List<string>;
            view.LargeImageList = Thumbnails;
            for (int i = 0; i < Label.Count; i++)
            {
                view.Items.Add(Label[i], i);
            }
        }
        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count == 1)
            {
                YouTubeSearch.PlayURL(URLs[view.SelectedItems[0].Index],player.player);
            }
        }
        public static bool IsURL(string url)
        {
            var youTube = YouTube.Default;
            try
            {
                var video = youTube.GetVideo(url);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SerchAndPlay(string url, AxWMPLib.AxWindowsMediaPlayer player, YouTubeSearch view)
        {
            List<object> input = new List<object>();
            input.Add(url);
            input.Add(player);
            input.Add(view);
            BackgroundWorker SAP = new BackgroundWorker();
            SAP.DoWork += new DoWorkEventHandler(SAP_DoWork);
            SAP.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SAP_Complete);
            SAP.RunWorkerAsync(input);
        }
        private static void SAP_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> input = new List<object>();
            input = e.Argument as List<object>;
            string sch = input[0] as string;
            AxWMPLib.AxWindowsMediaPlayer player = input[1] as AxWMPLib.AxWindowsMediaPlayer;
            YouTubeSearch view = input[2] as YouTubeSearch;
            if (YouTubeSearch.IsURL(sch))
            {
                YouTubeSearch.PlayURL(sch, player);
                e.Result = input;
            }
            else
            {
                input[1] = null;
                e.Result = input;
            }
        }
        private static void SAP_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            List<object> input = new List<object>();
            input = e.Result as List<object>;
            string sch = input[0] as string;
            AxWMPLib.AxWindowsMediaPlayer player = input[1] as AxWMPLib.AxWindowsMediaPlayer;
            YouTubeSearch view = input[2] as YouTubeSearch;
            if (player == null)
            {
                view.SearchVideos(sch);
            }
        }
        public static void PlayURL(string url,AxWMPLib.AxWindowsMediaPlayer player)
        {
            List<object> input = new List<object>();
            input.Add(url);
            input.Add(player);
            BackgroundWorker URI = new BackgroundWorker();
            URI.DoWork += new DoWorkEventHandler(URI_DoWork);
            URI.RunWorkerCompleted += new RunWorkerCompletedEventHandler(URI_Complete);
            URI.RunWorkerAsync(input);
        }
        private static void URI_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> input = new List<object>();
            input = e.Argument as List<object>;
            string url = input[0] as string;
            
            try
            {
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(url);
                input[0] = video.GetUri();
            }
            catch
            {
                input[0] = null;
            }
            e.Result = input;
        }
        private static void URI_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            List<object> input = new List<object>();
            input = e.Result as List<object>;
            string url = input[0] as string;
            AxWMPLib.AxWindowsMediaPlayer player = input[1] as AxWMPLib.AxWindowsMediaPlayer;
            player.URL = url;
        }
    }
}
