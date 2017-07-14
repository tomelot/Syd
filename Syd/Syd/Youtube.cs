using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Syd
{
    class Youtube
    {
        public static string DownloadYoutube(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string NewName = video.FullName;
            string path = dir + @"\" + NewName;
            path = Pathes.GetUniqueFilePath(path);//change file name if already exists
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            return path;
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
