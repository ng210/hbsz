using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertJson
{
    class Champion
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int MoveSpeed { get; set; }
        public int Armor { get; set; }
        public int SpellBlock { get; set; }
        public int AttackRange { get; set; }
        public float HpRegen { get; set; }
        public float MpRegen { get; set; }
        public int Crit { get; set; }
        public int AttackDamage { get; set; }
        public float AttackSpeed { get; set; }
        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }


        static public List<Champion> ReadFromJson(string path)
        {
            var list = new List<Champion>();
            var obj = JObject.Parse(File.ReadAllText(path, Encoding.UTF8));
            foreach (var ch in obj["data"].Values())
            {
                list.Add(new Champion
                {
                    Armor = ch["stats"].Value<int>("armor"),
                    AttackDamage = ch["stats"].Value<int>("attackdamage"),
                    AttackSpeed = ch["stats"].Value<float>("attackspeed"),
                    AttackRange = ch["stats"].Value<int>("attackrange"),
                    Crit = ch["stats"].Value<int>("crit"),
                    Description = ch.Value<string>("blurb"),
                    Hp = ch["stats"].Value<int>("hp"),
                    HpRegen = ch["stats"].Value<float>("hpregen"),
                    MoveSpeed = ch["stats"].Value<int>("movespeed"),
                    Mp = ch["stats"].Value<int>("mp"),
                    MpRegen = ch["stats"].Value<float>("mpregen"),
                    Name = ch.Value<string>("name"),
                    SpellBlock = ch["stats"].Value<int>("spellblock"),
                    ImageUrl = ch["image"].Value<string>("full")
                });
            }

            return list;
        }

        public string ToSqlInsert()
        {
            var attackSpeed = AttackSpeed.ToString().Replace(",", ".");
            var hpRegen = HpRegen.ToString().Replace(",", ".");
            var mpRegen = MpRegen.ToString().Replace(",", ".");
            return
                "INSERT INTO `card`" +
                "(`armor`, `attackdamage`, `attackspeed`, `attackrange`," +
                 "`crit`, `hp`, `hpregen`, `movespeed`, `mp`, `mpregen`," + 
                 "`name`, `spellblock`, `image`) VALUES" +
                $"({Armor}, {AttackDamage}, {attackSpeed}, {AttackRange}, {Crit}, {Hp}, {hpRegen}, {MoveSpeed}, {Mp}, {mpRegen}, \"{Name}\", {SpellBlock}, FROM_BASE64('{Convert.ToBase64String(Image)}'));";
        }

        public string ToSqlUpdate()
        {
            return
                $"UPDATE `card` SET `description`='{Description.Replace("'", "\\'")}' WHERE `name`='{Name.Replace("'", "\\'")}';";
        }

        public void DownloadImage()
        {
            const string baseUrl = "https://ddragon.leagueoflegends.com/cdn/14.22.1/img/champion/";
            using (WebClient client = new WebClient())
            {
                Image = client.DownloadData(new Uri($"{baseUrl}{ImageUrl}"));
            }
        }
    }
}
