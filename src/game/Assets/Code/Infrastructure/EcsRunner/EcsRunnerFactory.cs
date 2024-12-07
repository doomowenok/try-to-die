using System.Linq;
using Code.Infrastructure.Config;
using Cysharp.Threading.Tasks;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;
using Installer = Scellecs.Morpeh.Installer;

namespace Code.Infrastructure.EcsRunner
{
    public sealed class EcsRunnerFactory : IEcsRunnerFactory
    {
        private readonly DiContainer _container;
        private readonly EcsRunnerConfig _runnerConfig;

        public EcsRunnerFactory(IConfigProvider configProvider, DiContainer container)
        {
            _container = container;
            _runnerConfig = configProvider.GetConfig<EcsRunnerConfig>();
        }
        
        public async UniTask<Installer> CreateRunner(EcsRunnerType runnerType)
        {
            AsyncInstantiateOperation<Installer> operation = Object.InstantiateAsync(_runnerConfig.Runners[runnerType]);
            
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }

            Installer runner = operation.Result.First();
            
            runner.initializers.ForEach(system => _container.Inject(system));
            runner.updateSystems.ForEach(system => _container.Inject(system.System));
            runner.lateUpdateSystems.ForEach(system => _container.Inject(system.System));
            runner.fixedUpdateSystems.ForEach(system => _container.Inject(system.System));
            runner.cleanupSystems.ForEach(system => _container.Inject(system.System));

            return runner;
        }
    }
}