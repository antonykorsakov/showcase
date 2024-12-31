using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ProjectFeatures.CoreModule.Runtime
{
    public static class InstantiateFactory
    {
        public static async UniTask<T> InstantiateAsync<T>(T original, Transform parent,
            Action<T> success, Action fail, CancellationToken cancellationToken)
            where T : Component
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
                    fail?.Invoke();
                    return null;
                }

                if (result.Length != 1)
                {
                    fail?.Invoke();
                    return null;
                }

                var item = result[0];
                if (item == null)
                {
                    fail?.Invoke();
                    return null;
                }

                item.transform.localPosition = zeroPos;
                item.transform.localRotation = zeroTurn;

                success?.Invoke(item);
                return item;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Operation was canceled.");
                return null;
                // Nothing!
            }
            catch (Exception ex)
            {
                fail?.Invoke();
                return null;
            }
        }
    }
}