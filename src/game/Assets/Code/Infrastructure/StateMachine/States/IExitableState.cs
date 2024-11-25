using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StateMachine.States
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}