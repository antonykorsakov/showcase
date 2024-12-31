using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public interface ICameraStackController
    {
        void SetGameplayCamera(Camera gameplayCamera);
        void SetUiCamera(Camera uiCamera);
    }
}