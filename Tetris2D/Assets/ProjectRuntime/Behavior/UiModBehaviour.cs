using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiModBehaviour : IInitializable
    {
        [Inject] private IUiController UiController { get; }

        public void Initialize()
        {
            UiController.LoadAndSetupUiPanelsContainer();
        }
    }
}