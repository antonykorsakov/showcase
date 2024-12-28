using ProjectFeatures.CameraModule.Runtime;
using UnityEngine;

namespace ProjectRuntime.FeatureConfig
{
    [CreateAssetMenu(fileName = nameof(CameraConfig),
        menuName = "Configs/" + nameof(CameraConfig), order = 'C')]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private CameraStack _cameraStack;

        public CameraStack CameraStack => _cameraStack;
    }
}
