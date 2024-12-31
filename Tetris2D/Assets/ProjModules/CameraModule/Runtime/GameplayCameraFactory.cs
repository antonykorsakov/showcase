using ProjectFeatures.PrefabFactoryModule.Runtime;
using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class GameplayCameraFactory : PrefabFactory<Camera>
    {
        public GameplayCameraFactory(Camera original) : base(original)
        { }
    }
}