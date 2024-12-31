namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiConfig
    {
        UiPanelsContainerView UiPanelsContainerView { get; }
        UiSplashPanelView UiSplashPanelView { get; }
        UiMainPanelView UiMainPanelView { get; }
    }
}