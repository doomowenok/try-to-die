using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StateMachine.States
{
    public interface IPayloadState<in TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}