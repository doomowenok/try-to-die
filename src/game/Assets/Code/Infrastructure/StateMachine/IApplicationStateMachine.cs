using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StateMachine
{
    public interface IApplicationStateMachine
    {
        void AddState<TState>(TState instance) where TState : class, IExitableState;
        UniTask Enter<TState>() where TState : class, IState;
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}