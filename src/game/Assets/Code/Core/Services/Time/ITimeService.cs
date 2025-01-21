using Code.Infrastructure.Reactive;

namespace Code.Core.Services.Time
{
    public interface ITimeService
    {
        INotifyProperty<float> TimeScale { get; }
        float DeltaTime { get; }
        void ChangeTimeScale(float value);
        void UpdateDeltaTime(float value);
    }
}