using Code.Infrastructure.MVVM.View;
using TMPro;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Loading
{
    public sealed class LoadingView : BaseView<LoadingViewModel>
    {
        [SerializeField] private TMP_Text loadingProgressText;
        
        public override void Subscribe()
        {
            ViewModel.LoadingProgress.OnValueChanged += UpdateProgress;
        }

        public override void Unsubscribe()
        {
            ViewModel.LoadingProgress.OnValueChanged -= UpdateProgress;
        }

        private void UpdateProgress(float progress)
        {
            loadingProgressText.SetText(progress.ToString("P"));
        }
    }
}