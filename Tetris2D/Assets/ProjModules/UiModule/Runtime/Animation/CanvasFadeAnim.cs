using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectFeatures.CoreModule.Runtime;
using UnityEngine;

namespace ProjectFeatures.UiModule.Runtime
{
    public class CanvasFadeAnim
    {
        private CanvasGroup _canvasGroup;
        private FadeState _state;

        private CancellationTokenSource _cancellationTokenSource;
        private UniTask _currentFade;

        public CanvasFadeAnim(CanvasGroup canvasGroup)
        {
            _canvasGroup = canvasGroup;
            _state = Mathf.Approximately(canvasGroup.alpha, 1)
                ? FadeState.Enabled
                : FadeState.Disabled;
        }

        public void StopAndEnable()
        {
            Stop();
            Enable();
        }

        public void StopAndDisable()
        {
            Stop();
            Disable();
        }

        public void Stop() => _cancellationTokenSource?.Cancel();

        public UniTask FadeIn(float duration)
        {
            switch (_state)
            {
                case FadeState.FadeIn:
                case FadeState.FadeOut:
                    _cancellationTokenSource?.Cancel();
                    break;

                case FadeState.Disabled:
                    break;

                case FadeState.Enabled:
                case FadeState.Undefined:
                default:
                    return UniTask.CompletedTask;
            }

            _state = FadeState.FadeIn;
            _cancellationTokenSource = new CancellationTokenSource();
            return AnimateAlpha(1f, duration, _cancellationTokenSource.Token);
        }

        public UniTask FadeOut(float duration)
        {
            switch (_state)
            {
                case FadeState.FadeIn:
                case FadeState.FadeOut:
                    _cancellationTokenSource?.Cancel();
                    break;

                case FadeState.Enabled:
                    break;

                case FadeState.Disabled:
                case FadeState.Undefined:
                default:
                    return UniTask.CompletedTask;
            }

            _state = FadeState.FadeOut;
            _cancellationTokenSource = new CancellationTokenSource();
            return AnimateAlpha(0f, duration, _cancellationTokenSource.Token);
        }

        private async UniTask AnimateAlpha(float targetAlpha, float duration,
            CancellationToken cancellationToken = default)
        {
            if (_canvasGroup == null)
                throw new ArgumentNullException(nameof(_canvasGroup));

            float startAlpha = _canvasGroup.alpha;
            float elapsedTime = 0f;

            try
            {
                while (elapsedTime < duration)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    elapsedTime += Time.deltaTime;
                    _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

                    await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
                }

                if (targetAlpha >= 1f)
                    Enable();
                else
                    Disable();
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Animation cancelled");
            }
        }

        private void Enable()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _state = FadeState.Enabled;
        }

        private void Disable()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _state = FadeState.Disabled;
        }
    }
}