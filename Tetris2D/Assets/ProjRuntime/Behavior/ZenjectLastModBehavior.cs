using ProjectFeatures.ZenjectModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class ZenjectLastModBehavior : IInitializable
    {
        [Inject] private IZenjectLastController ZenjectLastController { get; }

        public void Initialize() => ZenjectLastController.Initialize();
    }
}