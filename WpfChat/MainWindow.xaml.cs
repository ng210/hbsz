using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChat
{
    public partial class MainWindow : Window
    {
        private SimpleServer _server;
        private SimpleClient _client;
        private SimpleAgent _agent;
        private const int PORT = 12345;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string text = InputBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                await _agent.SendAsync(text);
                InputBox.Clear();
            }
        }

        public void AddMessage(string msg)
        {
            MessageList.Items.Add(msg);
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            _agent = _server = new SimpleServer(this);
            _ = _server.StartAsync(PORT);
        }
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            _agent = _client = new SimpleClient(this);
            _ = _client.ConnectAsync("127.0.0.1", PORT);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
