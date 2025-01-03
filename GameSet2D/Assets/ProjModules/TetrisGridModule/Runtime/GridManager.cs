using System;
using ProjModules.TetrisGridModule.Runtime.Data;
using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime
{
    public class GridManager : IGridManager
    {
        private readonly Tile _tmp;
        private readonly IGridDataController _dataController;
        private readonly IGridRendererController _rendererController;

        public GridManager(Tile tmp,
            IGridDataController dataController,
            IGridRendererController rendererController)
        {
            _tmp = tmp;
            _dataController = dataController;
            _rendererController = rendererController;
        }

        public void Enable()
        {
            bool[,] tetromino = 
            {
                { true, false },
                { true, false },
                { true, false },
                { false, true },
            };
            
            _dataController.AddTetromino(tetromino, 0, 0);
                
            _rendererController.EnableRenderer();
            for (int x = 0; x < _dataController.Width; x++)
            {
                for (int y = 0; y < _dataController.Height; y++)
                {
                    var cellState = _dataController.GetCell(x, y);
                    switch (cellState)
                    {
                        case GridCellState.Empty:
                            _rendererController.SetCell(x, y, null);
                            break;

                        case GridCellState.ControlledTetromino:
                            _rendererController.SetCell(x, y, _tmp);
                            break;

                        case GridCellState.StoppedTetromino:
                        case GridCellState.UnbreakableWall:
                        case GridCellState.Error:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}