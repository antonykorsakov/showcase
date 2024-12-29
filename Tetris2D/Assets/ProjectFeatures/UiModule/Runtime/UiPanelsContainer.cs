using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiPanelsContainer : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _uiCamera;

        public Canvas Canvas => _canvas;
        public Camera UiCamera => _uiCamera;
    }
}