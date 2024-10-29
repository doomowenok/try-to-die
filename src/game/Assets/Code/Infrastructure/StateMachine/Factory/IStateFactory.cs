using Code.Infrastructure.StateMachine.States;

namespace Code.Infrastructure.StateMachine.Factory
{
    public interface IStateFactory
    {
        TState CreateState<TState>() where TState : class, IExitableState;
    }
}