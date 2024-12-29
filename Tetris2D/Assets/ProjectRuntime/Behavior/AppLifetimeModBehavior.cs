using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectFeatures.AppLifetimeModule;
using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.JsonModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class AppLifetimeModBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }
        [Inject] private ICameraStorage CameraStorage { get; }
        [Inject] private IJsonController JsonController { get; }
        [Inject] private IUiManager UiManager { get; }
        [Inject] private IMainUiController MainUiController { get; }

        public async void Initialize()
        {
            var cancellationToken = new CancellationToken(false);

            CameraStorage.SetGameplayCamera(cancellationToken).Forget();
            // await UniTask.Delay(3000);
            await UiManager.LoadAndSetupUiPanelsContainer();
            var item = Resources.FindObjectsOfTypeAll<MainUiPanel>()[0];
            MainUiController.SetPanel(item);
            MainUiController.FadeInPanel();
        }
    }
}