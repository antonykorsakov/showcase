using ProjModules.TetrisGridModule.Runtime;
using Zenject;

namespace ProjRuntime.TetrisGridModule
{
    public class TetrisGridBeh : IInitializable
    {
        [Inject] private ITetrisGridController TetrisGridController { get; }

        public void Initialize()
        {
        }
    }
}