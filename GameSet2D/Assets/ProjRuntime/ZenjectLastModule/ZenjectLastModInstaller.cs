using ProjModules.ZenjectLastModule.Runtime;
using Zenject;

namespace ProjRuntime.ZenjectLastModule
{
    public class ZenjectLastModInstaller : MonoInstaller<ZenjectLastModInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ZenjectLastModBeh>().AsSingle();
            Container.BindInterfacesTo<ZenjectLastController>().AsSingle();
        }
    }
}