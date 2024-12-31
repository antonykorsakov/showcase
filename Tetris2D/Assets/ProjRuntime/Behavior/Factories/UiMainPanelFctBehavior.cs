using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.PrefabFactoryModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using ProjModules.UiContainerModule.Runtime.Controller;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiMainPanelFctBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IUiContainerController UiContainerController { get; }
        [Inject] private IPrefabFactory<UiMainPanelView> Factory { get; }

        public void Initialize()
        {
            AppLifetimeController.AppStateChangedEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.GameSelection)
                    Factory.CleanReferences();
            };

            UiContainerController.SetEvent += () =>
                Factory.Load(UiContainerController.Container).Forget();
        }
    }
}