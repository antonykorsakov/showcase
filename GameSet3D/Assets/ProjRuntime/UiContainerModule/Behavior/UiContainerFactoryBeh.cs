using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjModules.UiContainerModule.Runtime.Controller;
using Zenject;

namespace ProjRuntime.UiContainerModule.Behavior
{
    public class UiContainerFactoryBeh : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IUiContainerFactory UiContainerFactory { get; }

        public void Initialize()
        {
            AppLifetimeController.AppStateChangedEvent += CallFactory;
        }

        private void CallFactory()
        {
            switch (AppLifetimeController.AppState)
            {
                case AppState.AppBaseItemsLoading:
                    UiContainerFactory.Load(null).Forget();
                    break;

                case AppState.GameSelection:
                    UiContainerFactory.CleanReferences();
                    break;
            }
        }
    }
}