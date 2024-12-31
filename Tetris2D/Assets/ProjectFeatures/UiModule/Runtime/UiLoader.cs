using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectFeatures.CoreModule.Runtime;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiLoader : IUiLoader
    {
        private readonly IUiConfig _config;

        public UiLoader(IUiConfig config)
        {
            _config = config;
        }

        public UiPanelsContainer UiPanelsContainer { get; private set; }

        public event Action LoadedFailureEvent;
        public event Action LoadedSuccessEvent;

        public async UniTask Load()
        {
            try
            {
                var item = await InstantiateFactory.InstantiateAsync(_config.UiPanelsContainer, null,
                    null, null, CancellationToken.None);
                //cancellationToken.ThrowIfCancellationRequested();

                UiPanelsContainer = item;
                LoadedSuccessEvent?.Invoke();
            }
            catch (Exception ex)
            {
                LoadedFailureEvent?.Invoke();
            }
        }
    }
}