using Code.Infrastructure.StateMachine.Factory;
using Zenject;

namespace Code.Infrastructure.StateMachine.Installers
{
    public sealed class StateMachineInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }
    }
}