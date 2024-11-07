using Code.Common.Config.Installers;
using Code.Common.SceneLoading.Installers;
using Code.Core.Gameplay.Features.Loading.Installers;
using Code.Core.Services.UI.Installers;
using Code.Infrastructure.MVVM.Installers;
using Code.Infrastructure.Pool.Installers;
using Code.Infrastructure.Resource.Installers;
using Code.Infrastructure.StateMachine.Installers;
using Zenject;

namespace Code.Core.Installers
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFeature<MvvmInstaller>();
            BindFeature<ObjectPoolInstaller>();
            BindFeature<ResourcesInstaller>();
            BindFeature<UIServiceInstaller>();
            
            BindFeature<ConfigProviderInstaller>();

            BindFeature<StateMachineInstaller>();
            
            BindFeature<SceneLoaderInstaller>();
            BindFeature<LoadingInstaller>();
        }

        private void BindFeature<TInstaller>() where TInstaller : Installer
        {
            TInstaller installer = Container.Instantiate<TInstaller>();
            installer.InstallBindings();
        }
    }
}