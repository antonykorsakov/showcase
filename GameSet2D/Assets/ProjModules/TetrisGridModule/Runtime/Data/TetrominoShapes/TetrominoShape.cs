namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public abstract class TetrominoShape
    {
        protected abstract byte[][,] Shapes { get; }

        public byte GetCellValue(int rotateType, int x, int y)
        {
            return Shapes[rotateType][x, y];
        }
    }
}