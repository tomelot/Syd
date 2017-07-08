using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using VideoLibrary;
using TagLib;
using MediaToolkit;
using MediaToolkit.Model;

namespace Syd
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = DownloadAudio("https://www.youtube.com/watch?v=IjV9Q9ujIEI", @"C:\Users\Omer\Downloads");
            ChangeDescription(FileName, "song name","song artist","song album");
        }
        static string DownloadAudio(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string path = dir + @"\" + video.FullName;
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            return MP4toMP3(path);
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
        static string MP4toMP3(string mp4)
        {
            string NewFileName = Path.ChangeExtension(mp4, ".mp3");
            var inputFile = new MediaFile { Filename = mp4 };
            var outputFile = new MediaFile { Filename = NewFileName };
            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile);
            }
            System.IO.File.Delete(mp4);
            return NewFileName;
        }
    }
}
