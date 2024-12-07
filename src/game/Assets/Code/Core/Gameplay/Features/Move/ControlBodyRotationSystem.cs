using Code.Core.Gameplay.Common;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Move
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ControlBodyRotationSystem))]
    public sealed class ControlBodyRotationSystem : UpdateSystem
    {
        private Filter _entities;

        public override void OnAwake()
        {
            _entities = World.Filter
                .With<BodyComponent>()
                .With<DirectionComponent>()
                .With<TransformComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref BodyComponent bodyComponent = ref entity.GetComponent<BodyComponent>();
                ref DirectionComponent directionComponent = ref entity.GetComponent<DirectionComponent>();

                Vector3 rotateScale = Vector3.one;

                if (!Mathf.Approximately(directionComponent.Value.x, 0.0f))
                {
                    rotateScale.x = directionComponent.Value.x >= 0 ? 1.0f : -1.0f;
                    bodyComponent.Value.localScale = rotateScale;   
                }
            }
        }
    }
}