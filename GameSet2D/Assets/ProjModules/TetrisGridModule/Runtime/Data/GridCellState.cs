namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public enum GridCellState : byte
    {
        Empty = 0x0,

        //
        ControlledTetromino,
        StoppedTetromino,

        // for an additional game mode
        UnbreakableWall,

        //
        Error = 0xFF,
    }
}