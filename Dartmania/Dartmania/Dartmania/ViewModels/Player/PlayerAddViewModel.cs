using Dartmania.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dartmania.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class PlayerAddViewModel : ViewModelBase
    {
        string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public AsyncCommand SaveCommand { get; }

        IPlayerService playerService;
        public PlayerAddViewModel()
        {
            Title = "Add Player";
            SaveCommand = new AsyncCommand(Save);
            playerService = DependencyService.Get<IPlayerService>();
        }

        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            await playerService.AddPlayer(name);

            await Shell.Current.GoToAsync("..");
        }
    }
}