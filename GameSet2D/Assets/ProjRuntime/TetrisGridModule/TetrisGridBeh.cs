using ProjModules.TetrisGridModule.Runtime;
using Zenject;

namespace ProjRuntime.TetrisGridModule
{
    public class TetrisGridBeh : IInitializable
    {
        [Inject] private IGridDataController GridDataController { get; }
        [Inject] private IGridManager GridManager { get; }

        public void Initialize()
        {
            GridManager.Enable();
        }
    }
}