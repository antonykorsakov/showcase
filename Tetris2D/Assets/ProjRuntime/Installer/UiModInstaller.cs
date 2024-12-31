using ProjectFeatures.UiModule.Runtime;
using ProjectRuntime.Behavior;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Installer
{
    public class UiModInstaller : MonoInstaller<UiModInstaller>
    {
        [SerializeField] private UiConfig _config;

        public override void InstallBindings()
        {
            // UiMainPanel
            Container.BindInterfacesTo<UiMainPanelFactory>().AsSingle().WithArguments(_config.UiMainPanelView);
            Container.BindInterfacesTo<UiMainPanelFctBehavior>().AsSingle();
            Container.BindInterfacesTo<UiMainPanelController>().AsSingle();
        }
    }
}