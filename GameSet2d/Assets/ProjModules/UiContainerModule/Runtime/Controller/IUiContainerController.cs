using System;
using UnityEngine;

namespace ProjModules.UiContainerModule.Runtime.Controller
{
    public interface IUiContainerController
    {
        Canvas Canvas { get; }
        Transform Container { get; }

        event Action SetEvent;

        void SetupContainer(Canvas canvas);
    }
}