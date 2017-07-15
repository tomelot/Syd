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
using Open.Nat;

namespace YoutubePlayer
{
    class Server
    {
        TcpListener serverSocket;
        TcpClient clientSocket;
        Boolean stop = false;
        public Thread ServerLooperClientsT;
        public Thread ServerLooperReccivetT;
        //Creating object from NetWorking
        public Networking NetFunctions = new Networking();
        //List of all clients
        public List<TcpClient> clients = new List<TcpClient>();

        public Server()
        {   //Init the server
            NetFunctions.PortForAsync(8888);
            serverSocket = TcpListener.Create(8888);
            clientSocket = default(TcpClient);
            serverSocket.Start();
            //New Thread Looper
            ServerLooperClientsT = new Thread(() => ServerLooperClients());
            ServerLooperReccivetT = new Thread(() => ServerLooperReccive());
            ServerLooperClientsT.Start();
            ServerLooperReccivetT.Start();
          

        }

        public void ServerStop()
        {
            clients.Clear();
            stop = true;
            ServerLooperClientsT.Suspend();
            ServerLooperReccivetT.Abort();
            serverSocket.Stop();
        }
        private void ServerLooperClients()
        {
            //The loop for connecting clients
            while (true)
            {
                ServerWaitConnect();
            }
        }
        private void ServerLooperReccive()
        {
            while (true)
            {
                ServerReceive();
            }
        }
        public void ServerWaitConnect()
        {
            try
            {
                //Accepting Client to the server
                    clientSocket = serverSocket.AcceptTcpClient();
                    clients.Add(clientSocket);
                    MessageBox.Show("Conected to: " + IPAddress.Parse(((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString()));
            }
            catch
            {

            }
            //Adding the client to the list
        }

        public void ServerReceive()
        {
            //Init the vars
            Byte[] bytes = new Byte[256];
            String data = null;
            int i;
            try
            {
                foreach (TcpClient client in clients)
                {
                    if (client.Connected) {
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
                        stream.Close();
                    }
                    else
                    {
                        clients.Remove(client);
                    }
                }
            }
            catch
            {

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
