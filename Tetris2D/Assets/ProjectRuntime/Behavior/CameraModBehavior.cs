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
            // CameraStorage.SetGameplayCamera();

            UiManager.PanelsContainerSetupSuccessEvent += uiPanelsContainer
                => CameraStorage.SetUiCamera(uiPanelsContainer.UiCamera);
        }
    }
}