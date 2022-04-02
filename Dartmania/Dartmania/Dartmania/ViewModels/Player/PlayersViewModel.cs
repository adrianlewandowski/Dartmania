using Dartmania.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Dartmania.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Grouping<string, Player>> PlayersList { get; set; }

        public ObservableRangeCollection<Player> Player { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand AddPlayerCommand { get; }
        public PlayersViewModel()
        {
            Title = "Lista gracz";
            Player = new ObservableRangeCollection<Player>();
            PlayersList = new ObservableRangeCollection<Grouping<string,Player>>();
            RefreshCommand = new AsyncCommand(Refresh);
            //AddPlayerCommand = new AsyncCommand(AddPlayer());
        }


        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            IsBusy = false;
        }
        public void AddPlayer()
        {

        }


    }
}
