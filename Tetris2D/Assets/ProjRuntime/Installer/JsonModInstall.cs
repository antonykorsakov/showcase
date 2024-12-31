using ProjectFeatures.JsonModule.Runtime;
using ProjectRuntime.Behavior;
using Zenject;

namespace ProjectRuntime.Installer
{
    public sealed class JsonModInstall : MonoInstaller<JsonModInstall>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JsonModBehavior>().AsSingle();
            Container.BindInterfacesTo<JsonController>().AsSingle();
        }
    }
}
