using Code.Core.Gameplay.Common;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Death
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DestroyDeadEntitiesSystem))]
    public sealed class DestroyDeadEntitiesSystem : UpdateSystem
    {
        private Filter _deads;

        public override void OnAwake()
        {
            _deads = World.Filter
                .With<GameObjectComponent>()
                .With<DeathComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity dead in _deads)
            {
                ref GameObjectComponent gameObjectComponent = ref dead.GetComponent<GameObjectComponent>();
                Destroy(gameObjectComponent.Value);
                dead.Dispose();
            }
        }
    }
}