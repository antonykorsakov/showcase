using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class CameraModBehavior : IInitializable
    {
        [Inject] private ICameraStorage CameraStorage { get; }
        [Inject] private IUiController UiController { get; }

        public void Initialize()
        {
            CameraStorage.SetGameplayCamera();

            UiController.PanelsContainerSetupSuccessEvent += uiPanelsContainer
                => CameraStorage.SetUiCamera(uiPanelsContainer.UiCamera);
        }
    }
}