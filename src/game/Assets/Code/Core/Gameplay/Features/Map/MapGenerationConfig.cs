using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Core.Gameplay.Features.Map
{
    [CreateAssetMenu(fileName = nameof(MapGenerationConfig), menuName = "Configs/Map Generation")]
    public sealed class MapGenerationConfig : SerializedScriptableObject
    {
        public float2 MapSize;
        public float2 CellSize;
        public Dictionary<MapPartType, MapGenerationRulesData> GenerationRules;
    }
}