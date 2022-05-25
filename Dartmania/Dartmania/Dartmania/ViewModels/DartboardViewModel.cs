using Dartmania.Models;
using Dartmania.Services;
using MvvmHelpers;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;

namespace Dartmania.ViewModels
{
    public class DartboardViewModel : ViewModelBase
    {
        public DartboardViewModel()
        {
            Title = "Dartmania";
        }
    }
}
