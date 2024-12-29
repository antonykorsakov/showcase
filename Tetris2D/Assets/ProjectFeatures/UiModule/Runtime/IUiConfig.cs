namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiConfig
    {
        UiPanelsContainer UiPanelsContainer { get; }
        SplashUiPanel SplashUiPanel { get; }
        MainUiPanel MainUiPanel { get; }
    }
}