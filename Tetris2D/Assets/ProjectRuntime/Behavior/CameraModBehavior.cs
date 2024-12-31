using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class CameraModBehavior : IInitializable
    {
        [Inject] private ICameraStorage CameraStorage { get; }
        [Inject] private IUiManager UiManager { get; }

        public void Initialize()
        {
            var cancellationToken = new CancellationToken(false);
            CameraStorage.SetGameplayCamera(cancellationToken).Forget();

            // CameraStorage.SetGameplayCamera();

            UiManager.PanelsContainerSetupSuccessEvent += _ => SetCameraStack();
        }

        private void SetCameraStack()
        {
            if (CameraStorage.GameplayCamera == null)
                return;
            
            if (UiManager.Canvas == null)
                return;
            
            // CameraStorage.SetUiCamera(uiPanelsContainer.UiCamera)
        }
    }
}