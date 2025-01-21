using Zenject;

namespace Code.Core.Services.Time.Installers
{
    public sealed class TimeServiceInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<TimeService>()
                .AsSingle()
                .NonLazy();
        }
    }
}