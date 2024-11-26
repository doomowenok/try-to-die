using Zenject;

namespace Code.Infrastructure.SceneLoading.Installers
{
    public sealed class SceneLoaderInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        }
    }
}