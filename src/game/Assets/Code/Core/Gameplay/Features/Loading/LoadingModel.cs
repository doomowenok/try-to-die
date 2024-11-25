using Code.Infrastructure.Reactive;

namespace Code.Core.Gameplay.Features.Loading
{
    public sealed class LoadingModel
    {
        public INotifyProperty<float> LoadingProgress { get; private set; } = new NotifyProperty<float>(0.0f);

        public void ChangeLoadingProgress(float progress)
        {
            LoadingProgress.Value = progress;
        }
    }
}