using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.Core.Services.Sprites.Configs
{
    [CreateAssetMenu(fileName = nameof(AtlasConfig), menuName = "Configs/AtlasConfig")]
    public sealed class AtlasConfig : SerializedScriptableObject
    {
        [OdinSerialize] private Dictionary<AtlasSpriteType, string> _spriteNameInAtlas;
        public IReadOnlyDictionary<AtlasSpriteType, string> SpriteNameInAtlas => _spriteNameInAtlas;

        [InfoBox("You get ID of atlas in \"GetAtlasId\" method in extensions.", InfoMessageType.Info)]
        [OdinSerialize] private Dictionary<int, string> _atlasesName;
        public IReadOnlyDictionary<int, string> AtlasesName => _atlasesName;
    }
}