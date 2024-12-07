using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Move
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct DirectionComponent : IComponent
    {
        public Vector3 Value;
    }
}