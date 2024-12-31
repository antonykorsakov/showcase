using UnityEngine;

namespace ProjModules.CameraModule.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(CameraConfig),
        menuName = "Configs/" + nameof(CameraConfig), order = 'C')]
    public class CameraConfig : ScriptableObject, ICameraConfig
    {
        [SerializeField] private Camera _gameCamera;

        public Camera GameCamera => _gameCamera;
    }
}