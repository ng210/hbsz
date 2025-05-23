using CardGame.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.DbAccess
{
    public class DbCard
    {
        DbConnection _connection;

        public DbCard(DbConnection connection)
        {
            _connection = connection;
        }

        public List<Card> Get()
        {
            var result = new List<Card>();
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT `name`,`hp`,`mp`,`hpregen`,`mpregen`,`movespeed`,`spellblock`,`armor`,`attackrange`,`crit`,`attackdamage`,`attackspeed`,`image` FROM `card`;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var card = new Card
                        {
                            Name = reader.GetString(0),
                            Hp = reader.GetInt32(1),
                            Mp = reader.GetInt32(2),
                            HpRegen = reader.GetFloat(3),
                            MpRegen = reader.GetFloat(4),
                            MoveSpeed = reader.GetInt32(5),
                            SpellBlock = reader.GetInt32(6),
                            Armor = reader.GetInt32(7),
                            AttackRange = reader.GetInt32(8),
                            Crit = reader.GetInt32(9),
                            AttackDamage = reader.GetInt32(10),
                            AttackSpeed = reader.GetInt32(11)
                        };
                        card.Image = new byte[65536];
                        reader.GetBytes(12, 0, card.Image, 0, 65536);
                        result.Add(card);
                    }
                }
            }

            return result;
        }
    }
}
