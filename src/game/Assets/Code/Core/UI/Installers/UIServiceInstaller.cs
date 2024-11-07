using Zenject;

namespace Code.Core.UI.Installers
{
    public sealed class UIServiceInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
        }
    }
}