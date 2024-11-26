using Zenject;

namespace Code.Infrastructure.EcsRunner.Installers
{
    public sealed class EcsRunnerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EcsRunnerFactory>().AsSingle();
            Container.BindInterfacesTo<EcsRunnerController>().AsSingle();
        }
    }
}