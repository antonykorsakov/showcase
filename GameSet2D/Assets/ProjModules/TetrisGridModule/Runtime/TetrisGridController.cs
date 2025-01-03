using System;
using ProjModules.TetrisGridModule.Runtime.Data;

namespace ProjModules.TetrisGridModule.Runtime
{
    public class TetrisGridController : ITetrisGridController
    {
        private readonly ITetrisGridConfig _config;
        private readonly GridCellState[,] _grid;

        public TetrisGridController(ITetrisGridConfig config)
        {
            _config = config;

            var w = config.Width;
            var h = config.Height;
            if (w <= 0 || h <= 0)
                throw new ArgumentException("Invalid tetris grid size.");

            _grid = new GridCellState[w, h];
        }

        public GridCellState GetCell(int x, int y)
        {
            // check width
            if (x < 0 || x >= _grid.GetLength(0))
                return GridCellState.Error;

            // check height
            if (y < 0 || y >= _grid.GetLength(1))
                return GridCellState.Error;

            return _grid[x, y];
        }

        public void AddTetromino(bool[,] tetromino, int minX, int minY)
            => SetCells(tetromino, minX, minY, GridCellState.ControlledTetromino, CanAddTetromino);


        public void RemoveTetromino(bool[,] tetromino, int minX, int minY)
            => SetCells(tetromino, minX, minY, GridCellState.Empty, CanRemoveTetromino);

        public bool IsValidTetrominoPos(bool[,] tetromino, int minX, int minY)
        {
            bool valid = IsValidTetrominoSize(tetromino, minX, minY);
            if (!valid)
                return false;

            int width = tetromino.GetLength(0);
            int height = tetromino.GetLength(1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isTetromino = tetromino[x, y];
                    if (!isTetromino)
                        continue;

                    var cell = _grid[minX + x, minY + y];
                    switch (cell)
                    {
                        case GridCellState.Empty:
                            continue;

                        case GridCellState.ControlledTetromino:
                        case GridCellState.StoppedTetromino:
                        case GridCellState.UnbreakableWall:
                        case GridCellState.Error:
                            return false;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return true;
        }

        private void SetCells(bool[,] tetromino, int minX, int minY, GridCellState cellState,
            Func<GridCellState, bool> checkCellCallback)
        {
            if (!IsValidTetrominoPos(tetromino, minX, minY))
                throw new InvalidOperationException("Invalid position for Tetromino.");

            int width = tetromino.GetLength(0);
            int height = tetromino.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isTetromino = tetromino[x, y];
                    if (!isTetromino)
                        continue;

                    if (!checkCellCallback(cellState))
                        continue;

                    _grid[minX + x, minY + y] = cellState;
                }
            }
        }

        private bool CanAddTetromino(GridCellState currentCellState)
        {
            switch (currentCellState)
            {
                case GridCellState.Empty:
                    return true;

                case GridCellState.StoppedTetromino:
                case GridCellState.UnbreakableWall:
                    return false;

                case GridCellState.ControlledTetromino:
                case GridCellState.Error:
                    throw new InvalidOperationException("Cannot add Tetromino in an error state");

                default:
                    throw new ArgumentOutOfRangeException(nameof(currentCellState), currentCellState, null);
            }
        }

        private bool CanRemoveTetromino(GridCellState currentCellState)
        {
            switch (currentCellState)
            {
                case GridCellState.ControlledTetromino:
                    return true;

                case GridCellState.StoppedTetromino:
                case GridCellState.UnbreakableWall:
                    return false;

                case GridCellState.Empty:
                case GridCellState.Error:
                    throw new InvalidOperationException("Cannot remove Tetromino in an error state");

                default:
                    throw new ArgumentOutOfRangeException(nameof(currentCellState), currentCellState, null);
            }
        }

        private bool IsValidTetrominoSize(bool[,] tetromino, int minX, int minY)
        {
            if (minX < 0 || minY < 0)
                return false;

            int width = tetromino.GetLength(0);
            int height = tetromino.GetLength(1);
            if (width == 0 || height == 0)
                return false;

            int maxX = minX + width - 1;
            if (maxX >= _grid.GetLength(0))
                return false;

            int maxY = minY + height - 1;
            if (maxY >= _grid.GetLength(1))
                return false;

            return true;
        }
    }
}