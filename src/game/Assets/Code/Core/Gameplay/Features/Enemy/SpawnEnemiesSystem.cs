using Code.Core.Gameplay.Common;
using Code.Core.Gameplay.Features.Move;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SpawnEnemiesSystem))]
    public sealed class SpawnEnemiesSystem : UpdateSystem
    {
        private Filter _cooldowns;

        public override void OnAwake()
        {
            Entity cooldown = World.CreateEntity();
            
            ref CreateEnemyCooldownComponent cooldownComponent = ref cooldown.AddComponent<CreateEnemyCooldownComponent>();
            cooldownComponent.InitialValue = 2.0f;
            cooldownComponent.Value = cooldownComponent.InitialValue;

            _cooldowns = World.Filter
                .With<CreateEnemyCooldownComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity cooldown in _cooldowns)
            {
                ref CreateEnemyCooldownComponent cooldownComponent =
                    ref cooldown.GetComponent<CreateEnemyCooldownComponent>();
                cooldownComponent.Value -= deltaTime;

                if (cooldownComponent.Value <= 0.0f)
                {
                    cooldownComponent.Value = cooldownComponent.InitialValue;

                    Vector3 spawnPosition = new Vector3(
                        Random.Range(-10.0f, 10.0f),
                        Random.Range(-10.0f, 10.0f),
                        0.0f);
                    GameObject enemyObject = Instantiate(Resources.Load<GameObject>("Enemy"));
                    enemyObject.transform.position = spawnPosition;
                    
                    Entity enemyEntity = World.CreateEntity();

                    enemyEntity.AddComponent<EnemyComponent>();
                    
                    ref GameObjectComponent gameObjectComponent = ref enemyEntity.AddComponent<GameObjectComponent>();
                    gameObjectComponent.Value = enemyObject;

                    ref TransformComponent transformComponent = ref enemyEntity.AddComponent<TransformComponent>();
                    transformComponent.Value = enemyObject.transform;

                    ref DirectionComponent directionComponent = ref enemyEntity.AddComponent<DirectionComponent>();
                    directionComponent.Value = Vector3.zero;
                }
            }
        }
    }
}