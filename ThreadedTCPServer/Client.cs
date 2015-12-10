using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ThreadedTCPServer
{
    public class Client
    {
        public string c_Name { get; private set; }
        private Socket c_Socket;
        public Client(string NamedIdentifier,Socket c_Sockets)
        {
            this.c_Name = NamedIdentifier;
            this.c_Socket = c_Sockets;
        }

        public void Listen()
        {
            c_Socket.Send(Encoding.ASCII.GetBytes("Welcome to the socket server\r\n"));

            char[] buffer = new char[8194];
            while (true)
            {
                NetworkStream Stream = new NetworkStream(this.c_Socket);
                StreamReader StreamRdr = new StreamReader(Stream);

                //This royally sucks. You need to actually buffer shit and have some kind of protocol on top of this.
                if (this.c_Socket.ReceiveBufferSize > 0)
                {
                    StreamRdr.Read(buffer, 0, this.c_Socket.ReceiveBufferSize);
                    Console.WriteLine(buffer);
                    Stream.Flush();
                }
            }
        }
    }
}
