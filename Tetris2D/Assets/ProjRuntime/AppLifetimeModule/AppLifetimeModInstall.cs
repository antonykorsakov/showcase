using ProjectFeatures.AppLifetimeModule;
using ProjectRuntime.Behavior;
using Zenject;

namespace ProjectRuntime.Installer
{
    public sealed class AppLifetimeModInstall : MonoInstaller<AppLifetimeModInstall>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AppLifetimeModBeh>().AsSingle();
            Container.BindInterfacesTo<AppLifetimeController>().AsSingle();
        }
    }
}