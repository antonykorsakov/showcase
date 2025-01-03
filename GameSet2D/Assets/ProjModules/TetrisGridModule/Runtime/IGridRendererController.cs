using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime
{
    public interface IGridRendererController
    {
        void EnableRenderer();
        void SetCell(int x, int y, Tile gridCell);
    }
}