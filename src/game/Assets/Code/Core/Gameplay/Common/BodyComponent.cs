using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Core.Gameplay.Common
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct BodyComponent : IComponent
    {
        public Transform Value;
    }
}