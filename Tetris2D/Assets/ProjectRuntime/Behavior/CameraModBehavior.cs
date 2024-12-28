using ProjectFeatures.CameraModule.Runtime;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public sealed class CameraModBehavior : IInitializable
    {
        [Inject] private ICameraStorage CameraStorage { get; }

        public void Initialize()
        {
            CameraStorage.LoadAndSetupCamera();
        }
    }
}