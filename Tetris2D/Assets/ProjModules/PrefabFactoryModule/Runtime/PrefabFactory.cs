using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ProjModules.PrefabFactoryModule.Runtime
{
    public abstract class PrefabFactory<T> : IPrefabFactory<T>
        where T : Component
    {
        private readonly T _original;

        protected PrefabFactory(T original)
        {
            _original = original;
        }

        public T Item { get; private set; }

        public event Action UnityOperationErrorEvent;
        public event Action ClonedItemErrorEvent;
        public event Action CancelledEvent;
        public event Action CompletedEvent;

        public async UniTask<T> Load(Transform parent)
            => await InstantiateAsync(_original, parent, CancellationToken.None);

        public void CleanReferences() => Item = null;

        private async UniTask<T> InstantiateAsync(T original, Transform parent, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var zeroPos = Vector3.zero;
                var zeroTurn = Quaternion.identity;
                var result = await UObject.InstantiateAsync(original, 1, parent, zeroPos, zeroTurn, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                if (result == null)
                {
                    ClonedItemErrorEvent?.Invoke();
                    return null;
                }

                if (result.Length != 1)
                {
                    ClonedItemErrorEvent?.Invoke();
                    return null;
                }

                var item = result[0];
                if (item == null)
                {
                    ClonedItemErrorEvent?.Invoke();
                    return null;
                }

                item.transform.localPosition = zeroPos;
                item.transform.localRotation = zeroTurn;
                Item = item;

                CompletedEvent?.Invoke();
                return item;
            }
            catch (OperationCanceledException)
            {
                CancelledEvent?.Invoke();
                return null;
            }
            catch (Exception ex)
            {
                UnityOperationErrorEvent?.Invoke();
                return null;
            }
        }
    }
}