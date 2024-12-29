using ProjectFeatures.AppLifetimeModule;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class AppLifetimeModBehavior : IInitializable
    {
        [Inject] private IAppLifetimeController AppLifetimeController { get; }

        public void Initialize()
        {
            
        }
    }
}