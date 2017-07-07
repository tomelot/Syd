using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using TagLib;

namespace Syd
{
    class Program
    {
        static void Main(string[] args)
        {

            DownloadVideo("https://www.youtube.com/watch?v=bv5JcXcI1ic", @"D:\projects\Syd");
        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".wav");
            System.IO.File.WriteAllBytes(file, video.GetBytes());

        }
    }
}
