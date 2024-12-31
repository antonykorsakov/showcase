using ProjModules.PrefabFactoryModule.Runtime;
using UnityEngine;

namespace ProjModules.CameraModule.Runtime.Controller
{
    public class GameCameraFactory : PrefabFactory<Camera>, IGameCameraFactory
    {
        public GameCameraFactory(Camera original) : base(original)
        { }
    }
}