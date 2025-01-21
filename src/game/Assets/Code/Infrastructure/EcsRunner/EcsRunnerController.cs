using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;
using UnityEngine;

namespace Code.Infrastructure.EcsRunner
{
    public sealed class EcsRunnerController : IEcsRunnerController
    {
        private readonly IEcsRunnerFactory _ecsRunnerFactory;
        private readonly Dictionary<EcsRunnerType, Installer> _activeRunners = new(16);

        public EcsRunnerController(IEcsRunnerFactory ecsRunnerFactory)
        {
            _ecsRunnerFactory = ecsRunnerFactory;
        }

        public void EnableRunner(EcsRunnerType runnerType)
        {
            if (_activeRunners.ContainsKey(runnerType))
            {
                Debug.LogWarning($"Runner {runnerType} already active.");
                return;
            }
            
            Installer runner = _ecsRunnerFactory.CreateRunner(runnerType);
            _activeRunners.Add(runnerType, runner);
        }

        public void DisableRunner(EcsRunnerType runnerType)
        {
            if (_activeRunners.TryGetValue(runnerType, out Installer runner))
            {
                Object.Destroy(runner.gameObject);
                _activeRunners.Remove(runnerType);
            }
            else
            {
                Debug.LogError($"Runner {runnerType} not active or created before.");
            }
        }
    }
}