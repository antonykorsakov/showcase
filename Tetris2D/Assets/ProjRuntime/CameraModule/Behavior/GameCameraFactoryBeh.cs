using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjModules.CameraModule.Runtime.Controller;
using Zenject;

namespace ProjRuntime.CameraModule.Behavior
{
    public sealed class GameCameraFactoryBeh : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IGameCameraFactory GameCameraFactory { get; }

        public void Initialize()
        {
            AppLifetimeController.AppStateChangedEvent += CallFactory;
        }

        private void CallFactory()
        {
            switch (AppLifetimeController.AppState)
            {
                case AppState.AppBaseItemsLoading:
                    GameCameraFactory.Load(null).Forget();
                    break;

                case AppState.GameSelection:
                    GameCameraFactory.CleanReferences();
                    break;
            }
        }
    }
}