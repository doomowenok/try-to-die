using Code.Infrastructure.MVVM.ViewModel;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.MVVM.View
{
    public abstract class BaseView<TViewModel> : MonoBehaviour, IView
        where TViewModel : IViewModel
    {
        [Inject] protected readonly TViewModel ViewModel;

        public GameObject ViewObject => gameObject;
        public GameObject PoolObject => gameObject;

        public abstract void Subscribe();
        public abstract void Unsubscribe();

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Release()
        {
            Hide();
        }
    }
}