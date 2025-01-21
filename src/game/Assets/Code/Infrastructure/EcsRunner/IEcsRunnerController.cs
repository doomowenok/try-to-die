namespace Code.Infrastructure.EcsRunner
{
    public interface IEcsRunnerController
    {
        void EnableRunner(EcsRunnerType runnerType);
        void DisableRunner(EcsRunnerType runnerType);
    }
}