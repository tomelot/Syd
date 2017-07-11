﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace YoutubePlayer
{
    class Client
    {
        public Networking NetFunctions = new Networking();
        TcpClient client;
        Thread myNewThread;
        public Client(String ip)
        {
            client = new TcpClient();
            client.Connect(ip, 25565);
            myNewThread = new Thread(() => ClientLooper());
            myNewThread.Start();
            Console.WriteLine(NetFunctions.GetComputer_InternetIP());
        }

        public void Clientstop()
        {
            client.Close();
            myNewThread.Abort();
        }

        private void ClientLooper()
        {
            while (true)
            {
                ClientReceive();
            }
        }
        public void ClientReceive()
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
        }

        public void ClientSend(string data)
        {
            NetworkStream stream = client.GetStream();
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
            stream.Write(msg, 0, msg.Length);
        }
    }
}
