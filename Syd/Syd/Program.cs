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
<<<<<<< HEAD
            DownloadVideo("https://www.youtube.com/watch?v=xm41dHucxmM", @"D:\projects\Syd");
=======
            DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"D:\projects\Syd");
>>>>>>> tom
        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
<<<<<<< HEAD
            string file = dir + @"\" + video.FullName;
            File.WriteAllBytes(file, video.GetBytes());
            Path.ChangeExtension(file, ".mp3");
=======
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
            File.WriteAllBytes(file, video.GetBytes());
>>>>>>> tom
        }
    }
}
