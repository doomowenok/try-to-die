using Zenject;

namespace Code.Infrastructure.MVVM.ViewModel
{
    public abstract class BaseViewModel<TModel> : IViewModel
    {
        [Inject] protected readonly TModel Model;

        public abstract void Subscribe();
        public abstract void Unsubscribe();
    }
}