using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlayer
{
    class Description
    {
        public static void ChangeDescription(string path, string name, string artist, string album)
        {
            string NewFileName = Path.GetDirectoryName(path) + @"\" + name + ".mp3";
            Console.WriteLine("Updating description");
            TagLib.File f = TagLib.File.Create(path);
            f.Tag.Album = album;
            f.Tag.Title = name;
            f.Tag.Performers = new string[] { artist };
            f.Save();
            NewFileName = Pathes.GetUniqueFilePath(NewFileName);//change file name if already exists
            System.IO.File.Move(path, NewFileName);
        }
    }
}
