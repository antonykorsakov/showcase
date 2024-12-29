using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UObject = UnityEngine.Object;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStorage : ICameraStorage
    {
        private readonly ICameraConfig _config;
        private List<Camera> _cameraStack;

        public CameraStorage(ICameraConfig config)
        {
            _config = config;
        }

        public Camera GameplayCamera { get; private set; }
        public Camera UiCamera { get; private set; }

        public event Action CamerasLoadedFailureEvent;
        public event Action CamerasSetupFailureEvent;
        public event Action CamerasSetupSuccessEvent;

        public async void SetGameplayCamera()
        {
            try
            {
                var items = await UObject.InstantiateAsync(_config.GameplayCamera);
                if (items is not { Length: 1 })
                {
                    CamerasSetupFailureEvent?.Invoke();
                    return;
                }

                SetGameplayCamera(items[0]);
            }
            catch (Exception ex)
            {
                CamerasLoadedFailureEvent?.Invoke();
            }
        }

        public void SetUiCamera(Camera uiCamera)
        {
            RemoveOverlayCamera();
            UiCamera = uiCamera;
            AddOverlayCamera();
        }

        private void SetGameplayCamera(Camera gameplayCamera)
        {
            RemoveOverlayCamera();
            GameplayCamera = gameplayCamera;
            _cameraStack = gameplayCamera.GetUniversalAdditionalCameraData().cameraStack;
            AddOverlayCamera();
        }


        private void AddOverlayCamera()
        {
            if (_cameraStack == null)
                return;

            if (UiCamera == null)
                return;

            _cameraStack.Add(UiCamera);
            CamerasSetupSuccessEvent?.Invoke();
        }

        private void RemoveOverlayCamera()
        {
            if (_cameraStack == null)
                return;

            if (UiCamera == null)
                return;

            _cameraStack.Remove(UiCamera);
        }
    }
}