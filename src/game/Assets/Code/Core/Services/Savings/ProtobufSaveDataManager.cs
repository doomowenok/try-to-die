using System;
using System.Collections.Generic;
using Code.Core.Services.Savings.Configs;
using Code.Infrastructure.Config;

namespace Code.Core.Services.Savings
{
    public sealed class ProtobufSaveDataManager : ISaveDataManager
    {
        private readonly IConfigProvider _configProvider;
        private readonly ISaveLoadService _saveLoadService;
        
        // Here will all types of savings.
        // Example: PlayerData Player { get; private set; }

        public ProtobufSaveDataManager(IConfigProvider configProvider, ISaveLoadService saveLoadService)
        {
            _configProvider = configProvider;
            _saveLoadService = saveLoadService;
        }

        public void LoadAll()
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            foreach (KeyValuePair<SaveDataType, string> dataPath in config.SaveDataPath)
            {
                LoadById(dataPath.Key);    
            }
        }

        public void LoadById(SaveDataType type)
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            switch (type)
            {
                case SaveDataType.None:
                    // Example:
                    // if (_saveLoadService.TryLoad(config.SaveDataPath[type], out byte[] data))
                    // {
                    //     Player = PlayerData.Parser.ParseFrom(data);
                    // }
                    // else
                    // {
                    //     Player = new Player();
                    // }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void SaveAll()
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            foreach (KeyValuePair<SaveDataType, string> dataPath in config.SaveDataPath)
            {
                SaveById(dataPath.Key);    
            }
        }
        
        public void SaveById(SaveDataType type)
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            switch (type)
            {
                case SaveDataType.None:
                    // Example:
                    // byte[] data = Player.ToByteArray();
                    // _saveLoadService.Save(config.SaveDataPath[type], data);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void ClearAll()
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            foreach (KeyValuePair<SaveDataType, string> dataPath in config.SaveDataPath)
            {
                ClearById(dataPath.Key);    
            }
        }
        
        public void ClearById(SaveDataType type)
        {
            SaveConfig config = _configProvider.GetConfig<SaveConfig>();
            
            switch (type)
            {
                case SaveDataType.None:
                    // Example:
                    // _saveLoadService.Delete(config.SaveDataPath[type]);
                    // Player = new Player();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}