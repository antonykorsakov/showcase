using ProjectFeatures.ZenjectModule.Runtime;
using Zenject;

namespace ProjRuntime.ZenjectLastModule
{
    public class ZenjectLastModBeh : IInitializable
    {
        [Inject] private IZenjectLastController ZenjectLastController { get; }

        public void Initialize() => ZenjectLastController.Initialize();
    }
}