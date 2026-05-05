using System.ComponentModel.DataAnnotations.Schema;

namespace BrawlstarsApi.Models
{
    [Table("brawler")]
    public class Brawler
    {
        public int ID {get; set;}
        public required string Name {get; set;}
        public required string Type {get; set;}
        public int Speed {get; set;}
        public string? Weapon {get; set;}
        public int Health {get; set;}
        public int Popularity { get; set; }
    }
}
