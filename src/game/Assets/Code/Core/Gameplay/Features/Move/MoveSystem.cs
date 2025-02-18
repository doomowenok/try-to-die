using Code.Core.Gameplay.Common;
using Code.Core.Services.Time;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Zenject;

namespace Code.Core.Gameplay.Features.Move
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveSystem))]
    public sealed class MoveSystem : UpdateSystem
    {
        private ITimeService _time;
        private Filter _directions;

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }

        public override void OnAwake()
        {
            _directions = World.Filter
                .With<DirectionComponent>()
                .With<TransformComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity direction in _directions)
            {
                ref TransformComponent transformComponent = ref direction.GetComponent<TransformComponent>();
                ref DirectionComponent directionComponent = ref direction.GetComponent<DirectionComponent>();

                transformComponent.Value.position += directionComponent.Value * _time.DeltaTime;
            }
        }
    }
}