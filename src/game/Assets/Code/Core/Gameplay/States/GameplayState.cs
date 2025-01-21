using Code.Infrastructure.EcsRunner;
using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;

namespace Code.Core.Gameplay.States
{
    public sealed class GameplayState : IState
    {
        private readonly IEcsRunnerController _ecsRunnerController;

        public GameplayState(IEcsRunnerController ecsRunnerController)
        {
            _ecsRunnerController = ecsRunnerController;
        }
        
        public UniTask Enter()
        {
            _ecsRunnerController.EnableRunner(EcsRunnerType.GameplayRunner);
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            _ecsRunnerController.DisableRunner(EcsRunnerType.GameplayRunner);
            return UniTask.CompletedTask;
        }
    }
}