using Dabuttemasu.Statics;
using Dabuttemasu.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace Dabuttemasu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var rm = this.Container.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion(ViewNames.MAIN_CONTROL_REGION, typeof(MainControl));
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
