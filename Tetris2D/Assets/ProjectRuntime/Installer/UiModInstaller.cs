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
            // UiPanelsContainer
            Container.BindInterfacesTo<UiPanelsContainerFactory>().AsSingle().WithArguments(_config.UiPanelsContainerView);
            Container.BindInterfacesTo<UiPanelsContainerFctBehavior>().AsSingle();
            Container.BindInterfacesTo<UiPanelsContainerController>().AsSingle();
            Container.BindInterfacesTo<UiPanelsContainerBehavior>().AsSingle();

            // UiMainPanel
            Container.BindInterfacesTo<UiMainPanelFactory>().AsSingle().WithArguments(_config.UiMainPanelView);
            Container.BindInterfacesTo<UiMainPanelFctBehavior>().AsSingle();
            Container.BindInterfacesTo<UiMainPanelController>().AsSingle();
        }
    }
}