using ProjModules.UiModule.Runtime.UiSplashPanel;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    [CreateAssetMenu(fileName = nameof(UiConfig),
        menuName = "Configs/" + nameof(UiConfig), order = 'U')]
    public class UiConfig : ScriptableObject, IUiConfig
    {
        [SerializeField] private UiSplashPanelView _uiSplashPanelView;
        
        
        public UiSplashPanelView UiSplashPanelView => _uiSplashPanelView;
        
    }
}