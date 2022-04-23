using Dartmania.Models;
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
        public GameViewModel()
        {
            CurrentGame = new GameModel();
            Title = "Dartmania";
        }

    }
}