using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectFeatures.CoreModule.Runtime;
using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class GameplayCameraLoader : IGameplayCameraLoader
    {
        private readonly ICameraConfig _config;

        public GameplayCameraLoader(ICameraConfig config)
        {
            _config = config;
        }

        public Camera GameplayCamera { get; private set; }

        public event Action LoadedFailureEvent;
        public event Action LoadedSuccessEvent;

        public async UniTask Load()
        {
            try
            {
                var item = await InstantiateFactory.InstantiateAsync(_config.GameplayCamera, null,
                    null, null, CancellationToken.None);
                //cancellationToken.ThrowIfCancellationRequested();

                GameplayCamera = item;
                LoadedSuccessEvent?.Invoke();
            }
            catch (Exception ex)
            {
                LoadedFailureEvent?.Invoke();
            }
        }
    }
}