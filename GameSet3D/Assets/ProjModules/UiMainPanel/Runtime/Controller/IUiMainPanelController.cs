using System;

namespace ProjModules.UiMainPanel.Runtime.Controller
{
    public interface IUiMainPanelController
    {
        event Action TetrisButtonClickEvent;
        event Action Match3ButtonClickEvent;

        void SetPanel(UiMainPanelView panelView);
        void FadeInPanel();
    }
}