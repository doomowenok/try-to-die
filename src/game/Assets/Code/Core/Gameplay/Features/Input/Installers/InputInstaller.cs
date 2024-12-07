using Zenject;

namespace Code.Core.Gameplay.Features.Input.Installers
{
    public sealed class InputInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayInput>().AsSingle();
        }
    }
}