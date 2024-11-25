using System.Collections.Generic;

namespace Code.Core.Gameplay.Features.Map
{
    public sealed class MapGenerationRulesData
    {
        public Dictionary<MapGenerationDirectionType, List<MapPartType>> Parts;
    }
}