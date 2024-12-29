using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiManager
    {
        Canvas Canvas { get; }
        Transform Container { get; }

        event Action PanelsContainerLoadedFailureEvent;
        event Action PanelsContainerSetupFailureEvent;
        event Action<UiPanelsContainer> PanelsContainerSetupSuccessEvent;

        UniTask LoadAndSetupUiPanelsContainer();
    }
}