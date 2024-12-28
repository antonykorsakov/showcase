using UnityEngine;

namespace ProjectFeatures.CameraModule.Runtime
{
    public class CameraStack : MonoBehaviour
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField] private Camera _uiCamera;

        public Camera GameplayCamera => _gameplayCamera;
        public Camera UiCamera => _uiCamera;

        private void OnValidate()
        {
            if (_gameplayCamera == null)
                Debug.LogError($"'{nameof(_gameplayCamera)}' is null");

            if (_uiCamera == null)
                Debug.LogError($"'{nameof(_uiCamera)}' is null");
        }
    }
}