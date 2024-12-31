using System;
using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.PrefabFactoryModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiPanelsContainerFctBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IPrefabFactory<UiPanelsContainerView> Factory { get; }

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