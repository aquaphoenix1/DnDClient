using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DnDClient.Client_Elements
{
    class Client
    {
        private int port;
        private String ip;

        private TcpClient tcpClient;

        private Thread receiveThread;

        public event EventHandler<String> ActivityHandler;

        public Client(int port, string ipAdress)
        {
            this.port = port;
            this.ip = ipAdress;

            try
            {
                tcpClient = new TcpClient(ip, port);

                receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();
            }
            catch (Exception exc)
            {
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    string message = string.Empty;
                    StringBuilder builder = new StringBuilder();

                    if (tcpClient.GetStream().DataAvailable)
                    {
                        byte[] data = new byte[256];

                        int bytes = 0;
                        do
                        {
                            bytes = tcpClient.GetStream().Read(data, 0, data.Length);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (tcpClient.GetStream() != null && tcpClient.GetStream().CanRead && tcpClient.GetStream().DataAvailable);

                        message = builder.ToString();

                        if (message != string.Empty)
                        {
                            ActivityHandler?.Invoke(this, message);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
