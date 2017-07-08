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
            string file = DownloadVideo("https://www.youtube.com/watch?v=bv5JcXcI1ic", @"D:\projects\Syd");
            ChangeDescription(file, "song name","song artist","song album");

        }
        static string DownloadVideo(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string file = dir + @"\" + video.FullName;
            System.IO.File.WriteAllBytes(file, video.GetBytes());
            return file;
        }
        static void ChangeDescription(string path,string name, string artist, string album)
        {
            TagLib.File f = TagLib.File.Create(path);
            f.Tag.Album = album;
            f.Tag.Title = name;
            f.Tag.Performers = new string[] { artist };
            f.Save();
            System.IO.File.Move(path, Path.GetDirectoryName(path)+@"\"+name+".mp3");
        }
    }
}
