using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using YoutubeSearch;
using YoutubePlayer;
using System.Net;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Syd
{
    class YouTubeSearch
    {
        ListView view;
        List<string> URLs;
        Player player;
        public YouTubeSearch(ListView view,Player player)
        {
            this.player = player;
            this.view = view;
            this.view.MouseDoubleClick+= new MouseEventHandler(view_DoubleClick);
            this.URLs = new List<string>();
        }
        
        public static string DownloadYoutube(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string path = dir + @"\" + video.FullName;
            path = Pathes.GetUniqueFilePath(path);//change file name if already exists
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            return path;
        }
        public void SearchVideos(string sch)
        {
            this.view.Clear();
            this.URLs.Clear();
            ImageList Thumbnails = new ImageList();
            Thumbnails.ImageSize = new Size(160, 90);
            Thumbnails.ColorDepth = ColorDepth.Depth16Bit;
            VideoSearch items = new VideoSearch();
            view.LargeImageList = Thumbnails;
            int cnt = 0;
            foreach (var item in items.SearchQuery(sch, 1))
            {
                //show: item.Title;
                //url: item.Url;
                Byte[] image = new WebClient().DownloadData(item.Thumbnail);
                using(MemoryStream ms=new MemoryStream(image))
                {
                    Thumbnails.Images.Add(Image.FromStream(ms));
                    byte[] bytes = Encoding.Default.GetBytes(System.Net.WebUtility.HtmlDecode(item.Title));
                    view.Items.Add(Encoding.UTF8.GetString(bytes), cnt);
                    URLs.Add(item.Url);
                }
                cnt++;
            }
        }
        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count == 1)
            {
                player.PlayURL(URLs[view.SelectedItems[0].Index]);
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
        public static string GetURI(string url)
        {
            try
            {
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(url);
                return video.GetUri();
            }
            catch
            {
                return null;
            }
        }
    }
}
