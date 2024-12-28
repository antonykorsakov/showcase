using System;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStorage : ICameraStorage
    {
        private readonly ICameraConfig _config;

        public CameraStorage(ICameraConfig config)
        {
            _config = config;
        }

        public Camera GameplayCamera { get; private set; }
        public Camera UiCamera { get; private set; }

        public event Action CamerasLoadedFailureEvent;
        public event Action CamerasSetupFailureEvent;
        public event Action CamerasSetupSuccessEvent;

        public async void LoadAndSetupCamera()
        {
            try
            {
                var cameraStacks = await UObject.InstantiateAsync(_config.CameraStack);
                SetupCameras(cameraStacks);
            }
            catch (Exception ex)
            {
                CamerasLoadedFailureEvent?.Invoke();
            }
        }

        private void SetupCameras(CameraStack[] cameraStacks)
        {
            if (cameraStacks is not { Length: 1 })
            {
                CamerasSetupFailureEvent?.Invoke();
                return;
            }

            GameplayCamera = cameraStacks[0].GameplayCamera;
            UiCamera = cameraStacks[0].UiCamera;
            CamerasSetupSuccessEvent?.Invoke();
        }
    }
}