using Code.Infrastructure.MVVM.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.MVVM.Factory
{
    public interface IWindowFactory
    {
        UniTask<TView> CreateWindow<TView>(string name, Transform parent = null) where TView : MonoBehaviour, IView;
        void DisposeWindow<TView>(TView instance) where TView : MonoBehaviour, IView;
    }
}