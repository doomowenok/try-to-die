using Zenject;

namespace Code.Common.SceneLoading.Installers
{
    public sealed class SceneLoaderInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        }
    }
}