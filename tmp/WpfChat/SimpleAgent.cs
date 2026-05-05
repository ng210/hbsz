using System.IO;
using System.Threading.Tasks;

namespace WpfChat
{
    public abstract class SimpleAgent
    {
        protected StreamReader _reader;
        protected StreamWriter _writer;

        public async Task SendAsync(string message)
        {
            await _writer.WriteLineAsync(message);
        }
    }
}
