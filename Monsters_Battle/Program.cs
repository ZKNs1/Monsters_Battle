using MonsterBattleGame.Models;

namespace MonsterBattleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static Monster ChooseMonster()
            {
                while (true)
                {
                    Console.WriteLine("Choose your monster:");
                    Console.WriteLine("1. Zombie");
                    Console.WriteLine("2. Ghost");
                    Console.WriteLine("3. Vampire");

                    string choice = Console.ReadLine() ?? "";

                    switch (choice)
                    {
                        case "1":
                            return new Zombie();
                        case "2":
                            return new Ghost();
                        case "3":
                            return new Vampire();
                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }
                }
            }

            Monster playerMonster = ChooseMonster();
            Monster computerMonster = new Ghost(); // IA escolhe sempre Ghost (pode ser randomizado depois)

            BattleSystem battleSystem = new BattleSystem();
            bool gameOver = false;

            Console.WriteLine("\nBattle Start!");
            Console.WriteLine($"Player chose: {playerMonster.Name}");
            Console.WriteLine($"Computer chose: {computerMonster.Name}");

            while (!gameOver)
            {
                Console.WriteLine("\nYour turn! Choose an action (attack, defend, special):");
                string playerAction = Console.ReadLine()?.ToLower() ?? "";

                // Turno do jogador
                battleSystem.ExecuteTurn(playerMonster, computerMonster, playerAction);
                if (computerMonster.Health <= 0)
                {
                    Console.WriteLine("\nYou win!");
                    gameOver = true;
                    break;
                }

                // Turno do computador
                Console.WriteLine("\nComputer's turn!");
                string computerAction = DecideComputerAction(computerMonster, playerMonster);
                Console.WriteLine($"Computer chooses to {computerAction}.");
                battleSystem.ExecuteTurn(computerMonster, playerMonster, computerAction);

                Console.WriteLine($"\nStatus after the turn:");
                Console.WriteLine($"Player Monster: {playerMonster.Name}, Health: {playerMonster.Health}, Defense: {playerMonster.Defense}");
                Console.WriteLine($"Computer Monster: {computerMonster.Name}, Health: {computerMonster.Health}, Defense: {computerMonster.Defense}");


                if (playerMonster.Health <= 0)
                {
                    Console.WriteLine("\nYou lose!");
                    gameOver = true;
                }
            }
        }

        // Sistema de decisão de ações do computador
        static string DecideComputerAction(Monster computerMonster, Monster playerMonster)
        {
            if (computerMonster.Health < 30 && computerMonster is Ghost ghost)
            {
                // Ghost tenta usar o especial se a saúde estiver baixa
                return "special";
            }
            else if (playerMonster.Health < 20)
            {
                // Prioriza ataque se o jogador estiver com pouca saúde
                return "attack";
            }
            else
            {
                // Escolha aleatória para diversificar as ações
                string[] possibleActions = { "attack", "defend", "special" };
                return possibleActions[new Random().Next(0, possibleActions.Length)];
            }
        }
    }
}
