using Dartmania.Views;
using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dartmania.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public AsyncCommand StartGame { get; }
        public AsyncCommand StartGameSolo { get; }

        public AsyncCommand Dart { get; }
        public HomeViewModel()
        {
            Title = "Dartmania";
            StartGame = new AsyncCommand(Start);
            StartGameSolo = new AsyncCommand(Solo);
            Dart = new AsyncCommand(DartBoard);
        }

        async Task Start()
        {
            var route = $"{nameof(GameViewPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Solo()
        {
            var route = $"{nameof(PlayerGameSoloPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task DartBoard()
        {
            var route = $"{nameof(DartboardPage)}";
            await Shell.Current.GoToAsync(route);
        }
        public ICommand OpenWebCommand { get; }
    }
}