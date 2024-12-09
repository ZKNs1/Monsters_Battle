namespace MonsterBattleGame.Models
{
    public class Ghost : Monster
    {
        private bool isImmuneNextTurn;

        public Ghost()
        {
            Name = "Ghost";
            Health = 80;
            AttackPower = 12;
            Defense = 3;
        }

        public override void UseSpecialAbility(Monster target)
        {
            isImmuneNextTurn = true;
            Console.WriteLine($"{Name} becomes immune to the next attack!");
        }

        public override void TakeDamage(int damage)
        {
            if (isImmuneNextTurn)
            {
                Console.WriteLine($"{Name} evades the attack and takes no damage!");
                isImmuneNextTurn = false;
            }
            else
            {
                base.TakeDamage(damage);
            }
        }
    }
}
