using UnityEngine;

namespace TaroCards
{
    public class CardConfig
    {
        public readonly string Name;
        public readonly string Description;
        public readonly int Health;
        public readonly int Attack;
        public readonly int Mana;

        public CardConfig(string name, string description)
        {
            Name = name;
            Description = description;
            Health = Random.Range(50, 100);
            Attack = Random.Range(50, 100);
            Mana = Random.Range(50, 100);
        }
    }
}