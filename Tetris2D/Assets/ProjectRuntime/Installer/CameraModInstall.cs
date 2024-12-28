using ProjectFeatures.CameraModule.Runtime;
using ProjectRuntime.Behavior;
using Zenject;

namespace ProjectRuntime.Installer
{
    public class CameraModInstall : MonoInstaller<CameraModInstall>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraModBehavior>().AsSingle();
            Container.BindInterfacesTo<CameraStorage>().AsSingle();
        }
    }
}