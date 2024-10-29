using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code.Infrastructure.Resource
{
    public sealed class ResourceProvider : IResourceProvider
    {
        private readonly IDictionary<Type, MonoBehaviour> _loadedAssets = new Dictionary<Type, MonoBehaviour>(64);
        
        public async UniTask<TObject> Get<TObject>(string name) where TObject : MonoBehaviour
        {
            if (_loadedAssets.TryGetValue(typeof(TObject), out MonoBehaviour asset))
            {
                return asset as TObject;
            }
            
            AsyncOperationHandle<TObject> handle = Addressables.LoadAssetAsync<TObject>(name);
            
            while (!handle.IsDone)
            {
                await UniTask.Yield();
            }

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Failed to load asset: {name}");
                return null;
            }
            
            _loadedAssets.Add(typeof(TObject), handle.Result);
            
            return handle.Result;
        }

        public void Release<TObject>(TObject instance) where TObject : MonoBehaviour
        {
            Addressables.Release(instance);
            _loadedAssets.Remove(typeof(TObject));
        }
    }
}