using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    [CreateAssetMenu(fileName = nameof(UiConfig),
        menuName = "Configs/" + nameof(UiConfig), order = 'U')]
    public class UiConfig : ScriptableObject, IUiConfig
    {
        [SerializeField] private UiPanelsContainer _uiPanelsContainer;
        [Header("Panels")]
        [SerializeField] private SplashUiPanel _splashUiPanel;
        [SerializeField] private MainUiPanel _mainUiPanel;

        public UiPanelsContainer UiPanelsContainer => _uiPanelsContainer;
        public SplashUiPanel SplashUiPanel => _splashUiPanel;
        public MainUiPanel MainUiPanel => _mainUiPanel;
    }
}