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
            DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"D:\projects\Syd");
        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
<<<<<<< HEAD
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
            File.WriteAllBytes(file, video.GetBytes());
            Console.WriteLine("tom");
            Console.WriteLine("omer");
=======
            string file = dir + @"\" + video.FullName;
            File.WriteAllBytes(file, video.GetBytes());
            Path.ChangeExtension(file, ".mp3");
>>>>>>> omer
        }
    }
}
