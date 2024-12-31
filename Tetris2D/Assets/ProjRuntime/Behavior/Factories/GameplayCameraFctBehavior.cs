using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.PrefabFactoryModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class GameplayCameraFctBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IPrefabFactory<Camera> Factory { get; }

        public void Initialize()
        {
            AppLifetimeController.AppStateChangedEvent += CallFactory;
        }

        private void CallFactory()
        {
            switch (AppLifetimeController.AppState)
            {
                case AppState.AppBaseItemsLoading:
                    Factory.Load(null).Forget();
                    break;

                case AppState.GameSelection:
                    Factory.CleanReferences();
                    break;
            }
        }
    }
}