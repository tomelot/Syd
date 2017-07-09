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
    class Youtube
    {
        static List<YouTubeThumbnail> list = new List<YouTubeThumbnail>();
        public static string DownloadYoutube(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string path = dir + @"\" + video.FullName;
            path = Pathes.GetUniqueFilePath(path);//change file name if already exists
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            return path;
        }
        public static void SearchVideos(Form form,string sch)
        {
            foreach(YouTubeThumbnail a in list)
            {
                a.panel.Visible = false;
            }
            list.Clear();
            int cnt = 0;
            VideoSearch items = new VideoSearch();
            foreach (var item in items.SearchQuery(sch, 1))
            {
                if (cnt == 12)
                    break;
                cnt++;
                YouTubeThumbnail video = new YouTubeThumbnail(form);
                video.label.Text = item.Title+" - "+item.Author;
                video.url = item.Url;
                Byte[] image = new WebClient().DownloadData(item.Thumbnail);
                using(MemoryStream ms=new MemoryStream(image))
                {
                    video.image.Image = Image.FromStream(ms);
                }
                list.Add(video);
            }
        }
        public static void ShowResults(Panel Spanel)
        {
            for(int i = 0; (i < list.Count)&&(i<12); i++)
            {
                list[i].panel.Parent = Spanel;
                list[i].panel.Location = new Point(3+172*(i % 6), 3+156*(i / 6));
            }
        }
    }
}
