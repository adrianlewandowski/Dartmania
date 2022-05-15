using Dartmania.ViewModels;
using Dartmania.Views;
using Dartmania.Views.Player;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Dartmania
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlayerGameSoloPage), typeof(PlayerGameSoloPage));
            Routing.RegisterRoute(nameof(AddPlayerPage), typeof(AddPlayerPage));
            Routing.RegisterRoute(nameof(GameViewPage), typeof(GameViewPage));
        }

    }
}