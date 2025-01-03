namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public sealed class TetrominoShapeI : TetrominoShape
    {
        private static readonly byte[,] Shape1 =
        {
            { 1, 1, 1, 1 },
        };

        private static readonly byte[,] Shape2 =
        {
            { 0, 0, 1 },
            { 0, 0, 1 },
            { 0, 0, 1 },
            { 0, 0, 1 },
        };
        
        protected override byte[][,] Shapes { get; } =
        {
            Shape1,
            Shape2,
        };
    }
}