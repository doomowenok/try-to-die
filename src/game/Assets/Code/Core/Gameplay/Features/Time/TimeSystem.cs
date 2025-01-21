using Code.Core.Services.Time;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Zenject;

namespace Code.Core.Gameplay.Features.Time
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(TimeSystem))]
    public sealed class TimeSystem : UpdateSystem
    {
        private ITimeService _time;

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }
        
        public override void OnAwake() { }

        public override void OnUpdate(float deltaTime) => 
            _time.UpdateDeltaTime(deltaTime);
    }
}