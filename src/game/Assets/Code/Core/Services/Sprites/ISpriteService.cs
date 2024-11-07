using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Core.Services.Sprites
{
    public interface ISpriteService
    {
        UniTask<Sprite> GetSprite(AtlasSpriteType spriteType);
    }
}