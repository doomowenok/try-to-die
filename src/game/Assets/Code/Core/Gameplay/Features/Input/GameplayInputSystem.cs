using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Zenject;

namespace Code.Core.Gameplay.Features.Input
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameplayInputSystem))]
    public sealed class GameplayInputSystem : UpdateSystem
    {
        private GameplayInput _gameplayInput;
        
        private Filter _inputs;

        [Inject]
        private void Construct(GameplayInput gameplayInput)
        {
            _gameplayInput = gameplayInput;
        }
        
        public override void OnAwake()
        {
            Entity input = World.CreateEntity();
            input.SetComponent(new GameplayInputComponent());

            _inputs = World.Filter.With<GameplayInputComponent>().Build();
            
            _gameplayInput.Enable();
        }

        public override void OnUpdate(float deltaTime)
        {
            Vector2 moveInput = _gameplayInput.Player.Move.ReadValue<Vector2>();
            Vector2 mousePosition = _gameplayInput.Player.Mouse.ReadValue<Vector2>();
            
            foreach (Entity entity in _inputs)
            {
                ref GameplayInputComponent input = ref entity.GetComponent<GameplayInputComponent>();
                input.mousePosition = mousePosition;
                input.horizontal = moveInput.x;
                input.vertical = moveInput.y;
            }
        }
    }
}