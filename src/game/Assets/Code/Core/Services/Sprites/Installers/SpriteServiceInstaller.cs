using Zenject;

namespace Code.Core.Services.Sprites.Installers
{
    public sealed class SpriteServiceInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SpriteService>().AsSingle();
        }
    }
}