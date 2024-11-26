using Zenject;

namespace Code.Infrastructure.Config.Installers
{
    public sealed class ConfigProviderInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourcesConfigProvider>().AsSingle();
        }
    }
}