using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubePlayer
{
    class Convertor
    {
        public static string MP4toMP3(string mp4)
        {
            string NewFileName = Path.ChangeExtension(mp4, ".mp3");
            NewFileName = Pathes.GetUniqueFilePath(NewFileName);//change file name if already exists
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
