using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiModBehaviour : IInitializable
    {
        [Inject] private ICameraStorage CameraStorage { get; }
        [Inject] private IUiController UiController { get; }

        public void Initialize()
        {
            // setup ui camera
            CameraStorage.CamerasSetupSuccessEvent += SetupUiCamera;
            UiController.PanelsContainerSetupSuccessEvent += SetupUiCamera;
            SetupUiCamera();

            UiController.LoadAndSetupUiPanelsContainer();
        }

        private void SetupUiCamera()
        {
            Debug.LogError($"{CameraStorage.UiCamera == null}; {UiController.Canvas == null}");

            if (CameraStorage.UiCamera == null)
                return;

            if (UiController.Canvas == null)
                return;

            UiController.Canvas.worldCamera = CameraStorage.UiCamera;
        }
    }
}