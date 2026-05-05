using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat
{
    public class SimpleClient : SimpleAgent
    {
        private readonly MainWindow _ui;
        private TcpClient _client;

        public SimpleClient(MainWindow ui)
        {
            _ui = ui;
        }

        public async Task ConnectAsync(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port);
            _ui.AddMessage("[Client connected]");

            _reader = new StreamReader(_client.GetStream());
            _writer = new StreamWriter(_client.GetStream()) { AutoFlush = true };

            _ = ReadLoopAsync();
        }

        private async Task ReadLoopAsync()
        {
            string line;
            while ((line = await _reader.ReadLineAsync()) != null)
            {
                _ui.AddMessage($"[Client received]: {line}");
            }
        }
    }

}
