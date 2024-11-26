using System.Collections.Generic;
using Code.Core.Services.Sprites.Configs;
using Code.Infrastructure.Config;
using Code.Infrastructure.Resource;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

namespace Code.Core.Services.Sprites
{
    public sealed class SpriteService : ISpriteService
    {
        private readonly Dictionary<int, SpriteAtlas> _loadedAtlases = new Dictionary<int, SpriteAtlas>();
        
        private readonly IConfigProvider _configProvider;
        private readonly IResourceProvider _resourceProvider;

        public SpriteService(IConfigProvider configProvider, IResourceProvider resourceProvider)
        {
            _configProvider = configProvider;
            _resourceProvider = resourceProvider;
        }

        public async UniTask<Sprite> GetSprite(AtlasSpriteType spriteType)
        {
            AtlasConfig config = _configProvider.GetConfig<AtlasConfig>();
            int atlasId = spriteType.GetAtlasId();
            string spriteNameInAtlas = config.SpriteNameInAtlas[spriteType];
            
            if (_loadedAtlases.TryGetValue(atlasId, out SpriteAtlas atlas) && atlas != null)
            {
                return atlas.GetSprite(spriteNameInAtlas);
            }
            
            atlas = await _resourceProvider.GetSpriteAtlas(config.AtlasesName[atlasId]);
            _loadedAtlases.Add(atlasId, atlas);
            
            return atlas.GetSprite(spriteNameInAtlas);
        }
    }
}