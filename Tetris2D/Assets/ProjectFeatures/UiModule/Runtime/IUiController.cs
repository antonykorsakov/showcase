using System;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiController
    {
        Canvas Canvas { get; }
        Transform Container { get; }

        event Action PanelsContainerLoadedFailureEvent;
        event Action PanelsContainerSetupFailureEvent;
        event Action PanelsContainerSetupSuccessEvent;

        void LoadAndSetupUiPanelsContainer();
    }
}