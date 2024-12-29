using System;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ProjectFeatures.UiModule.Runtime
{
    public sealed class UiController : IUiController
    {
        private readonly IUiConfig _config;

        public UiController(IUiConfig config)
        {
            _config = config;
        }

        public Canvas Canvas { get; private set; }
        public Transform Container { get; private set; }

        public event Action PanelsContainerLoadedFailureEvent;
        public event Action PanelsContainerSetupFailureEvent;
        public event Action<UiPanelsContainer> PanelsContainerSetupSuccessEvent;

        public async void LoadAndSetupUiPanelsContainer()
        {
            try
            {
                var items = await UObject.InstantiateAsync(_config.UiPanelsContainer);
                if (items is not { Length: 1 })
                {
                    PanelsContainerSetupFailureEvent?.Invoke();
                    return;
                }
                
                SetupContainer(items[0]);
            }
            catch (Exception ex)
            {
                PanelsContainerLoadedFailureEvent?.Invoke();
            }
        }

        private void SetupContainer(UiPanelsContainer uiPanelsContainers)
        {
            Canvas = uiPanelsContainers.Canvas;
            Container = Canvas.transform;
            PanelsContainerSetupSuccessEvent?.Invoke(uiPanelsContainers);
        }
    }
}