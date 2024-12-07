using Code.Core.Gameplay.Features.Loading;
using Code.Core.Gameplay.States;
using Code.Core.Services.UI;
using Code.Infrastructure.SceneLoading;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Core.Boot.States
{
    public sealed class BootState : IPayloadState<string>
    {
        private readonly IApplicationStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIService _uiService;
        private readonly LoadingModel _loadingModel;

        public BootState(
            IApplicationStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            IUIService uiService,
            LoadingModel loadingModel)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiService = uiService;
            _loadingModel = loadingModel;
        }
        
        public async UniTask Enter(string sceneName)
        {
            await _uiService.Show(UIViewType.Loading);
            
            DOTween.To(
                    () => _loadingModel.LoadingProgress.Value,
                    (value) => _loadingModel.ChangeLoadingProgress(value),
                    1.0f,
                    1.0f)
                .OnComplete(() =>
                {
                    _uiService.Hide(UIViewType.Loading);
                    _sceneLoader.LoadSceneAsync(sceneName, DebugProgress, DebugComplete).Forget();
                });
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
            _stateMachine.Enter<GameplayState>().Forget();
        }
    }
}