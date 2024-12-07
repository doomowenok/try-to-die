using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Core.Gameplay.Features.Death
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct DeathComponent : IComponent { }
}