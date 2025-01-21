using Scellecs.Morpeh;

namespace Code.Infrastructure.EcsRunner
{
    public interface IEcsRunnerFactory
    {
        Installer CreateRunner(EcsRunnerType runnerType);
    }
}