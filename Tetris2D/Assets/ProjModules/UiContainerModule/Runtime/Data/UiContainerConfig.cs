using UnityEngine;

namespace ProjModules.UiContainerModule.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(UiContainerConfig),
        menuName = "Configs/" + nameof(UiContainerConfig), order = 'U')]
    public class UiContainerConfig : ScriptableObject, IUiContainerConfig
    {
        [SerializeField] private UiContainerView _uiContainerView;
        
        public UiContainerView UiContainerView => _uiContainerView;
    }
}