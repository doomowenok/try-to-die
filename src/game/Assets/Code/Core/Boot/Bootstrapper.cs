using Code.Core.Boot.States;
using Code.Core.Gameplay.States;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.Factory;
using UnityEngine;
using Zenject;

namespace Code.Core.Boot
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private bool _logEnabled;
        
        private IApplicationStateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Construct(IApplicationStateMachine stateMachine, IStateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }

        public void Start()
        {
            Debug.unityLogger.logEnabled = _logEnabled;
            
            _stateMachine.AddState(_stateFactory.CreateState<BootState>());
            _stateMachine.AddState(_stateFactory.CreateState<GameplayState>());

            _stateMachine.Enter<BootState, string>("Game");
        }
    }
}