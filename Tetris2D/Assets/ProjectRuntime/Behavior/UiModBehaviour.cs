using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiModBehaviour : IInitializable
    {
        [Inject] private IUiManager UiManager { get; }

        public void Initialize()
        {
            // UiController.LoadAndSetupUiPanelsContainer();
        }
    }
}