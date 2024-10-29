using UnityEngine;

namespace Code.Infrastructure.Pool
{
    public interface IPoolable
    {
        GameObject PoolObject { get; }
        void Release();
    }
}