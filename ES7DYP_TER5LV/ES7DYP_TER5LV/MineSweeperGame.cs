using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ES7DYP_TER5LV
{
    public class MineSweeperGame : IMineSweeperGame
    {
        private readonly IBoard board;
      
        public MineSweeperGame(int width, int height, int mineCount)
        {
            board = new Board(width, height, mineCount);
            board.Initialize();
        }

        public void Start()
        {
            Console.WriteLine("Minesweeper game started!");
            PrintBoard();
        }

        public bool RevealField(int x, int y) //Felhasználó által választott mező felfedése
        {
            var field = board.GetField(x, y);
            if (field == null || field.IsRevealed || field.IsFlagged)
                return false;

            field.IsRevealed = true;

            if (field.IsMine)
                return true; // Game over

            if (field.AdjacentMines == 0)
            {
                RevealAdjacentFields(field);
            }

            return false;
        }

        //Resz method a RevealFieldshez
        private void RevealAdjacentFields(IField field)
        {
            foreach (var adjacentField in board.GetAdjacentFields(field))
            {
                if (!adjacentField.IsRevealed && !adjacentField.IsFlagged)
                {
                    adjacentField.IsRevealed = true;
                    if (adjacentField.AdjacentMines == 0)
                    {
                        RevealAdjacentFields(adjacentField);
                    }
                }
            }
        }

        public void FlagField(int x, int y)
        {
            var field = board.GetField(x, y);
            if(field != null && !field.IsRevealed)
            {
                field.IsFlagged = !field.IsFlagged;
            }
            
        }

        public bool IsGameOver()
        {
            return board.Fields.Any(f => f.IsMine && f.IsRevealed);
        }

        public bool IsGameWon()
        {
            return board.AreAllSafeCellsRevealed();
        }


        public void PrintBoard()
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    var field = board.GetField(x, y);
                    if (field.IsRevealed)
                    {
                        Console.Write(field.IsMine ? "*" : field.AdjacentMines.ToString());
                    }
                    else if (field.IsFlagged)
                    {
                        Console.Write("F");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
