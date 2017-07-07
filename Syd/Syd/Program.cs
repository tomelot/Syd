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
            DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"D:\projects\Syd");
=======
            DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"C:\Users\Omer\Downloads");
>>>>>>> omer
        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
<<<<<<< HEAD
            File.WriteAllBytes(file, video.GetBytes());
            Console.WriteLine("tom");
            Console.WriteLine("omer");
=======
            System.IO.File.WriteAllBytes(file, video.GetBytes());
>>>>>>> omer
        }
    }
}
