using ProjectRuntime.Installer;
using ProjModules.UiContainerModule.Runtime.Controller;
using ProjModules.UiContainerModule.Runtime.Data;
using ProjRuntime.UiContainerModule.Behavior;
using ProjRuntime.UiMainPanel.Installer;
using UnityEngine;
using Zenject;

namespace ProjRuntime.UiContainerModule.Installer
{
    public class UiPanelsContainerInstaller : MonoInstaller<UiMainPanelInstaller>
    {
        [SerializeField] private UiContainerConfig _config;

        public override void InstallBindings()
        {
            // behaviors
            Container.BindInterfacesTo<UiContainerFactoryBeh>().AsSingle();
            Container.BindInterfacesTo<UiContainerBeh>().AsSingle();

            // main controllers
            Container.BindInterfacesTo<UiContainerFactory>().AsSingle().WithArguments(_config.UiContainerView);
            Container.BindInterfacesTo<UiContainerController>().AsSingle();
        }
    }
}