namespace ES7DYP_TER5LV
{
    internal interface IMineSweeperGame
    {
        void Start();
        bool RevealField(int x, int y);
        void FlagField(int x, int y);
        bool IsGameOver();
        bool IsGameWon();
        void PrintBoard();
        void MoveSelection(int deltaX, int deltaY);
        bool RevealSelectedField();
        void FlagSelectedField();
    }
}
