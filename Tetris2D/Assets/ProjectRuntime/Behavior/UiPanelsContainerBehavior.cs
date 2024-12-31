using ProjectFeatures.PrefabFactoryModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiPanelsContainerBehavior : IInitializable
    {
        [Inject] private IUiPanelsContainerController UiPanelsContainerController { get; }
        [Inject] private IPrefabFactory<UiPanelsContainerView> UiPanelsContainerFactory { get; }

        public void Initialize()
        {
            UiPanelsContainerFactory.CompletedEvent += () =>
                UiPanelsContainerController.SetupContainer(UiPanelsContainerFactory.Item.Canvas);
        }
    }
}