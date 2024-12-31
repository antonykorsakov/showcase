using ProjectRuntime.Installer;
using ProjModules.UiContainerModule.Runtime.Controller;
using ProjModules.UiContainerModule.Runtime.Data;
using ProjRuntime.UiContainerModule.Behavior;
using UnityEngine;
using Zenject;

namespace ProjRuntime.UiContainerModule.Installer
{
    public class UiPanelsContainerInstaller : MonoInstaller<UiModInstaller>
    {
        [SerializeField] private UiContainerConfig _config;

        public override void InstallBindings()
        {
            // behaviors
            Container.BindInterfacesTo<UiContainerFactoryBehavior>().AsSingle();
            Container.BindInterfacesTo<UiContainerBehavior>().AsSingle();

            // main controllers
            Container.BindInterfacesTo<UiContainerFactory>().AsSingle().WithArguments(_config.UiContainerView);
            Container.BindInterfacesTo<UiContainerController>().AsSingle();
        }
    }
}