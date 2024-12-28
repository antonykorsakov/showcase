using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    [CreateAssetMenu(fileName = nameof(UiConfig),
        menuName = "Configs/" + nameof(UiConfig), order = 'U')]
    public class UiConfig : ScriptableObject, IUiConfig
    {
        [SerializeField] private UiPanelsContainer _uiPanelsContainer;

        public UiPanelsContainer UiPanelsContainer => _uiPanelsContainer;
    }
}