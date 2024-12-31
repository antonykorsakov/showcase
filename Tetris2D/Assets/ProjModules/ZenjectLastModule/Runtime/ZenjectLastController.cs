using System;

namespace ProjectFeatures.ZenjectModule.Runtime
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