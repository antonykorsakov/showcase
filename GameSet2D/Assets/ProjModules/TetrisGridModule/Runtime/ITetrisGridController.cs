namespace ProjModules.TetrisGridModule.Runtime
{
    public interface ITetrisGridController
    {
        GridCellState GetCell(int x, int y);

        void AddTetromino(bool[,] tetromino, int minX, int minY);
        void RemoveTetromino(bool[,] tetromino, int minX, int minY);
        bool IsValidTetrominoPos(bool[,] tetromino, int minX, int minY);
    }
}