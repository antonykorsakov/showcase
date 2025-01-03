namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public class TetrominoShapeT : TetrominoShape
    {
        private static readonly byte[,] Shape1 =
        {
            { 1, 1, 1 },
            { 0, 1, 0 },
        };

        private static readonly byte[,] Shape2 =
        {
            { 0, 1 },
            { 1, 1 },
            { 0, 1 },
        };

        private static readonly byte[,] Shape3 =
        {
            { 0, 1, 0 },
            { 1, 1, 1 },
        };

        private static readonly byte[,] Shape4 =
        {
            { 1, 0 },
            { 1, 1 },
            { 1, 0 },
        };

        protected override byte[][,] Shapes { get; } =
        {
            Shape1,
            Shape2,
            Shape3,
            Shape4,
        };
    }
}