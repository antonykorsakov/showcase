using UnityEngine;

namespace ProjModules.UiContainerModule.Runtime
{
    public class UiContainerView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _uiCamera;

        public Canvas Canvas => _canvas;
        public Camera UiCamera => _uiCamera;
    }
}