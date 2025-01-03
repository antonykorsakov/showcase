using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public interface ITetrisGridConfig
    {
        Tile Tmp { get; }
        int Width { get; }
        int Height { get; }
        GridRenderer View { get; }

        TileData GetTetrominoShape(TetrominoType type);
    }
}