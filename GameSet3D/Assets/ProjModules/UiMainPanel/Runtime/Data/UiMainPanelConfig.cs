using UnityEngine;

namespace ProjModules.UiMainPanel.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(UiMainPanelConfig),
        menuName = "Configs/" + nameof(UiMainPanelConfig), order = 'U')]
    public class UiMainPanelConfig : ScriptableObject, IUiMainPanelConfig
    {
        [SerializeField] private UiMainPanelView _uiMainPanelView;
        
        public UiMainPanelView UiMainPanelView => _uiMainPanelView;
    }
}