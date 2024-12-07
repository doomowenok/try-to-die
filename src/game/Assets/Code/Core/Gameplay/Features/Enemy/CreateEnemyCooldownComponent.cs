using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Core.Gameplay.Features.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct CreateEnemyCooldownComponent : IComponent
    {
        public float InitialValue;
        public float Value;
    }
}