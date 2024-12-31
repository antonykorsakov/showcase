using ProjectRuntime.Behavior;
using ProjModules.JsonModule.Runtime;
using Zenject;

namespace ProjectRuntime.Installer
{
    public sealed class JsonModInstall : MonoInstaller<JsonModInstall>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JsonControllerBeh>().AsSingle();
            Container.BindInterfacesTo<JsonController>().AsSingle();
        }
    }
}
