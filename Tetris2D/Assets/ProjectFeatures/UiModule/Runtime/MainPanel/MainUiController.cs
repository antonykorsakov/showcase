using System;

namespace ProjectFeatures.UiModule.Runtime
{
    public class MainUiController : IMainUiController
    {
        private CanvasFadeAnim _buttonsFadeAnim;
        private MainUiPanel _panel;

        public event Action TetrisButtonClickEvent;
        public event Action Match3ButtonClickEvent;

        public void SetPanel(MainUiPanel panel)
        {
            ResetPanel();
            _panel = panel;
            SetupPanel();
        }

        public async void FadeInPanel()
        {
            if (_panel == null)
                return;

            _buttonsFadeAnim.StopAndDisable();
            await _buttonsFadeAnim.FadeIn(1.5f);
            await _buttonsFadeAnim.FadeOut(1.5f);
            await _buttonsFadeAnim.FadeIn(1.5f);
        }

        private void SetupPanel()
        {
            if (_panel == null)
                return;

            _panel.TetrisButton.onClick.AddListener(ClickTetrisButton);
            _panel.Match3Button.onClick.AddListener(ClickMatch3Button);
            _buttonsFadeAnim = new CanvasFadeAnim(_panel.ButtonsContainer);
        }

        private void ResetPanel()
        {
            if (_panel == null)
                return;

            _buttonsFadeAnim.Stop();
            _buttonsFadeAnim = null;
            _panel.TetrisButton.onClick.RemoveListener(ClickTetrisButton);
            _panel.Match3Button.onClick.RemoveListener(ClickMatch3Button);
        }

        private void ClickTetrisButton() => TetrisButtonClickEvent?.Invoke();
        private void ClickMatch3Button() => Match3ButtonClickEvent?.Invoke();
    }
}