using ProjectFeatures.SceneModule;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class SceneModBehavior : IInitializable
    {
        [Inject] private IScenesController ScenesController { get; }

        public void Initialize()
        {
        }
    }
}