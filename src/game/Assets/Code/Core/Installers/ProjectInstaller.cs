using Code.Core.Gameplay.Features.Input.Installers;
using Code.Core.Gameplay.Features.Loading.Installers;
using Code.Core.Gameplay.Features.Map.Installers;
using Code.Core.Services.Savings.Installers;
using Code.Core.Services.Sprites.Installers;
using Code.Core.Services.Time;
using Code.Core.Services.Time.Installers;
using Code.Core.Services.UI.Installers;
using Code.Infrastructure.Config.Installers;
using Code.Infrastructure.EcsRunner.Installers;
using Code.Infrastructure.MVVM.Installers;
using Code.Infrastructure.Pool.Installers;
using Code.Infrastructure.Resource.Installers;
using Code.Infrastructure.SceneLoading.Installers;
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
            BindFeature<SpriteServiceInstaller>();
            BindFeature<TimeServiceInstaller>();
            BindFeature<SavingsInstaller>();
            BindFeature<EcsRunnerInstaller>();

            BindFeature<ConfigProviderInstaller>();

            BindFeature<StateMachineInstaller>();

            BindFeature<InputInstaller>();
            BindFeature<SceneLoaderInstaller>();
            BindFeature<LoadingInstaller>();
            BindFeature<MapInstaller>();
        }

        private void BindFeature<TInstaller>() where TInstaller : Installer
        {
            TInstaller installer = Container.Instantiate<TInstaller>();
            installer.InstallBindings();
        }
    }
}