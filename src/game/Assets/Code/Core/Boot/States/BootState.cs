using Code.Common.SceneLoading;
using Code.Core.Gameplay.Features.Loading;
using Code.Infrastructure.MVVM.Factory;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Core.Boot.States
{
    public sealed class BootState : IPayloadState<string>
    {
        private readonly IApplicationStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IWindowFactory _windowFactory;
        private readonly LoadingModel _loadingModel;
        private readonly LoadingViewModel _loadingViewModel;

        // TODO::Usage of WindowFactory is temp, need to create UI service that controls windows.
        public BootState(
            IApplicationStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            IWindowFactory windowFactory,
            LoadingModel loadingModel,
            LoadingViewModel loadingViewModel)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _windowFactory = windowFactory;
            _loadingModel = loadingModel;
            _loadingViewModel = loadingViewModel;
        }
        
        public async UniTask Enter(string sceneName)
        {
            LoadingView view = await _windowFactory.CreateWindow<LoadingView>("LoadingView");
            view.Subscribe();
            _loadingViewModel.Subscribe();
            
            
            DOTween.To(
                () => _loadingModel.LoadingProgress.Value,
                (value) => _loadingModel.ChangeLoadingProgress(value),
                1.0f,
                10.0f);

            // await _sceneLoader.LoadSceneAsync(sceneName, DebugProgress, DebugComplete);
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
        
        // TODO::Fill progress in loading window.
        private void DebugProgress(float progress)
        {
            Debug.Log($"Loading scene progress: {progress}");
            _loadingModel.ChangeLoadingProgress(progress);
        }

        // TODO::Create game world.
        private void DebugComplete()
        {
            Debug.Log($"Loading scene complete.");
            _loadingModel.ChangeLoadingProgress(33.0f);
        }
    }
}