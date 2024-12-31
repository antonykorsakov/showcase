using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectFeatures.PrefabFactoryModule.Runtime
{
    public interface IPrefabFactory<T>
    {
        T Item { get; }

        event Action UnityOperationErrorEvent;
        event Action ClonedItemErrorEvent;
        event Action CancelledEvent;
        event Action CompletedEvent;

        UniTask<T> Load(Transform parent);
        void CleanReferences();
    }
}