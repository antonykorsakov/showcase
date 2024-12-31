using Cysharp.Threading.Tasks;
using ProjModules.AppLifetimeModule.Runtime;
using ProjModules.PrefabFactoryModule.Runtime;
using ProjModules.UiContainerModule.Runtime.Controller;
using ProjModules.UiMainPanel.Runtime;
using Zenject;

namespace ProjRuntime.UiMainPanel.Behavior
{
    public class UiMainPanelFactoryBeh : IInitializable
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