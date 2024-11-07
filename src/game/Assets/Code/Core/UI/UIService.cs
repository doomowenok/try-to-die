using System;
using System.Collections.Generic;
using Code.Common.Config;
using Code.Core.Gameplay.Features.Loading;
using Code.Core.UI.Configs;
using Code.Infrastructure.MVVM.Factory;
using Code.Infrastructure.MVVM.View;
using Code.Infrastructure.MVVM.ViewModel;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Core.UI
{
    public sealed class UIService : IUIService
    {
        private readonly Dictionary<Type, IView> _activeViews = new Dictionary<Type, IView>();
        
        private readonly IWindowFactory _windowFactory;
        private readonly IConfigProvider _configProvider;
        private readonly DiContainer _container;

        public UIService(IWindowFactory windowFactory, IConfigProvider configProvider, DiContainer container)
        {
            _windowFactory = windowFactory;
            _configProvider = configProvider;
            _container = container;
        }

        public async UniTask Show(UIViewType viewType)
        {
            UIConfig config = _configProvider.GetConfig<UIConfig>();

            switch (viewType)
            {
                case UIViewType.None:
                    break;
                case UIViewType.Loading:
                    await Subscribe<LoadingView, LoadingViewModel>(config.UIData[viewType].Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }

        public void Hide(UIViewType viewType)
        {
            switch (viewType)
            {
                case UIViewType.None:
                    break;
                case UIViewType.Loading:
                    Unsubscribe<LoadingView, LoadingViewModel>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }

        private async UniTask Subscribe<TView, TViewModel>(string name) 
            where TView : MonoBehaviour, IView  
            where TViewModel : IViewModel
        {
            TView view = await _windowFactory.CreateWindow<TView>(name);
            TViewModel viewModel = _container.Resolve<TViewModel>();
            view.Subscribe();
            viewModel.Subscribe();
            
            _activeViews.Add(typeof(TView), view);
        }
        
        private void Unsubscribe<TView, TViewModel>() 
            where TView : MonoBehaviour, IView  
            where TViewModel : IViewModel
        {
            TViewModel viewModel = _container.Resolve<TViewModel>();
            viewModel.Unsubscribe();

            TView view = _activeViews[typeof(TView)] as TView;
            
            if (view == null)
            {
                Debug.LogWarning($"View {typeof(TView).Name} not found");
                return;
            }

            _windowFactory.DisposeWindow<TView>(view);
            _activeViews.Remove(typeof(TView));
        }
    }
}