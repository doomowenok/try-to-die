using System.Collections.Generic;

namespace Code.Core.Gameplay.Features.Map
{
    public sealed class MapGenerationRulesData
    {
        public List<MapPartType> LeftPart;
        public List<MapPartType> RightPart;
        public List<MapPartType> UpPart;
        public List<MapPartType> DownPart;
    }
}