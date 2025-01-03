namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public interface ITetrisGridConfig
    {
        int Width { get; }
        int Height { get; }
        TetrisGridView View { get; }

        TileData GetTetrominoShape(TetrominoType type);
    }
}