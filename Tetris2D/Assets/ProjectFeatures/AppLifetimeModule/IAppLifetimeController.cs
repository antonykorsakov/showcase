using System;

namespace ProjectFeatures.AppLifetimeModule
{
    public interface IAppLifetimeController
    {
        event Action AppStateChangedEvent;

        AppState AppState { get; }

        void SetState(AppState value);
    }
}