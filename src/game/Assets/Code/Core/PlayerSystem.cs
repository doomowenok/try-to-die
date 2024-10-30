using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerSystem))]
    public sealed class PlayerSystem : UpdateSystem
    {
        private Filter _filter;
        
        // Used for optimization, we don't need to use get component from entity every frame, stash cache it. 
        private Stash<PlayerComponent> _playerStash;

        public override void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.SetComponent(new PlayerComponent() { Health = 100 });

            _filter = World.Filter.With<PlayerComponent>().Build();
            _playerStash = World.GetStash<PlayerComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                // ref var player = ref entity.GetComponent<PlayerComponent>();
                ref var player = ref _playerStash.Get(entity);
                player.Health -= deltaTime;
                Debug.Log(player.Health);
            }
        }
    }
}