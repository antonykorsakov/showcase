using ProjectFeatures.PrefabFactoryModule.Runtime;

namespace ProjectFeatures.UiModule.Runtime
{
    public sealed class UiPanelsContainerFactory : PrefabFactory<UiPanelsContainerView>
    {
        public UiPanelsContainerFactory(UiPanelsContainerView original) : base(original)
        { }
    }
}