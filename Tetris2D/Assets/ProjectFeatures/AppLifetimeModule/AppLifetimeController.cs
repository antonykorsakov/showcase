using System;

namespace ProjectFeatures.AppLifetimeModule
{
    public sealed class AppLifetimeController : IAppLifetimeController
    {
        public AppState AppState { get; private set; }

        public event Action AppStateChangedEvent;

        public void SetState(AppState value)
        {
            if (AppState == value)
                return;

            AppState = value;
        }
    }
}