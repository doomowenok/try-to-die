using Code.Infrastructure.StateMachine.States;
using Zenject;

namespace Code.Infrastructure.StateMachine.Factory
{
    public sealed class StateFactory : IStateFactory
    {
        private readonly DiContainer _context;

        public StateFactory(DiContainer context)
        {
            _context = context;
        }
        
        public TState CreateState<TState>() where TState : class, IExitableState
        {
            TState state = _context.Instantiate<TState>();
            
            _context
                .Bind<TState>()
                .FromInstance(state)
                .AsSingle()
                .Lazy();
            
            return state;
        }
    }
}