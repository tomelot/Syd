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
        static List<TcpClient> clients = new List<TcpClient>();
        static void Main(string[] args)
        {
            CreateServer();
            string FileName = DownloadAudio("https://www.youtube.com/watch?v=IjV9Q9ujIEI", @"D:\projects\Syd");
           // ChangeDescription(FileName, "song name","song artist","song album");
            //Console.WriteLine("done");
            //Console.ReadKey();
        }
        static void ServerSendToAll(string data)
        {
            foreach (TcpClient client in clients)
            {
                NetworkStream stream = client.GetStream();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
            }
        }
        static void ServerSendToOne(string data,string clientip)
        {
            foreach (TcpClient client in clients)
            {
                string clientIPAddress = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()).ToString();
                if (clientIPAddress == clientip)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                }
            }
        }
        static void ServerRecive()
        {
            Byte[] bytes = new Byte[256];
            String data = null;
            int i;
            foreach (TcpClient client in clients)
            {
                NetworkStream stream = client.GetStream();
                i = stream.Read(bytes, 0, bytes.Length);
                if (i != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                }
                switch (data.Split(':')[0])
                {

                }
            }
        }
        static void ClientRecive(TcpClient client)
        {
            while (true)
            {
                Byte[] bytes = new Byte[256];
                String data = null;
                int i;
                NetworkStream stream = client.GetStream();
                i = stream.Read(bytes, 0, bytes.Length);
                if (i != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                }
                switch (data.Split(':')[0])
                {

                }
            }
        }
        static void CreateServer()
        {
            Int32 port = 25565;
            IPAddress localAddr = IPAddress.Parse(GetComputer_LanIP());
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            Thread myNewThread = new Thread(() => WaitForClients(server));
            myNewThread.Start();
            Console.WriteLine(GetComputer_InternetIP());
        }
        private static void WaitForClients(TcpListener server)
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("Conected to: " + IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));
            }
        }
        static void ClientConnect()
        {
            String ip = Console.ReadLine();
            TcpClient client = new TcpClient();
            client.Connect(ip, 25565);
           

        }
        static string GetComputer_LanIP()
        {
            string strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return ipAddress.ToString();
                }
            }

            return null;
        }
        static string GetComputer_InternetIP()
        {
            // check IP using DynDNS's service
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // replace everything and keep only IP
            return ipAddress.
                Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).
                Replace("</body></html>", string.Empty);
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
