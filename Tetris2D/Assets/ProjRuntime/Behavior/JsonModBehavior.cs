using ProjectFeatures.JsonModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class JsonModBehavior : IInitializable
    {
        [Inject] private IJsonController JsonController { get; }

        public void Initialize()
        {
            // Debug.LogError(JsonController.GetType());
        }
    }
}