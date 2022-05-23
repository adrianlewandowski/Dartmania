using Dartmania.Models;
using Dartmania.Services;
using Dartmania.Views.Player;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dartmania.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Player> Player { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand AddPlayerCommand { get; }

        IPlayerService playerService;
        public PlayersViewModel()
        {
            Title = "Lista gracz";
            Player = new ObservableRangeCollection<Player>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddPlayerCommand = new AsyncCommand(Add);
            playerService = DependencyService.Get<IPlayerService>();
        }


        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);
            Player.Clear();
            var players = await playerService.GetPlayers();
            Player.AddRange(players);
            IsBusy = false;
        }
        async Task Add()
        {
            var route = $"{nameof(AddPlayerPage)}?Name=Enter Name";
            await Shell.Current.GoToAsync(route);
        }
    }
}