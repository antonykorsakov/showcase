using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public interface ICameraConfig
    {
        Camera GameplayCamera { get; }
    }
}