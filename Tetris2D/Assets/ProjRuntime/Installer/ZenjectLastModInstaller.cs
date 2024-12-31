using ProjectFeatures.ZenjectModule.Runtime;
using ProjectRuntime.Behavior;
using Zenject;

namespace ProjectRuntime.Installer
{
    public class ZenjectLastModInstaller : MonoInstaller<ZenjectLastModInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ZenjectLastModBehavior>().AsSingle();
            Container.BindInterfacesTo<ZenjectLastController>().AsSingle();
        }
    }
}