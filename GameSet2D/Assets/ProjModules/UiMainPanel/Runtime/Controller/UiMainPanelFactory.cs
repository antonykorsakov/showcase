using ProjModules.PrefabFactoryModule.Runtime;

namespace ProjModules.UiMainPanel.Runtime.Controller
{
    public class UiMainPanelFactory : PrefabFactory<UiMainPanelView>, IUiMainPanelFactory
    {
        public UiMainPanelFactory(UiMainPanelView original) : base(original)
        { }
    }
}