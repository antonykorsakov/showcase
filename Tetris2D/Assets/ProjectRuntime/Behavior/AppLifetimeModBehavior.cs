using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.UiModule.Runtime;
using ProjectFeatures.ZenjectModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class AppLifetimeModBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private IMainUiController MainUiController { get; }
        [Inject] private IZenjectLastController ZenjectLastController { get; }

        public void Initialize()
        {
            ZenjectLastController.InitializedEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.AppInitializing)
                    AppLifetimeController.SetState(AppState.GDPR);
                
                if (AppLifetimeController.AppState == AppState.GDPR)
                    AppLifetimeController.SetState(AppState.GameSelection);
            };
            
            MainUiController.TetrisButtonClickEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.GameSelection)
                    AppLifetimeController.SetState(AppState.TetrisGameplay);
            };
            
            MainUiController.Match3ButtonClickEvent += () =>
            {
                if (AppLifetimeController.AppState == AppState.GameSelection)
                    AppLifetimeController.SetState(AppState.Match3Gameplay);
            };
        }
    }
}