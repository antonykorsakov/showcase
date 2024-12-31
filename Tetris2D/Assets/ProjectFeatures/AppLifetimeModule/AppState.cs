namespace ProjectFeatures.AppLifetimeModule
{
    public enum AppState
    {
        /// <summary>
        /// Waiting for Unity to initialize.
        /// </summary>
        AppInitializing = 0,
        
        /// <summary>
        /// Waiting for approve GDPR (General Data Protection Regulation)
        /// </summary>
        GDPR,

        /// <summary>
        /// The state where the player can select a game (e.g., Main UI Panel).
        /// </summary>
        GameSelection,

        /// <summary>
        /// The player selected Tetris and is now playing.
        /// </summary>
        TetrisGameplay,

        /// <summary>
        /// The player selected Match3 and is now playing.
        /// </summary>
        Match3Gameplay,
    }
}