using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertJson
{
    class Program
    {
        static void Checks(List<Champion> list)
        {
            Console.WriteLine($"Hp: {list.Any(ch => ch.Hp == 0)}");
            Console.WriteLine($"Mp: {list.Any(ch => ch.Mp == 0)}");
            Console.WriteLine($"MoveSpeed: {list.Any(ch => ch.MoveSpeed == 0)}");
            Console.WriteLine($"Armor: {list.Any(ch => ch.Armor == 0)}");
            Console.WriteLine($"SpellBlock: {list.Any(ch => ch.SpellBlock == 0)}");
            Console.WriteLine($"AttackRange: {list.Any(ch => ch.AttackRange == 0)}");
            Console.WriteLine($"HpRegen: {list.Any(ch => ch.HpRegen == 0)}");
            Console.WriteLine($"MpRegen: {list.Any(ch => ch.MpRegen == 0)}");
            Console.WriteLine($"Crit: {list.Any(ch => ch.Crit == 0)}");
            Console.WriteLine($"AttackDamage: {list.Any(ch => ch.AttackDamage == 0)}");
            Console.WriteLine($"AttackSpeed: {list.Any(ch => ch.AttackSpeed == 0)}");
        }

        static void CreateSql(List<Champion> list)
        {
            var sb = new StringBuilder();
            foreach (var ch in list)
            {
                sb.Append(ch.ToSqlInsert() + "\n");
            }
            File.WriteAllText("champions.sql", sb.ToString());
        }

        static void DownloadImages(List<Champion> list)
        {
            if (!Directory.Exists("images"))
            {
                Directory.CreateDirectory("images");
            }

            foreach (var ch in list)
            {
                ch.DownloadImage();
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var list = Champion.ReadFromJson("lol-champions.json");

            // Checks(list);
            DownloadImages(list);
            CreateSql(list);
        }
    }
}
