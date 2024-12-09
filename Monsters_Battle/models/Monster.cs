namespace MonsterBattleGame.Models
{
    public abstract class Monster
    {
        public string Name { get; set; } = string.Empty; 
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public abstract void UseSpecialAbility(Monster target);

        // Método para sofrer dano com defesa inclusa
        public virtual void TakeDamage(int damage)
        {
            // Reduz o dano com base na defesa
            int reducedDamage = Math.Max(damage - Defense, 0);
            int damageReduced = damage - reducedDamage;

            // Atualiza a vida do monstro
            Health -= reducedDamage;

            // Exibe no console a quantidade de dano recebido e reduzido
            Console.WriteLine($"{Name} defends! Damage reduced by {damageReduced}.");
            Console.WriteLine($"{Name} takes {reducedDamage} damage. Current Health: {Health}");
        }
    }
}
