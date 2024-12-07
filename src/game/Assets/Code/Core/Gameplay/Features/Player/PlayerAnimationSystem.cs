using Code.Core.Constants;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerAnimationSystem))]
    public sealed class PlayerAnimationSystem : UpdateSystem
    {
        private Filter _players;

        public override void OnAwake()
        {
            _players = World.Filter
                .With<PlayerComponent>()
                .With<AnimatorComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                ref AnimatorComponent animatorComponent = ref player.GetComponent<AnimatorComponent>();
                ref PlayerComponent playerComponent = ref player.GetComponent<PlayerComponent>();
                
                animatorComponent.Value.SetBool(AnimationConstants.Player.IsMoving, playerComponent.IsMoving);
            }
        }
    }
}