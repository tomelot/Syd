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
            string path = dir + @"\" + video.FullName;
            path = Pathes.GetUniqueFilePath(path);//change file name if already exists
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            return path;
        }
    }
}
