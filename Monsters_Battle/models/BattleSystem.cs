using MonsterBattleGame.Models;

namespace MonsterBattleGame
{
    public class BattleSystem
    {
        public void ExecuteTurn(Monster attacker, Monster defender, string action)
        {
            switch (action.ToLower())
            {
                case "attack":
                    PerformAttack(attacker, defender);
                    break;
                case "defend":
                    PerformDefense(attacker);
                    break;
                case "special":
                    attacker.UseSpecialAbility(defender);
                    break;
                default:
                    Console.WriteLine("Invalid action. Turn skipped.");
                    break;
            }
        }

        private void PerformDefense(Monster defender)
        {
            defender.Defense += 50; // Defesa reduz o dano pela metade.
            Console.WriteLine($"{defender.Name} prepares to defend! Incoming damage will be reduced by 50%.");
        }

        private void PerformAttack(Monster attacker, Monster defender)
        {
            int rawDamage = Math.Max(attacker.AttackPower - defender.Defense, 0);
            int finalDamage = defender.Defense > 0 ? rawDamage / 2 : rawDamage; // Reduz 50% se defender.

            defender.Health -= finalDamage;

            Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {finalDamage} damage!");
            Console.WriteLine($"{defender.Name} has {defender.Health} health remaining.");

            defender.Defense = 0;

            if (defender.Health <= 0)
            {
                Console.WriteLine($"{defender.Name} has been defeated!");
            }
        }
    }
}
