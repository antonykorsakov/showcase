using ProjModules.TetrisGridModule.Runtime.Data;

namespace ProjModules.TetrisGridModule.Runtime
{
    public interface IGridDataController
    {
        int Width { get; }
        int Height { get; }

        GridCellState GetCell(int x, int y);

        void AddTetromino(bool[,] tetromino, int minX, int minY);
        void RemoveTetromino(bool[,] tetromino, int minX, int minY);
        bool IsValidTetrominoPos(bool[,] tetromino, int minX, int minY);
    }
}