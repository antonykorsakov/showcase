using ProjectFeatures.PrefabFactoryModule.Runtime;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiMainPanelFactory : PrefabFactory<UiMainPanelView>
    {
        public UiMainPanelFactory(UiMainPanelView original) : base(original)
        { }
    }
}