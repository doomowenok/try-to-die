using Zenject;

namespace Code.Infrastructure.Resource.Installers
{
    public sealed class ResourcesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourceProvider>().AsSingle();
        }
    }
}