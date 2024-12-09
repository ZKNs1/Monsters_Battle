namespace MonsterBattleGame.Models
{
    public class Zombie : Monster
    {
        private const int MaxHealth = 100;

        public Zombie()
        {
            Name = "Zombie";
            Health = MaxHealth;
            AttackPower = 10;
            Defense = 5;
        }

        public override void UseSpecialAbility(Monster target)
        {
            if (Health < MaxHealth)
            {
                int healAmount = 15;
                Health = Math.Min(Health + healAmount, MaxHealth); // Limita a vida ao máximo
                Console.WriteLine($"{Name} regenerates {healAmount} health! Current Health: {Health}");
            }
            else
            {
                Console.WriteLine($"{Name} is already at full health and can't regenerate!");
            }
        }
    }
}
