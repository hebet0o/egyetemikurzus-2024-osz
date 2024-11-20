using System.Collections.Generic;

namespace ES7DYP_TER5LV
{
    internal interface IBoard
    {
        int Width { get; }
        int Height { get; }
        int MineCount { get; }
        IEnumerable<IField> Fields { get; }
        void Initialize();
        IField GetField(int x, int y);
        IEnumerable<IField> GetAdjacentFields(IField field);
        bool AreAllSafeCellsRevealed();
    }
}
