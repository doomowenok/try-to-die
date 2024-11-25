using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StateMachine.States
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}