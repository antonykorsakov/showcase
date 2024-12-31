using System;

namespace ProjModules.ZenjectLastModule.Runtime
{
    public class ZenjectLastController : IZenjectLastController
    {
        public bool Initialized { get; private set; }

        public event Action InitializedEvent;

        public void Initialize()
        {
            Initialized = true;
            InitializedEvent?.Invoke();
        }
    }
}