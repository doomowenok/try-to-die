using Code.Core.Gameplay.Common;
using Code.Core.Gameplay.Features.Move;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(CreatePlayerSystem))]
    public sealed class CreatePlayerSystem : Initializer
    {
        public override void OnAwake()
        {
            GameObject playerObject = Instantiate(Resources.Load<GameObject>("Player"));
            PlayerProvider playerProvider = playerObject.GetComponent<PlayerProvider>();
            
            Entity playerEntity = World.CreateEntity();
            
            ref PlayerComponent playerComponent = ref playerEntity.AddComponent<PlayerComponent>();
            playerComponent.IsMoving = false;
            
            ref GameObjectComponent gameObjectComponent = ref playerEntity.AddComponent<GameObjectComponent>();
            gameObjectComponent.Value = playerObject;
            
            ref TransformComponent transformComponent = ref playerEntity.AddComponent<TransformComponent>();
            transformComponent.Value = playerProvider.transform;

            ref AnimatorComponent animatorComponent = ref playerEntity.AddComponent<AnimatorComponent>();
            animatorComponent.Value = playerProvider.Animator;
            
            ref DirectionComponent directionComponent = ref playerEntity.AddComponent<DirectionComponent>();
            directionComponent.Value = Vector3.zero;
            
            ref BodyComponent bodyComponent = ref playerEntity.AddComponent<BodyComponent>();
            bodyComponent.Value = playerProvider.Body;
        }

        public override void Dispose()
        {
        }
    }
}