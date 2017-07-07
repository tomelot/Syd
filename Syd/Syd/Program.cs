using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Syd
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string file = dir + @"\" + video.FullName;
            File.WriteAllBytes(file, video.GetBytes());
            Path.ChangeExtension(file, ".mp3");

        }
    }
}
