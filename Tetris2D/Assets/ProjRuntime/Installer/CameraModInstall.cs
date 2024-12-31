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
            Container.BindInterfacesTo<GameplayCameraFactory>().AsSingle().WithArguments(_config.GameplayCamera);
            Container.BindInterfacesTo<GameplayCameraFctBehavior>().AsSingle();

            Container.BindInterfacesTo<CameraStackController>().AsSingle();
            Container.BindInterfacesTo<CameraStackBehavior>().AsSingle();
        }
    }
}