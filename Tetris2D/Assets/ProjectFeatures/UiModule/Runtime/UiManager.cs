using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ProjectFeatures.UiModule.Runtime
{
    public sealed class UiManager : IUiManager
    {
        private readonly IUiConfig _config;

        public UiManager(IUiConfig config)
        {
            _config = config;
        }

        public Canvas Canvas { get; private set; }
        public Transform Container { get; private set; }

        public event Action PanelsContainerLoadedFailureEvent;
        public event Action PanelsContainerSetupFailureEvent;
        public event Action<UiPanelsContainer> PanelsContainerSetupSuccessEvent;

        public async UniTask LoadAndSetupUiPanelsContainer()
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

                var xItems = await UObject.InstantiateAsync(_config.MainUiPanel, Container);
                xItems[0].transform.localPosition = Vector3.zero;
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