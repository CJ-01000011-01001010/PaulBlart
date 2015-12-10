using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionSpawnListener Listener = new ConnectionSpawnListener(2245, "127.0.0.1");
            Listener.Listen();
        }
    }
}
