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
            Container.BindInterfacesTo<UiModBehaviour>().AsSingle();
            Container.BindInterfacesTo<UiController>().AsSingle().WithArguments(_config);
        }
    }
}