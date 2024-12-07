using Code.Core.Gameplay.Common;
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
            Entity playerEntity = World.CreateEntity();
            playerEntity.AddComponent<PlayerComponent>();
            ref TransformComponent transformComponent = ref playerEntity.AddComponent<TransformComponent>();
            transformComponent.value = playerObject.transform;
        }

        public override void Dispose()
        {
        }
    }
}