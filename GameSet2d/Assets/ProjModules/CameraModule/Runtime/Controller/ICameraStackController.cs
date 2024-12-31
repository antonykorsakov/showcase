using UnityEngine;

namespace ProjModules.CameraModule.Runtime.Controller
{
    public interface ICameraStackController
    {
        void SetGameCamera(Camera value);
        void SetUiCamera(Camera value);
    }
}