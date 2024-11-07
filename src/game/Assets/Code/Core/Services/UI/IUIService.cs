using Cysharp.Threading.Tasks;

namespace Code.Core.Services.UI
{
    public interface IUIService
    {
        UniTask Show(UIViewType viewType);
        void Hide(UIViewType viewType);
    }
}