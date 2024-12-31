using ProjModules.JsonModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class JsonControllerBeh : IInitializable
    {
        [Inject] private IJsonController JsonController { get; }

        public void Initialize()
        {
            // Debug.LogError(JsonController.GetType());
        }
    }
}