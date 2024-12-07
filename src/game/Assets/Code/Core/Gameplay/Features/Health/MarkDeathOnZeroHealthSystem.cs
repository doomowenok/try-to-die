using Code.Core.Gameplay.Features.Death;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Health
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MarkDeathOnZeroHealthSystem))]
    public sealed class MarkDeathOnZeroHealthSystem : UpdateSystem
    {
        private Filter _entities;

        public override void OnAwake()
        {
            _entities = World.Filter
                .With<HealthComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref HealthComponent health = ref entity.GetComponent<HealthComponent>();

                if (health.Value <= 0.0f)
                {
                    entity.AddComponent<DeathComponent>();
                }
            }
        }
    }
}