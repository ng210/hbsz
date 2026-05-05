namespace CardGame.Model
{
    public class Card
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
    }
}
