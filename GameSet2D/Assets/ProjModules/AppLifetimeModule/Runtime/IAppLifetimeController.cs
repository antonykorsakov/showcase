using System;

namespace ProjModules.AppLifetimeModule.Runtime
{
    public interface IAppLifetimeController
    {
        event Action AppStateChangedEvent;

        AppState AppState { get; }

        void SetState(AppState value);
    }
}