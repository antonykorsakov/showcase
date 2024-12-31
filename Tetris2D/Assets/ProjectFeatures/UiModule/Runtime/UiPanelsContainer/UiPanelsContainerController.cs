using System;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiPanelsContainerController : IUiPanelsContainerController
    {
        public Canvas Canvas { get; private set; }
        public Transform Container { get; private set; }

        public event Action SetEvent;

        public void SetupContainer(Canvas canvas)
        {
            Canvas = canvas;
            Container = Canvas.transform;
            SetEvent?.Invoke();
        }
    }
}