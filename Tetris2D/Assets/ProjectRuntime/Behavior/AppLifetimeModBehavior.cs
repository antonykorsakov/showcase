using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.JsonModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class AppLifetimeModBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private ICameraStorage CameraStorage { get; }
        [Inject] private IJsonController JsonController { get; }
        [Inject] private IUiController UiController { get; }

        public async void Initialize()
        {
            CameraStorage.SetGameplayCamera().Forget();
            // await UniTask.Delay(3000);
            UiController.LoadAndSetupUiPanelsContainer().Forget();;
        }
    }
}