using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public interface ICameraStorage
    {
        Camera GameplayCamera { get; }
        Camera UiCamera { get; }

        event Action CamerasLoadedFailureEvent;
        event Action CamerasSetupFailureEvent;
        event Action CamerasSetupSuccessEvent;

        UniTask SetGameplayCamera();
        void SetUiCamera(Camera uiCamera);
    }
}