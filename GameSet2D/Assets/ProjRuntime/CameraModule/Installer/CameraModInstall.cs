using ProjModules.CameraModule.Runtime.Controller;
using ProjModules.CameraModule.Runtime.Data;
using ProjRuntime.CameraModule.Behavior;
using UnityEngine;
using Zenject;

namespace ProjRuntime.CameraModule.Installer
{
    public sealed class CameraModInstall : MonoInstaller<CameraModInstall>
    {
        [SerializeField] private CameraConfig _config;

        public override void InstallBindings()
        {
            // behaviors
            Container.BindInterfacesTo<CameraStackBeh>().AsSingle();
            Container.BindInterfacesTo<GameCameraFactoryBeh>().AsSingle();

            // main controllers
            Container.BindInterfacesTo<CameraStackController>().AsSingle();
            Container.BindInterfacesTo<GameCameraFactory>().AsSingle().WithArguments(_config.GameCamera);
        }
    }
}