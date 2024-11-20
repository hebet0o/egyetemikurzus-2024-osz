using System.Collections.Generic;
using System;
using System.Linq;


namespace ES7DYP_TER5LV
{
    internal class Board : IBoard
    {
        private List<IField> fields;
        private Random random;

        public int Width { get; }
        public int Height { get; }
        public int MineCount { get; }
        public IEnumerable<IField> Fields => fields.AsReadOnly();

        public Board(int width, int height, int mineCount)
        {
            Width = width;
            Height = height;
            MineCount = mineCount;
            fields = new List<IField>();
            random = new Random();
        }

        public void Initialize()
        {
            CreateFields();
            PlaceMines();
            CalculateAdjacentMines();
        }

        public IField GetField(int x, int y)
        {
            return fields.FirstOrDefault(f => f.Position.X == x && f.Position.Y == y);
        }

        public IEnumerable<IField> GetAdjacentFields(IField field)
        {
            return fields.Where(f => Math.Abs(f.Position.X - field.Position.X) <= 1 &&
                                     Math.Abs(f.Position.Y - field.Position.Y) <= 1 &&
                                     f != field);
        }

        public bool AreAllSafeCellsRevealed()
        {
            return fields.Count(f => !f.IsMine && !f.IsRevealed) == 0;
        }

        private void CreateFields()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    fields.Add(new Field(x, y));
                }
            }
        }

        private void PlaceMines()
        {
            int minesToPlace = MineCount;
            while (minesToPlace > 0)
            {
                int index = random.Next(fields.Count);
                if (!fields[index].IsMine)
                {
                    fields[index].IsMine = true;
                    minesToPlace--;
                }
            }
        }

        private void CalculateAdjacentMines()
        {
            foreach (var field in fields.Where(f => !f.IsMine)) 
            {                                                   

                field.AdjacentMines = GetAdjacentFields(field).Count(f => f.IsMine);

            }
        }
    }
}
