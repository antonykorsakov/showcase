using ProjModules.UiContainerModule.Runtime.Controller;
using Zenject;

namespace ProjRuntime.UiContainerModule.Behavior
{
    public class UiContainerBehavior : IInitializable
    {
        [Inject] private IUiContainerController UiContainerController { get; }
        [Inject] private IUiContainerFactory UiContainerFactory { get; }

        public void Initialize()
        {
            UiContainerFactory.CompletedEvent += () =>
                UiContainerController.SetupContainer(UiContainerFactory.Item.Canvas);
        }
    }
}