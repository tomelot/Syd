using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Syd
{
    class Server
    {
        //Creating object from NetWorking
        public Networking NetFunctions = new Networking();
        //List of all clients
        public List<TcpClient> clients = new List<TcpClient>();

        public void CreateServer()
        {   //Init the server
            Int32 port = 25565;
            IPAddress localAddr = IPAddress.Parse(NetFunctions.GetComputer_LanIP());
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            //New Thread Looper
            Thread myNewThread = new Thread(() => ServerLooper(server));
            myNewThread.Start();
            Console.WriteLine(NetFunctions.GetComputer_InternetIP());
        }

        private void ServerLooper(TcpListener server)
        {
            //The loop for connecting clients, receiving data and sending data
            while (true)
            {

            }
        }
        public void ServerWaitConnect(TcpListener server)
        {
            //Accepting Client to the server
            TcpClient client = server.AcceptTcpClient();
            //Adding the client to the list
            clients.Add(client);
            Console.WriteLine("Conected to: " + IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));
        }

        public void ServerReceive()
        {
            //Init the vars
            Byte[] bytes = new Byte[256];
            String data = null;
            int i;
            foreach (TcpClient client in clients)
            {
                //Get the stream of each client
                NetworkStream stream = client.GetStream();
                //Gets the data
                i = stream.Read(bytes, 0, bytes.Length);
                if (i != 0)
                {
                    //Decode the data
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                }
                //Switch case for the type of data
                switch (data.Split(':')[0])
                {

                }
            }
        }

        public void ServerSendToAll(string data)
        {
            foreach (TcpClient client in clients)
            {
                //Get the stream of each client
                NetworkStream stream = client.GetStream();
                //Encode the data
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                //Send the data
                stream.Write(msg, 0, msg.Length);
            }
        }

        public void ServerSendToOne(string data, string clientip)
        {
            foreach (TcpClient client in clients)
            {
                //Get the ip of each client
                string clientIPAddress = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()).ToString();
                //Checking for the Right ip
                if (clientIPAddress == clientip)
                {
                    //Get the stream of the client
                    NetworkStream stream = client.GetStream();
                    //Encode the data
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    //Send the data
                    stream.Write(msg, 0, msg.Length);
                }
            }
        }

    }
}
