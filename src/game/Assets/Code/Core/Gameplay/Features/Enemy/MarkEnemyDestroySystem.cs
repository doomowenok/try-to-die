using Code.Core.Gameplay.Common;
using Code.Core.Gameplay.Features.Death;
using Code.Core.Gameplay.Features.Health;
using Code.Core.Gameplay.Features.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MarkEnemyDestroySystem))]
    public sealed class MarkEnemyDestroySystem : UpdateSystem
    {
        private Filter _enemies;
        private Filter _players;
        
        public override void OnAwake()
        {
            _enemies = World.Filter
                .With<EnemyComponent>()
                .With<TransformComponent>()
                .Build();

            _players = World.Filter
                .With<PlayerComponent>()
                .With<TransformComponent>()
                .With<HealthComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity enemy in _enemies)
                {
                    ref TransformComponent playerTransformComponent = ref player.GetComponent<TransformComponent>();
                    ref HealthComponent playerHealth = ref player.GetComponent<HealthComponent>();
                    ref TransformComponent enemyTransformComponent = ref enemy.GetComponent<TransformComponent>();

                    float distance = Vector3.Distance(
                        playerTransformComponent.Value.position,
                        enemyTransformComponent.Value.position);

                    if (distance < 1.0f)
                    {
                        enemy.AddComponent<DeathComponent>();
                        playerHealth.Value -= 20.0f;
                    }
                }   
            }
        }
    }
}