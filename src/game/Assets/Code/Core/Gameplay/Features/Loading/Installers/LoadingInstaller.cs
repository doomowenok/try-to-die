using Zenject;

namespace Code.Core.Gameplay.Features.Loading.Installers
{
    public sealed class LoadingInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingModel>().ToSelf().AsSingle();
            Container.Bind<LoadingViewModel>().ToSelf().AsSingle();
        }
    }
}