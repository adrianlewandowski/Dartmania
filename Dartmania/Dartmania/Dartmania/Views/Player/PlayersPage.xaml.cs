using Dartmania.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {

        public PlayersPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (PlayersViewModel)BindingContext;
            if (vm.Player.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }
    }
}
