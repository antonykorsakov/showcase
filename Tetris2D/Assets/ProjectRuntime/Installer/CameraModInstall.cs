using ProjectFeatures.CameraModule.Runtime;
using ProjectRuntime.Behavior;
using ProjectRuntime.FeatureConfig;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Installer
{
    public sealed class CameraModInstall : MonoInstaller<CameraModInstall>
    {
        [SerializeField] private CameraConfig _config;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraModBehavior>().AsSingle();
            Container.BindInterfacesTo<CameraStorage>().AsSingle();
            Container.BindInterfacesTo<GameplayCameraLoader>().AsSingle().WithArguments(_config);
        }
    }
}