using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Syd
{
    class Pathes
    {
        public static string GetUniqueFilePath(string fullPath)
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
