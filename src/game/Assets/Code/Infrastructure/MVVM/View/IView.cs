using Code.Infrastructure.Pool;
using UnityEngine;

namespace Code.Infrastructure.MVVM.View
{
    public interface IView : IPoolable
    {
        GameObject ViewObject { get; }
        void Subscribe();
        void Unsubscribe();
    }
}