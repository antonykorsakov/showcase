using System;

namespace ProjectFeatures.ZenjectModule.Runtime
{
    public interface IZenjectLastController
    {
        bool Initialized { get; }

        event Action InitializedEvent;

        void Initialize();
    }
}