using Code.Common.SceneLoading.Installers;
using Code.Core.Boot.Installers;
using Code.Infrastructure.StateMachine.Installers;
using Zenject;

namespace Code.Core.Installers
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFeature<SceneLoaderInstaller>();
            
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