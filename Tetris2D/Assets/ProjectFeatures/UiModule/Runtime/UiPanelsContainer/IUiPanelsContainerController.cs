using System;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiPanelsContainerController
    {
        Canvas Canvas { get; }
        Transform Container { get; }

        event Action SetEvent;

        void SetupContainer(Canvas canvas);
    }
}