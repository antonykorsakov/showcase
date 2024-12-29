using UnityEngine;
using UnityEngine.UI;

namespace ProjectFeatures.UiModule.Runtime
{
    public sealed class MainUiPanel : UiPanel
    {
        [SerializeField] private CanvasGroup _buttonsContainer;
        [Header("Buttons")] 
        [SerializeField] private Button _tetrisButton;
        [SerializeField] private Button _match3Button;

        public CanvasGroup ButtonsContainer => _buttonsContainer;
        public Button TetrisButton => _tetrisButton;
        public Button Match3Button => _match3Button;
    }
}