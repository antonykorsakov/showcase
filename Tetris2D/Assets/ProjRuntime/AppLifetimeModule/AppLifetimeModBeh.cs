using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.UiModule.Runtime;
using ProjectFeatures.ZenjectModule.Runtime;
using ProjModules.UiMainPanel.Runtime.Controller;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class AppLifetimeModBeh : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IUiMainPanelController UiMainPanelController { get; }
        [Inject] private IZenjectLastController ZenjectLastController { get; }

        public void Initialize()
        {
            ZenjectLastController.InitializedEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.AppInitializing)
                    AppLifetimeController.SetState(AppState.AppBaseItemsLoading);
            };

            UiMainPanelController.TetrisButtonClickEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.GameSelection)
                    AppLifetimeController.SetState(AppState.TetrisGameplay);
            };

            UiMainPanelController.Match3ButtonClickEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.GameSelection)
                    AppLifetimeController.SetState(AppState.Match3Gameplay);
            };
        }
    }
}