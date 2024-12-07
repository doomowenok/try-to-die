using Code.Core.Gameplay.Common;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerRotateToMouseSystem))]
    public sealed class PlayerRotateToMouseSystem : UpdateSystem
    {
        private Filter _players;
        private Filter _inputs;
        
        public override void OnAwake()
        {
            _players = World.Filter
                .With<PlayerComponent>()
                .With<TransformComponent>()
                .Build();

            _inputs = World.Filter
                .With<GameplayInputComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            Camera camera = Camera.main;

            if (camera == null)
            {
                return;
            }

            foreach (Entity player in _players)
            {
                foreach (Entity input in _inputs)
                {
                    ref GameplayInputComponent inputComponent = ref input.GetComponent<GameplayInputComponent>();
                    ref TransformComponent transformComponent = ref player.GetComponent<TransformComponent>();

                    Vector3 mousePositionWorld = camera.ScreenToWorldPoint(new Vector3(inputComponent.mousePosition.x, inputComponent.mousePosition.y, 0.0f));
                    Vector3 direction = mousePositionWorld - transformComponent.value.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transformComponent.value.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);;
                }
            }
        }
    }
}