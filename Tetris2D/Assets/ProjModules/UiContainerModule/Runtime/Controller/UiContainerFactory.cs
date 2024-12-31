using ProjectFeatures.PrefabFactoryModule.Runtime;
using ProjectFeatures.UiModule.Runtime;

namespace ProjModules.UiContainerModule.Runtime.Controller
{
    public sealed class UiContainerFactory : PrefabFactory<UiContainerView>, IUiContainerFactory
    {
        public UiContainerFactory(UiContainerView original) : base(original)
        { }
    }
}