namespace ProjModules.TetrisGridModule.Runtime
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