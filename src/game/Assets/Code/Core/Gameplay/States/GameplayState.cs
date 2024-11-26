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
        
        public async UniTask Enter()
        {
            await _ecsRunnerController.EnableRunner(EcsRunnerType.GameplayRunner);
        }

        public async UniTask Exit()
        {
            await _ecsRunnerController.DisableRunner(EcsRunnerType.GameplayRunner);
        }
    }
}