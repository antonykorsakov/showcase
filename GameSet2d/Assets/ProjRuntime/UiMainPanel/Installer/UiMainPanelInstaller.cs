using ProjModules.UiMainPanel.Runtime.Controller;
using ProjModules.UiMainPanel.Runtime.Data;
using ProjRuntime.UiMainPanel.Behavior;
using UnityEngine;
using Zenject;

namespace ProjRuntime.UiMainPanel.Installer
{
    public class UiMainPanelInstaller : MonoInstaller<UiMainPanelInstaller>
    {
        [SerializeField] private UiMainPanelConfig _config;

        public override void InstallBindings()
        {
            // behaviors
            Container.BindInterfacesTo<UiMainPanelFactoryBeh>().AsSingle();
            Container.BindInterfacesTo<UiMainPanelControllerBeh>().AsSingle();

            // main controllers
            Container.BindInterfacesTo<UiMainPanelFactory>().AsSingle().WithArguments(_config.UiMainPanelView);
            Container.BindInterfacesTo<UiMainPanelController>().AsSingle();
        }
    }
}