using System;
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

        void LoadAndSetupCamera();
    }
}