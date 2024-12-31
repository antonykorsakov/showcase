using System;

namespace ProjModules.AppLifetimeModule.Runtime
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
            AppStateChangedEvent?.Invoke();
        }
    }
}