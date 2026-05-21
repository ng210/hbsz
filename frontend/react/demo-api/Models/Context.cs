using BrawlstarsApi.Models;
using System.Text.Json;

namespace DemoApi.Models
{
    public class Context
    {
        public HashSet<Brawler> Brawlers { get; set; } = [];

        public Context(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Brawlers = JsonSerializer.Deserialize<HashSet<Brawler>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
