namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public interface ITetrisGridConfig
    {
        int Width { get; }
        int Height { get; }
        int SpawnAreaHeight { get; }
    }
}