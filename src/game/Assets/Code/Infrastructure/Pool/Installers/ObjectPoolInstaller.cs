using Zenject;

namespace Code.Infrastructure.Pool.Installers
{
    public sealed class ObjectPoolInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ObjectPool>().AsSingle();
        }
    }
}