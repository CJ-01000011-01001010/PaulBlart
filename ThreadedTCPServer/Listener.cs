using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ThreadedTCPServer
{
    public class ConnectionSpawnListener
    {
        private UInt16 s_ListenPort;
        private string s_BindingAddr;
        private List<Thread> s_Threads;
        private TcpListener s_Incoming;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListenPort">What port do i listen for incoming connections</param>
        /// <param name="BindingAddress">Interface address</param>
        public ConnectionSpawnListener(UInt16 ListenPort, string BindingAddress)
        {

            this.s_BindingAddr = BindingAddress;
            this.s_ListenPort = ListenPort;
            s_Threads = new List<Thread>();
        }

        public void Listen()
        {
            s_Incoming = new TcpListener(IPAddress
                                        .Parse(this.s_BindingAddr), this.s_ListenPort);
            s_Incoming.Start();
            //256Byte buffer
            Byte[] s_Buffer = new Byte[256];
            //Probably want this to be something other than a for ever running event loop
            while (true)
            {
                //This is a blocking request
                var x = new Thread(
                    new ThreadStart(
                    new Client("Ident", s_Incoming.AcceptSocket())
                    .Listen));
                x.Start();
                s_Threads.Add(x);
             
            }
        }
        
    }

}
