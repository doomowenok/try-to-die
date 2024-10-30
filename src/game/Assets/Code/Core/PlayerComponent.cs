using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Core
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PlayerComponent : IComponent
    {
        public float Health;
    }
}