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
<<<<<<< HEAD
            DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"D:\projects\Syd");
=======
            DownloadVideo("https://www.youtube.com/watch?v=xm41dHucxmM", @"C:\Users\Omer\Downloads");
>>>>>>> 01a5b3fcf78547547172ca9d29468c68ca457feb
        }
        static void DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
<<<<<<< HEAD
            file = Path.ChangeExtension(file, ".mp3");
            File.WriteAllBytes(file, video.GetBytes());
=======
            System.IO.File.WriteAllBytes(file, video.GetBytes());
            Path.ChangeExtension(file, ".mp3");
>>>>>>> 01a5b3fcf78547547172ca9d29468c68ca457feb
        }
    }
}
