using System;
using UnityEngine;

namespace ProjModules.UiContainerModule.Runtime.Controller
{
    public class UiContainerController : IUiContainerController
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