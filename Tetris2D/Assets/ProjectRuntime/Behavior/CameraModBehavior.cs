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
        [Inject] private IGameplayCameraLoader GameplayCameraLoader { get; }
        [Inject] private IUiLoader UiLoader { get; }

        public void Initialize()
        {
            GameplayCameraLoader.LoadedSuccessEvent += SetCameraStack;
            UiLoader.LoadedSuccessEvent += SetCameraStack;

            GameplayCameraLoader.Load();
        }

        private void SetCameraStack()
        {
            if (GameplayCameraLoader.GameplayCamera == null)
                return;

            if (UiLoader.UiPanelsContainer == null)
                return;

            CameraStorage.SetGameplayCamera(GameplayCameraLoader.GameplayCamera);
            CameraStorage.SetUiCamera(UiLoader.UiPanelsContainer.UiCamera);
        }
    }
}