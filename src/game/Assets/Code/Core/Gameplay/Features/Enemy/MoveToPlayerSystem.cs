using Code.Core.Gameplay.Common;
using Code.Core.Gameplay.Features.Move;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveToPlayerSystem))]
    public sealed class MoveToPlayerSystem : UpdateSystem
    {
        private Filter _players;
        private Filter _enemies;

        public override void OnAwake()
        {
            _players = World.Filter
                .With<PlayerComponent>()
                .With<TransformComponent>()
                .Build();

            _enemies = World.Filter
                .With<EnemyComponent>()
                .With<TransformComponent>()
                .With<DirectionComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity enemy in _enemies)
                {
                    ref TransformComponent playerTransformComponent = ref player.GetComponent<TransformComponent>();
                    ref TransformComponent enemyTransformComponent = ref enemy.GetComponent<TransformComponent>();
                    ref DirectionComponent enemyDirectionComponent = ref enemy.GetComponent<DirectionComponent>();

                    Vector3 playerPosition = playerTransformComponent.Value.position;
                    Vector3 enemyPosition = enemyTransformComponent.Value.position;

                    Vector3 direction = (playerPosition - enemyPosition).normalized;
                    enemyDirectionComponent.Value = direction;
                }
            }
        }
    }
}