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
    class StatisticsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Player> Player { get; set; }
        //public ObservableRangeCollection<Grouping<string, Player>> PlayerGroups { get; }
        public AsyncCommand RefreshCommand { get; }

        IPlayerService playerService;
        public StatisticsViewModel()
        {
            Title = "Settings";
            RefreshCommand = new AsyncCommand(Refresh);
            Player = new ObservableRangeCollection<Player>();
            playerService = DependencyService.Get<IPlayerService>();
            //PlayerGroups = new ObservableRangeCollection<Grouping<string, Player>>();
        }
        Player selectedPlayer;
        public Player SelectedPlayer
        {
            get => selectedPlayer;
            set => SetProperty(ref selectedPlayer, value);
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
    }
}
