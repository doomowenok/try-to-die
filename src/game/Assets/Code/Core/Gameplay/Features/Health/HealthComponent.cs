using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Core.Gameplay.Features.Health
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct HealthComponent : IComponent
    {
        public float Value;
    }
}