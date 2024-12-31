using ProjectFeatures.UiModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class UiModBehaviour : IInitializable
    {
        [Inject] private IUiManager UiManager { get; }
        [Inject] private IMainUiController MainUiController { get; }

        public async void Initialize()
        {
            await UiManager.LoadAndSetupUiPanelsContainer();
            var item = Resources.FindObjectsOfTypeAll<MainUiPanel>()[0];
            MainUiController.SetPanel(item);
            MainUiController.FadeInPanel();
        }
    }
}