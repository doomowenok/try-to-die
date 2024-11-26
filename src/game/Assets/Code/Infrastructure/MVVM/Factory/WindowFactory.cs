using System.Linq;
using Code.Infrastructure.MVVM.View;
using Code.Infrastructure.Pool;
using Code.Infrastructure.Resource;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.MVVM.Factory
{
    public sealed class WindowFactory : IWindowFactory
    {
        private readonly DiContainer _context;
        private readonly IResourceProvider _resourceProvider;
        private readonly IObjectPool _objectPool;

        public WindowFactory(DiContainer context, IResourceProvider resourceProvider, IObjectPool objectPool)
        {
            _context = context;
            _resourceProvider = resourceProvider;
            _objectPool = objectPool;
        }
        
        public async UniTask<TView> CreateWindow<TView>(string name, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (!_objectPool.TryRent<TView>(out TView instance))
            {
                TView viewPrefab = await _resourceProvider.Get<TView>(name);
                AsyncInstantiateOperation<TView> operation = Object.InstantiateAsync(viewPrefab);

                while (!operation.isDone)
                {
                    await UniTask.Yield();
                }

                instance = operation.Result.First();
            }

            instance.transform.SetParent(parent);
            _context.Inject(instance);
            return instance;
        }

        public void DisposeWindow<TView>(TView instance) where TView : MonoBehaviour, IView
        {
            _objectPool.Release(instance);
        }
    }
}