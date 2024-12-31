using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    [CreateAssetMenu(fileName = nameof(UiConfig),
        menuName = "Configs/" + nameof(UiConfig), order = 'U')]
    public class UiConfig : ScriptableObject, IUiConfig
    {
        [SerializeField] private UiPanelsContainerView _uiPanelsContainerView;
        [Header("Panels")]
        [SerializeField] private UiSplashPanelView _uiSplashPanelView;
        [SerializeField] private UiMainPanelView _uiMainPanelView;

        public UiPanelsContainerView UiPanelsContainerView => _uiPanelsContainerView;
        public UiSplashPanelView UiSplashPanelView => _uiSplashPanelView;
        public UiMainPanelView UiMainPanelView => _uiMainPanelView;
    }
}