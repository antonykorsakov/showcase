using ProjectFeatures.CameraModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class CameraModBehavior : IInitializable
    {
        [Inject] private ICameraStorage CameraStorage { get; }

        public void Initialize()
        {
        }
    }
}