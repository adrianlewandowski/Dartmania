using Dartmania.Models;
using Dartmania.Services;
using MvvmHelpers;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dartmania.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public GameModel CurrentGame { get; set; }
        IPlayerService playerService;
        public GameViewModel()
        {
            CurrentGame = new GameModel();
            Title = "Dartmania";
            playerService = DependencyService.Get<IPlayerService>();
        }

    }
}