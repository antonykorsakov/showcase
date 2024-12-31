using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStorage : ICameraStorage
    {
        private List<Camera> _cameraStack;

        public Camera GameplayCamera { get; private set; }
        public Camera UiCamera { get; private set; }

        public void SetGameplayCamera(Camera gameplayCamera)
        {
            RemoveOverlayCamera();
            GameplayCamera = gameplayCamera;
            _cameraStack = gameplayCamera.GetUniversalAdditionalCameraData().cameraStack;
            AddOverlayCamera();
        }

        public void SetUiCamera(Camera uiCamera)
        {
            RemoveOverlayCamera();
            UiCamera = uiCamera;
            AddOverlayCamera();
        }

        private void AddOverlayCamera()
        {
            if (_cameraStack == null)
                return;

            if (UiCamera == null)
                return;

            _cameraStack.Add(UiCamera);
            // CamerasSetupSuccessEvent?.Invoke();
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