using ProjectFeatures.SceneModule;
using ProjectRuntime.Behavior;
using Zenject;

namespace ProjectRuntime.Installer
{
    public class SceneModInstall : MonoInstaller<SceneModInstall>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneModBehavior>().AsSingle();
            Container.BindInterfacesTo<ScenesController>().AsSingle();
        }
    }
}