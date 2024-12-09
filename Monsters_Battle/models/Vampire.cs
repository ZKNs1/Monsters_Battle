using MonsterBattleGame.Models;

namespace MonsterBattleGame.Models
{
    public class Vampire : Monster
    {
        public Vampire()
        {
            Name = "Vampire";
            Health = 90;
            AttackPower = 12;
            Defense = 4;
        }

        public override void UseSpecialAbility(Monster target)
        {
            int damage = AttackPower - target.Defense;
            damage = Math.Max(damage, 1); // Garante que o dano mínimo seja 1
            target.Health -= damage;
            Health += damage / 2; // Recupera metade do dano como vida
            Console.WriteLine($"{Name} uses Life Steal, dealing {damage} damage and healing {damage / 2} health! Target Health: {target.Health}");
        }
    }
}
