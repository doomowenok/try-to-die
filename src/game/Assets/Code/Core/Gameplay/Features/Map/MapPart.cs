using UnityEngine;

namespace Code.Core.Gameplay.Features.Map
{
    public sealed class MapPart : MonoBehaviour
    {
        public SpriteRenderer Renderer;

        private void OnValidate()
        {
            if (Renderer == null)
            {
                bool result = gameObject.TryGetComponent(out SpriteRenderer spriteRenderer);

                if (result)
                {
                    Renderer = spriteRenderer;
                }
                else
                {
                    Debug.LogError($"Can't find {nameof(SpriteRenderer)} component in {gameObject.name}.");
                }
            }
        }
    }
}