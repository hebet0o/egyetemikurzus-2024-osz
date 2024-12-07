namespace ES7DYP_TER5LV
{
    public interface IField
    {
        Position Position { get; }
        bool IsMine { get; set; }
        bool IsRevealed { get; set; }
        bool IsFlagged { get; set; }
        bool Selected { get; set; }
        int AdjacentMines { get; set; }
    }
}
