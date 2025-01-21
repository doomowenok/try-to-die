using Code.Infrastructure.Reactive;

namespace Code.Core.Services.Time
{
    public sealed class TimeService : ITimeService
    {
        private float _deltaTime;
        public INotifyProperty<float> TimeScale { get; private set; } = new NotifyProperty<float>(UnityEngine.Time.timeScale);
        public float DeltaTime => _deltaTime * TimeScale.Value;

        public void ChangeTimeScale(float value)
        {
            TimeScale.Value = value;
        }

        public void UpdateDeltaTime(float value)
        {
            _deltaTime = value;
        }
    }
}