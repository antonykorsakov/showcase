namespace ProjModules.TetrisGridModule.Runtime
{
    public interface ITetrisGridConfig
    {
        int Width { get; }
        int Height { get; }
        int SpawnAreaHeight { get; }
    }
}