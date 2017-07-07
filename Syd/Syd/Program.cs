using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using TagLib;
<<<<<<< HEAD
=======

>>>>>>> tom
namespace Syd
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
=======
            string file;
            file=DownloadVideo("https://www.youtube.com/watch?v=xm41dHucxmM", @"C:\Users\Omer\Downloads");
            System.IO.File.Move(file, Path.GetDirectoryName(file) + "dick" + ".mp3");
            Console.WriteLine(file);
            ChangeDescription(file);
>>>>>>> tom

        }
        static string DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
<<<<<<< HEAD
            Console.WriteLine("got");
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
            File.WriteAllBytes(file, video.GetBytes());
            Console.WriteLine(video.Stream().ReadByte().ToString());
=======
            string file = dir + @"\" + video.FullName;
            file = Path.ChangeExtension(file, ".mp3");
            System.IO.File.WriteAllBytes(file, video.GetBytes());
            return file;
        }
        static void ChangeDescription(string path)
        {
            TagLib.File f = TagLib.File.Create(path);
            f.Tag.Album = "omer";
            //file.Tag.Performers = new string[] { artist };
            f.Save();
            //System.IO.File.Move(dir, Path.GetDirectoryName(dir)+name+".mp3");
>>>>>>> tom
        }
    }
}
