using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace YoutubePlayer
{
    class Client
    {
        public Networking NetFunctions = new Networking();
        Thread myNewThread;
        TcpClient client;
        bool sending = false;
        public Client(String ip)
        {
            try
            {
                IPAddress tryip = IPAddress.Parse(ip);
                Int32 port = 25565;
                NetFunctions.PortForAsync(port);
                var client = new TcpClient();
                client.Connect(ip, port);
                myNewThread = new Thread(() => ClientLooper(ip));
                myNewThread.Start();
            }
            catch
            {

            }
        }

        public void Clientstop()
        {
            try
            {
                client.Close();
                myNewThread.Abort();
            }
            catch { }
        }

        private void ClientLooper(string ip)
        {
            while (true)
            {
                ClientReceive();
            }
        }
        public void ClientReceive()
        {
            try
            {
                if (!sending)
                {
                    byte[] bytes = new byte[client.ReceiveBufferSize];
                    String data = null;
                    int i;
                    NetworkStream stream = client.GetStream();
                    i = stream.Read(bytes, 0, (int)client.ReceiveBufferSize);
                    if (i != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    }
                    switch (data.Split(':')[0])
                    {

                    }
                    stream.Close();
                }
            }
            catch { }
        }

        public void ClientSend(string data)
        {
            try
            {
                sending = true;
                NetworkStream stream = client.GetStream();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                sending = false;
                stream.Close();
            }
            catch { }
        }
    }
}
