using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using CollectionViewSource.Views;

namespace CollectionViewSource
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(MainPage));
            await Task.Yield();
        }
    }
}
