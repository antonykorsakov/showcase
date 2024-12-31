using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public interface ICameraStorage
    {
        void SetGameplayCamera(Camera gameplayCamera);
        void SetUiCamera(Camera uiCamera);
    }
}