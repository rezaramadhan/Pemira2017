using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace PemiraServer
{
    class ServerSocket {
        private TcpClient client;
        private NetworkStream netStream;
        private string host;
        private int port;
        private int MAXBUFF = 1024;
        public ServerSocket(string h, int p) {
            host = h;
            port = p;
            client = new TcpClient();
        }

        public void connect() {
            client.Connect(host, port);
            netStream = client.GetStream();
            client.ReceiveBufferSize = MAXBUFF;
        }

        public void disconnect() {
            client.Close();
        }

        public void send(string s) {
            byte[] outStream = Encoding.ASCII.GetBytes(s);
            netStream.Write(outStream, 0, outStream.Length);

        }

        public string recv() {
            byte[] inStream = new byte[MAXBUFF];

            netStream.Read(inStream, 0, client.ReceiveBufferSize);
            string s = "";
            s = Encoding.ASCII.GetString(inStream);

            return s;
        }
    }
}
