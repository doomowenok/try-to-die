using Code.Core.Boot.States;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.Factory;
using Zenject;

namespace Code.Core.Boot.Installers
{
    public sealed class BootInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootState>().AsSingle();
        }
    }
}