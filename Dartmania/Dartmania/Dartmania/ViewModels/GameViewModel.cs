using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dartmania.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public GameViewModel()
        {
            Title = "Dartmania";
        }

        public ICommand OpenWebCommand { get; }
    }
}