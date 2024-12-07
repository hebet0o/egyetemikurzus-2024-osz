namespace ES7DYP_TER5LV
{
    public class Field : IField
    {
        public Position Position { get; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int AdjacentMines { get; set; }
        public bool Selected { get; set; }

        public Field(int x, int y)
        {
            Position = new Position(x, y);
            IsMine = false;
            IsRevealed = false;
            IsFlagged = false;
            Selected = false;
            AdjacentMines = 0;
        }
    }
}
