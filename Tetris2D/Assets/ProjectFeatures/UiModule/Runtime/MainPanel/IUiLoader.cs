using System;
using Cysharp.Threading.Tasks;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiLoader
    {
        UiPanelsContainer UiPanelsContainer { get; }

        event Action LoadedFailureEvent;
        event Action LoadedSuccessEvent;

        UniTask Load();
    }
}