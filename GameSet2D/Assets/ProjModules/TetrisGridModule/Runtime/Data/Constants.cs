using System.Collections.Generic;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    internal static class Constants
    {
        public static Dictionary<TetrominoType, TetrominoShape> AllTetrominoShapes { get; } = new()
        {
            { TetrominoType.I, new TetrominoShapeI() },
            { TetrominoType.O, new TetrominoShapeO() },
            { TetrominoType.T, new TetrominoShapeT() },
        };
    }
}