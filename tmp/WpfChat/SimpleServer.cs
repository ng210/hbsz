using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat
{
    public class SimpleServer : SimpleAgent
    {
        private readonly MainWindow _ui;
        private TcpListener _listener;

        public SimpleServer(MainWindow ui)
        {
            _ui = ui;
        }

        public async Task StartAsync(int port)
        {
            _listener = new TcpListener(IPAddress.Loopback, port);
            _listener.Start();
            _ui.AddMessage("[Server started]");

            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            _reader = new StreamReader(client.GetStream());
            _writer = new StreamWriter(client.GetStream()) { AutoFlush = true };

            string line;
            while ((line = await _reader.ReadLineAsync()) != null)
            {
                _ui.AddMessage($"[received]: {line}");
            }

            _ui.AddMessage("[Client disconnected]");

            _reader.Dispose();
            _writer.Dispose();
        }
    }

}
