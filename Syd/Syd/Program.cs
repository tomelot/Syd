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
            string file;
            file=DownloadVideo("https://www.youtube.com/watch?v=0KSOMA3QBU0&list=PLMC9KNkIncKtPzgY-5rmhvj7fax8fdxoj", @"C:\Users\Omer\Downloads");


        }
        static string DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
            System.IO.File.WriteAllBytes(file, video.GetBytes());
            return file;
        static void ChangeDescription(string dir, string artist, string album, string name)
        {
            TagLib.File file = TagLib.File.Create(dir);
            file.Tag.Album = album;
            file.Tag.Performers = new string[] { artist };
            System.IO.File.Move(dir, Path.GetDirectoryName(dir)+name+".mp3");
        }
    }
}
