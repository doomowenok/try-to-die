using System.Collections.Generic;
using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Infrastructure.EcsRunner
{
    [CreateAssetMenu(fileName = nameof(EcsRunnerConfig), menuName = "Configs/Ecs Runner")]
    public sealed class EcsRunnerConfig : SerializedScriptableObject
    {
        public Dictionary<EcsRunnerType, Installer> Runners;
    }
}