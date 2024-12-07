using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Input
{
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
            // float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            // float vertical = UnityEngine.Input.GetAxis("Vertical");
            // bool isAttack = UnityEngine.Input.GetButtonDown("Jump");
            // Vector3 mousePosition = UnityEngine.Input.mousePosition;
            //
            // foreach (Entity entity in _inputs)
            // {
            //     ref GameplayInputComponent input = ref _inputsStash.Get(entity);
            //     input.mousePosition = mousePosition;
            //     input.horizontal = horizontal;
            //     input.vertical = vertical;
            //     input.isAttack = isAttack;
            // }
        }
    }
}