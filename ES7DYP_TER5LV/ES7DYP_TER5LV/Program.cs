using System;

namespace ES7DYP_TER5LV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aknakereso ES7DYP - TER5LV");

            Console.WriteLine("Difficulty? Type easy, medium or hard");
            var difficulty = Console.ReadLine();

            IMineSweeperGame game;

            switch (difficulty)
            {
                case "easy":
                    game = new MineSweeperGame(5, 5, 2);
                    break;
                case "medium":
                    game = new MineSweeperGame(20, 20, 15);
                    break;
                case "hard":
                    game = new MineSweeperGame(30, 30, 25);
                    break;
                default:
                    game = new MineSweeperGame(10, 10, 15);
                    break;
            }

            game.Start();
            game.PrintBoard();

            while (!game.IsGameOver() && !game.IsGameWon())
            {
                game.Start();

                while (!game.IsGameOver() && !game.IsGameWon())
                {
                    Console.WriteLine("Use arrow keys to move, Spacebar to reveal, F to flag, Q to quit");

                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            game.MoveSelection(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            game.MoveSelection(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            game.MoveSelection(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            game.MoveSelection(1, 0);
                            break;
                        case ConsoleKey.Spacebar:
                            if (game.RevealSelectedField())
                            {
                                Console.WriteLine("Game Over! You hit a mine!");
                                game.PrintBoard();
                                return;
                            }
                            break;
                        case ConsoleKey.F:
                            game.FlagSelectedField();
                            break;
                        case ConsoleKey.Q:
                            return;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            continue;
                    }

                    Console.Clear();

                    game.PrintBoard();

                    if (game.IsGameWon())
                    {
                        Console.WriteLine("Congratulations! You've won!");
                    }
                }

                Console.WriteLine("Game ended. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
