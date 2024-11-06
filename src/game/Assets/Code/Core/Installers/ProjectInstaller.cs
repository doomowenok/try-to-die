using Code.Core.Boot.Installers;
using Code.Infrastructure.StateMachine.Installers;
using Zenject;

namespace Code.Core.Project
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFeature<StateMachineInstaller>();
            BindFeature<BootInstaller>();
        }

        private void BindFeature<TInstaller>() where TInstaller : Installer
        {
            TInstaller installer = Container.Instantiate<TInstaller>();
            installer.InstallBindings();
        }
    }
}