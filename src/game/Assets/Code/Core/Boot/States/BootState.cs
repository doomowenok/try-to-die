using Code.Common.SceneLoading;
using Code.Core.Gameplay.Features.Loading;
using Code.Core.Gameplay.Features.Map;
using Code.Core.Services.UI;
using Code.Infrastructure.MVVM.Factory;
using Code.Infrastructure.Resource;
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
        private readonly IUIService _uiService;
        private readonly LoadingModel _loadingModel;
        private readonly DiContainer _container;
        private readonly IResourceProvider _resourceProvider;

        public BootState(
            IApplicationStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            IUIService uiService,
            LoadingModel loadingModel,
            DiContainer container,
            IResourceProvider resourceProvider)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiService = uiService;
            _loadingModel = loadingModel;
            _container = container;
            _resourceProvider = resourceProvider;
        }
        
        public async UniTask Enter(string sceneName)
        {
            await _uiService.Show(UIViewType.Loading);
            
            DOTween.To(
                    () => _loadingModel.LoadingProgress.Value,
                    (value) => _loadingModel.ChangeLoadingProgress(value),
                    1.0f,
                    10.0f)
                .OnComplete(() => _uiService.Hide(UIViewType.Loading));

            MapPart mapPart = await _resourceProvider.Get<MapPart>("MapPart");
            _container.InstantiatePrefabForComponent<MapPart>(mapPart);

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