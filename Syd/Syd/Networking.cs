﻿using System;
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
    class Networking
    {
        public string GetComputer_LanIP()
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
        public string GetComputer_InternetIP()
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
    }
}
