using UObject = UnityEngine.Object;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStorage : ICameraStorage
    {
        private readonly ICameraConfig _config;

        public CameraStorage(ICameraConfig config)
        {
            _config = config;
        }

        public void LoadCamera()
        {
            UObject.InstantiateAsync(_config.CameraStack);
        }
    }
}