namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public class TetrominoShapeO : TetrominoShape
    {
        private static readonly byte[,] Shape1 =
        {
            { 1, 1 },
            { 1, 1 },
        };

        protected override byte[][,] Shapes { get; } =
        {
            Shape1,
        };
    }
}