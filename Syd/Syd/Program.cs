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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Syd
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string FileName = DownloadAudio("https://www.youtube.com/watch?v=IjV9Q9ujIEI", @"D:\projects\Syd");
           // ChangeDescription(FileName, "song name","song artist","song album");
            //Console.WriteLine("done");
            //Console.ReadKey();
        }
       
        //Download video from YouTube and convert it to mp3
        static string DownloadAudio(string link, string dir)
        {
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            string path = dir + @"\" + video.FullName;
            Console.WriteLine("Downloading video: "+video.FullName);
            path = GetUniqueFilePath(path);//change file name if already exists
            System.IO.File.WriteAllBytes(path, video.GetBytes());
            Console.WriteLine("Converting to MP3");
            return MP4toMP3(path);
        }

        //Change some attributes of the mp3 file 
        static void ChangeDescription(string path,string name, string artist, string album)
        {
            string NewFileName= Path.GetDirectoryName(path) + @"\" + name + ".mp3";
            Console.WriteLine("Updating description");
            TagLib.File f = TagLib.File.Create(path);
            f.Tag.Album = album;
            f.Tag.Title = name;
            f.Tag.Performers = new string[] { artist };
            f.Save();
            NewFileName = GetUniqueFilePath(NewFileName);//change file name if already exists
            System.IO.File.Move(path, NewFileName);
        }

        //Convert mp4 file to mp3 file
        static string MP4toMP3(string mp4)
        {
            string NewFileName = Path.ChangeExtension(mp4, ".mp3");
            NewFileName = GetUniqueFilePath(NewFileName);//change file name if already exists
            var inputFile = new MediaFile { Filename = mp4 };
            var outputFile = new MediaFile { Filename = NewFileName };
            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile);
            }
            System.IO.File.Delete(mp4);
            return NewFileName;
        }

        //copied from internet for now
        //Incresses number between ( ) until it finds file name that doesn't exist
        static string GetUniqueFilePath(string fullPath)
        {
            if (System.IO.File.Exists(fullPath))
            {
                string folder = Path.GetDirectoryName(fullPath);
                string filename = Path.GetFileNameWithoutExtension(fullPath);
                string extension = Path.GetExtension(fullPath);
                int number = 1;
                Match regex = Regex.Match(fullPath, @"(.+) \((\d+)\)\.\w+");
                if (regex.Success)
                {
                    filename = regex.Groups[1].Value;
                    number = int.Parse(regex.Groups[2].Value);
                }
                do
                {
                    number++;
                    fullPath = Path.Combine(folder, string.Format("{0} ({1}){2}", filename, number, extension));
                }
                while (System.IO.File.Exists(fullPath));
            }
            return fullPath;
        }
    }
}
