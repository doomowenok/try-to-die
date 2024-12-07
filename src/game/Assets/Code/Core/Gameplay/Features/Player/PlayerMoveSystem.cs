using Code.Core.Constants;
using Code.Core.Gameplay.Common;
using Code.Core.Gameplay.Features.Input;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMoveSystem))]
    public sealed class PlayerMoveSystem : UpdateSystem
    {
        private Filter _players;
        private Filter _inputs;

        public override void OnAwake()
        {
            _players = World.Filter
                .With<PlayerComponent>()
                .With<TransformComponent>()
                .With<DirectionComponent>()
                .Build();

            _inputs = World.Filter.With<GameplayInputComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity input in _inputs)
                {
                    ref PlayerComponent playerComponent = ref player.GetComponent<PlayerComponent>();
                    ref DirectionComponent directionComponent = ref player.GetComponent<DirectionComponent>();
                    
                    ref GameplayInputComponent inputComponent = ref input.GetComponent<GameplayInputComponent>();

                    Vector3 direction = new Vector3(inputComponent.horizontal, inputComponent.vertical, 0.0f);
                    directionComponent.Value = direction;
                    playerComponent.IsMoving = Vector3.Magnitude(direction) > InputConstants.InputEpsilon;
                }
            }
        }
    }
}