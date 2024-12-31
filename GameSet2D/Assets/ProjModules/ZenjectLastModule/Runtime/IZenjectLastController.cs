using System;

namespace ProjModules.ZenjectLastModule.Runtime
{
    public interface IZenjectLastController
    {
        bool Initialized { get; }

        event Action InitializedEvent;

        void Initialize();
    }
}