using System;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IMainUiController
    {
        event Action TetrisButtonClickEvent;
        event Action Match3ButtonClickEvent;

        void SetPanel(MainUiPanel panel);
        void FadeInPanel();
    }
}