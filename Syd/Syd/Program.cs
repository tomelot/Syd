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
using System.Net.Sockets;


namespace Syd
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=Youtube.DownloadYoutube("link", "path");
            path=Convertor.MP4toMP3(path);
            Description.ChangeDescription(path,"name","art","album");
        }

     
    }
}
