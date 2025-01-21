using Code.Infrastructure.Config;
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
        
        public Installer CreateRunner(EcsRunnerType runnerType)
        {
            Installer runner = Object.Instantiate(_runnerConfig.Runners[runnerType]);
            
            runner.initializers.ForEach(system => _container.Inject(system));
            runner.updateSystems.ForEach(system => _container.Inject(system.System));
            runner.lateUpdateSystems.ForEach(system => _container.Inject(system.System));
            runner.fixedUpdateSystems.ForEach(system => _container.Inject(system.System));
            runner.cleanupSystems.ForEach(system => _container.Inject(system.System));

            return runner;
        }
    }
}