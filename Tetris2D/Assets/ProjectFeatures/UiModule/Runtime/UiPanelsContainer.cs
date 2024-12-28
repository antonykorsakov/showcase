using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiPanelsContainer : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        public Canvas Canvas => _canvas;
    }
}