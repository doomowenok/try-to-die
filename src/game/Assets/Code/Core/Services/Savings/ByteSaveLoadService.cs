using System.IO;
using UnityEngine;

namespace Code.Core.Services.Savings
{
    public sealed class ByteSaveLoadService : ISaveLoadService
    {
        public void Save(string key, byte[] data)
        {
            string filePath = Path.Combine(Application.persistentDataPath, key);
            File.WriteAllBytes(filePath, data);
        }

        public bool TryLoad(string key, out byte[] data)
        {
            string filePath = Path.Combine(Application.persistentDataPath, key);
            
            if (File.Exists(filePath))
            {
                data = File.ReadAllBytes(filePath);
                return true;
            }
            
            data = null;
            return false;
        }

        public void Delete(string key)
        {
            string filePath = Path.Combine(Application.persistentDataPath, key);
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}