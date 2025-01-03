using ProjModules.TetrisGridModule.Runtime;
using ProjModules.TetrisGridModule.Runtime.Data;
using UnityEngine;
using Zenject;

namespace ProjRuntime.TetrisGridModule
{
    public class TetrisGridInstall : MonoInstaller<TetrisGridInstall>
    {
        [SerializeField] private TetrisGridConfig _config;

        public override void InstallBindings()
        {
            // behaviors
            Container.BindInterfacesTo<TetrisGridBeh>().AsSingle();

            // main controllers
            Container.BindInterfacesTo<GridManager>().AsSingle().WithArguments(_config.Tmp);
            Container.BindInterfacesTo<GridDataController>().AsSingle().WithArguments(_config);
            Container.BindInterfacesTo<GridRendererController>().AsSingle().WithArguments(_config);
        }
    }
}