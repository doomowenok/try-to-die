using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.Core.Services.Savings.Configs
{
    [CreateAssetMenu(fileName = nameof(SaveConfig), menuName = "Configs/SaveConfig")]
    public sealed class SaveConfig : SerializedScriptableObject
    {
        [InfoBox("You can use readable key for save name and value for savings.", InfoMessageType.Info)]
        [OdinSerialize] private Dictionary<SaveDataType, string> _saveDataPath;
        public IReadOnlyDictionary<SaveDataType, string> SaveDataPath => _saveDataPath;
    }
}