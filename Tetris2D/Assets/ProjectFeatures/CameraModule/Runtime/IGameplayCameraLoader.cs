using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public interface IGameplayCameraLoader
    {
        Camera GameplayCamera { get; }

        event Action LoadedFailureEvent;
        event Action LoadedSuccessEvent;

        UniTask Load();
    }
}