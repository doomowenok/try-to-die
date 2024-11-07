using Zenject;

namespace Code.Common.Config.Installers
{
    public sealed class ConfigProviderInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourcesConfigProvider>().AsSingle();
        }
    }
}