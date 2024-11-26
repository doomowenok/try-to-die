using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.EcsRunner
{
    public interface IEcsRunnerController
    {
        UniTask EnableRunner(EcsRunnerType runnerType);
        UniTask DisableRunner(EcsRunnerType runnerType);
    }
}