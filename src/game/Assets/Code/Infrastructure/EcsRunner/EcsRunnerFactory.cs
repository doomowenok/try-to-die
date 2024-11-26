using System.Linq;
using Code.Infrastructure.Config;
using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;
using UnityEngine;

namespace Code.Infrastructure.EcsRunner
{
    public sealed class EcsRunnerFactory : IEcsRunnerFactory
    {
        private readonly EcsRunnerConfig _runnerConfig;

        public EcsRunnerFactory(IConfigProvider configProvider)
        {
            _runnerConfig = configProvider.GetConfig<EcsRunnerConfig>();
        }
        
        public async UniTask<Installer> CreateRunner(EcsRunnerType runnerType)
        {
            AsyncInstantiateOperation<Installer> operation = Object.InstantiateAsync(_runnerConfig.Runners[runnerType]);
            
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }

            return operation.Result.First();
        }
    }
}