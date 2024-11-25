using Zenject;

namespace Code.Core.Gameplay.Features.Map.Installers
{
    public sealed class MapInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NextMapPartTypeService>().AsSingle();
        }
    }
}