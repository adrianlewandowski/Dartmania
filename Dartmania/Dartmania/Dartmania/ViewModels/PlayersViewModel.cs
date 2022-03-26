using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dartmania.Services;

namespace Dartmania.ViewModels
{
    class PlayersViewModel : BaseViewModel
    {
        public PlayersViewModel()
        {
            async Task Add()
            {
                var name = await App.Current.MainPage.DisplayPromptAsync("Name","Proszę podać nazwę gracza","OK","Anuluj");
                await DbServcies.AddPlayer(name);
                await Refresh();
            }

            async Task Refresh()
            {
            }

        }
    }
}
