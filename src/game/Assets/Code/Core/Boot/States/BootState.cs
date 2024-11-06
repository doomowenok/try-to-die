using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;

namespace Code.Core.Boot.States
{
    public sealed class BootState : IState
    {
        private readonly IApplicationStateMachine _stateMachine;

        public BootState(IApplicationStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public UniTask Enter()
        {
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}