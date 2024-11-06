using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Input
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct GameplayInputComponent : IComponent
    {
        public float Horizontal;
        public float Vertical;
        public bool IsJump;
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameplayInputSystem))]
    public sealed class GameplayInputSystem : UpdateSystem
    {
        private Filter _inputs;
        private Stash<GameplayInputComponent> _inputsStash;

        public override void OnAwake()
        {
            Entity input = World.CreateEntity();
            input.SetComponent(new GameplayInputComponent());

            _inputs = World.Filter.With<GameplayInputComponent>().Build();
            _inputsStash = World.GetStash<GameplayInputComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");
            bool isJump = UnityEngine.Input.GetButtonDown("Jump");
            
            foreach (Entity entity in _inputs)
            {
                ref GameplayInputComponent input = ref _inputsStash.Get(entity);
                input.Horizontal = horizontal;
                input.Vertical = vertical;
                input.IsJump = isJump;
            }
        }
    }
}