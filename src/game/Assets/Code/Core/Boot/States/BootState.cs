using Code.Common.SceneLoading;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Core.Boot.States
{
    public sealed class BootState : IPayloadState<string>
    {
        private readonly IApplicationStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootState(IApplicationStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public async UniTask Enter(string sceneName)
        {
            await _sceneLoader.LoadSceneAsync(sceneName, DebugProgress, DebugComplete);
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
        
        // TODO::Fill progress in loading window.
        private void DebugProgress(float progress)
        {
            Debug.Log($"Loading scene progress: {progress}");
        }

        // TODO::Create game world.
        private void DebugComplete()
        {
            Debug.Log($"Loading scene complete.");
        }
    }
}