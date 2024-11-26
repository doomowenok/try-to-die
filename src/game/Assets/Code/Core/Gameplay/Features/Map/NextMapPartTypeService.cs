using System;
using System.Collections.Generic;
using System.Linq;
using Code.Core.Extensions.System;
using Code.Infrastructure.Config;

namespace Code.Core.Gameplay.Features.Map
{
    public sealed class NextMapPartTypeService : INextMapPartTypeService
    {
        private readonly MapGenerationConfig _mapGenerationConfig;
        private readonly List<MapPartType> _mapPartTypes;

        public NextMapPartTypeService(IConfigProvider configProvider)
        {
            _mapGenerationConfig = configProvider.GetConfig<MapGenerationConfig>();
            _mapPartTypes = (Enum.GetValues(typeof(MapPartType)) as MapPartType[] ?? Array.Empty<MapPartType>())
                .Where(value => value != MapPartType.None)
                .ToList();
        }
        
        public MapPartType GetNext(MapPartType current, MapGenerationDirectionType direction) =>
            current == MapPartType.None
                ? _mapPartTypes.GetRandomElement()
                : _mapGenerationConfig.GenerationRules[current].Parts[direction].GetRandomElement();
    }
}