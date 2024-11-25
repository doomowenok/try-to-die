namespace Code.Core.Gameplay.Features.Map
{
    public interface INextMapPartTypeService
    {
        MapPartType GetNext(MapPartType current, MapGenerationDirectionType direction);
    }
}