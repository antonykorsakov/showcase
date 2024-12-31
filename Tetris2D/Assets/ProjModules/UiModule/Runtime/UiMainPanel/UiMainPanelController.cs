using System;

namespace ProjectFeatures.UiModule.Runtime
{
    public class UiMainPanelController : IUiMainPanelController
    {
        private CanvasFadeAnim _buttonsFadeAnim;
        private UiMainPanelView _panelView;

        public event Action TetrisButtonClickEvent;
        public event Action Match3ButtonClickEvent;

        public void SetPanel(UiMainPanelView panelView)
        {
            ResetPanel();
            _panelView = panelView;
            SetupPanel();
        }

        public async void FadeInPanel()
        {
            if (_panelView == null)
                return;

            _buttonsFadeAnim.StopAndDisable();
            await _buttonsFadeAnim.FadeIn(1.5f);
            await _buttonsFadeAnim.FadeOut(1.5f);
            await _buttonsFadeAnim.FadeIn(1.5f);
        }

        private void SetupPanel()
        {
            if (_panelView == null)
                return;

            _panelView.TetrisButton.onClick.AddListener(ClickTetrisButton);
            _panelView.Match3Button.onClick.AddListener(ClickMatch3Button);
            _buttonsFadeAnim = new CanvasFadeAnim(_panelView.ButtonsContainer);
        }

        private void ResetPanel()
        {
            if (_panelView == null)
                return;

            _buttonsFadeAnim.Stop();
            _buttonsFadeAnim = null;
            _panelView.TetrisButton.onClick.RemoveListener(ClickTetrisButton);
            _panelView.Match3Button.onClick.RemoveListener(ClickMatch3Button);
        }

        private void ClickTetrisButton() => TetrisButtonClickEvent?.Invoke();
        private void ClickMatch3Button() => Match3ButtonClickEvent?.Invoke();
    }
}