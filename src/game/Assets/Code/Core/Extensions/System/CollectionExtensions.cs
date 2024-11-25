using System.Collections.Generic;

namespace Code.Core.Extensions.System
{
    public static class CollectionExtensions
    {
        public static T GetRandomElement<T>(this List<T> collection) => 
            collection[UnityEngine.Random.Range(0, collection.Count)];
    }
}