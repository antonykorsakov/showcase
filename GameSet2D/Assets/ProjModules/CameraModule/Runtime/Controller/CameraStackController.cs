using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ProjModules.CameraModule.Runtime.Controller
{
    public class CameraStackController : ICameraStackController
    {
        private List<Camera> _cameraStack;

        private Camera _gameplayCamera;
        private Camera _uiCamera;

        public void SetGameCamera(Camera value)
        {
            RemoveOverlayCamera();
            _gameplayCamera = value;
            _cameraStack = value.GetUniversalAdditionalCameraData().cameraStack;
            AddOverlayCamera();
        }

        public void SetUiCamera(Camera value)
        {
            RemoveOverlayCamera();
            _uiCamera = value;
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