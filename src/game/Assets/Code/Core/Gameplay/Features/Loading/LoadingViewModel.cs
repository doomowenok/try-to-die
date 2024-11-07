using Code.Infrastructure.MVVM.ViewModel;
using Code.Infrastructure.Reactive;

namespace Code.Core.Gameplay.Features.Loading
{
    public sealed class LoadingViewModel : BaseViewModel<LoadingModel>
    {
        public INotifyProperty<float> LoadingProgress { get; private set; } = new NotifyProperty<float>();
        
        public override void Subscribe()
        {
            Model.LoadingProgress.OnValueChanged += UpdateLoadingProgress;
        }

        public override void Unsubscribe()
        {
            Model.LoadingProgress.OnValueChanged -= UpdateLoadingProgress;
        }

        private void UpdateLoadingProgress(float progress)
        {
            LoadingProgress.Value = progress;
        }
    }
}