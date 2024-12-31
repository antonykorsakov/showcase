using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStackController : ICameraStackController
    {
        private List<Camera> _cameraStack;

        private Camera _gameplayCamera;
        private Camera _uiCamera;

        public void SetGameplayCamera(Camera gameplayCamera)
        {
            RemoveOverlayCamera();
            _gameplayCamera = gameplayCamera;
            _cameraStack = gameplayCamera.GetUniversalAdditionalCameraData().cameraStack;
            AddOverlayCamera();
        }

        public void SetUiCamera(Camera uiCamera)
        {
            RemoveOverlayCamera();
            _uiCamera = uiCamera;
            AddOverlayCamera();
        }

        private void AddOverlayCamera()
        {
            if (_cameraStack == null)
                return;

            if (_uiCamera == null)
                return;

            _cameraStack.Add(_uiCamera);
            // CamerasSetupSuccessEvent?.Invoke();
        }

        private void RemoveOverlayCamera()
        {
            if (_cameraStack == null)
                return;

            if (_uiCamera == null)
                return;

            _cameraStack.Remove(_uiCamera);
        }
    }
}