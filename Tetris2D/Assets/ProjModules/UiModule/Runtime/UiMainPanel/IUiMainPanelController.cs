using System;

namespace ProjectFeatures.UiModule.Runtime
{
    public interface IUiMainPanelController
    {
        event Action TetrisButtonClickEvent;
        event Action Match3ButtonClickEvent;

        void SetPanel(UiMainPanelView panelView);
        void FadeInPanel();
    }
}