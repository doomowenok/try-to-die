using Code.Core.Common;
using Code.Core.Gameplay.Features.Input;
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
        private Filter _inputs;
        private Stash<GameplayInputComponent> _inputsStash;
        
        private Filter _players;

        public override void OnAwake()
        {
            _inputs = World.Filter.With<GameplayInputComponent>().Build();
            _inputsStash = World.GetStash<GameplayInputComponent>();
            
            _players = World.Filter.With<PlayerComponent>().With<TransformComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity input in _inputs)
                {
                    GameplayInputComponent inputData = _inputsStash.Get(input);
                    ref TransformComponent playerTransform = ref player.GetComponent<TransformComponent>();
                    ref PlayerComponent playerComponent = ref player.GetComponent<PlayerComponent>();

                    playerTransform.Transform.position += new Vector3(inputData.Horizontal, 0f, inputData.Vertical) * playerComponent.MoveSpeed * deltaTime;
                }
            }
        }
    }
}