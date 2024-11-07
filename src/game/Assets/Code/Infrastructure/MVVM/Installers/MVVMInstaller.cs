using Code.Infrastructure.MVVM.Factory;
using Zenject;

namespace Code.Infrastructure.MVVM.Installers
{
    public sealed class MvvmInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindowFactory>().AsSingle();
        }
    }
}