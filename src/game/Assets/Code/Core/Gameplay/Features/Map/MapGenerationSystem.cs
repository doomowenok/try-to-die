using Code.Core.Gameplay.Common;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Map
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(MapGenerationSystem))]
    public sealed class MapGenerationSystem : Initializer
    {
        public override void OnAwake()
        {
            SpriteRenderer spriteRenderer = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<SpriteRenderer>();
            Entity entity = World.CreateEntity();
            ref SpriteRendererComponent component = ref entity.AddComponent<SpriteRendererComponent>();
            component.Renderer = spriteRenderer;
        }

        public override void Dispose()
        {
            
        }
    }
}