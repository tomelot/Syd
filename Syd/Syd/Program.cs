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
            file=DownloadVideo("https://www.youtube.com/watch?v=IjV9Q9ujIEI", @"C:\Users\Omer\Downloads");
            //Console.WriteLine(file);
            //ChangeDescription(file, "omern","3124","12312");

        }
        static string DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".wav");
            file = Path.ChangeExtension(file, ".mp3");
            System.IO.File.WriteAllBytes(file, video.GetBytes());
            return file;
        }
        static void ChangeDescription(string path,string name, string artist, string album)
        {
            TagLib.File f = TagLib.File.Create(path);
            //f.Tag.Performers = new string[] { artist };
            //f.Save();
            //System.IO.File.Move(dir, Path.GetDirectoryName(dir)+name+".mp3");
        }
    }
}
