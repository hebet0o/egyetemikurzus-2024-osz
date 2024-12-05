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

            while (!game.IsGameOver() && !game.IsGameWon())
            {
                Console.Write("Enter command (R x y to reveal, F x y to flag, Q to quit): ");
                string[] input = Console.ReadLine().Split(' ');

                try
                {
                    switch (input[0].ToUpper())
                    {
                        case "R":
                            if (game.RevealField(int.Parse(input[1]), int.Parse(input[2])))
                            {
                                Console.WriteLine("Game Over! You hit a mine!");
                                game.PrintBoard(); // Show final board state
                                Console.ReadKey();
                                return;
                            }
                            break;
                        case "F":
                            game.FlagField(int.Parse(input[1]), int.Parse(input[2]));
                            break;
                        case "Q":
                            return;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

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
