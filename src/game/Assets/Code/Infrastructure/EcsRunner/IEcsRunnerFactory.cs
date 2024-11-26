using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;

namespace Code.Infrastructure.EcsRunner
{
    public interface IEcsRunnerFactory
    {
        UniTask<Installer> CreateRunner(EcsRunnerType runnerType);
    }
}