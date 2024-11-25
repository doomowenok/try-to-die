namespace Code.Core.Services.Sprites
{
    public static class AtlasSpriteExtensions
    {
        public static int GetAtlasId(this AtlasSpriteType spriteType)
        {
            return (int)spriteType switch
            {
                (>= 100 and <= 199) => 100,
                (>= 200 and <= 202) => 200,
                _ => -1,
            };
        }
    }
}