using Zenject;

namespace Code.Core.Services.Savings.Installers
{
    public sealed class SavingsInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ByteSaveLoadService>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ProtobufSaveDataManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}