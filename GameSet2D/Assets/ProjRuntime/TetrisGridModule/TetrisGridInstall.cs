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
            Container.BindInterfacesTo<TetrisGridBeh>().AsSingle();
            Container.BindInterfacesTo<TetrisGridController>().AsSingle().WithArguments(_config);
        }
    }
}