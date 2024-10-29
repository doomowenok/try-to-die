using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Resource
{
    public interface IResourceProvider
    {
        UniTask<TObject> Get<TObject>(string name) where TObject : MonoBehaviour;
        void Release<TObject>(TObject instance) where TObject : MonoBehaviour;
    }
}