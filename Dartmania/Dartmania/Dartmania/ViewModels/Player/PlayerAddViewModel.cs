using Dartmania.Commands;
using Dartmania.Services;
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

        ICoffeeService coffeeService;
        public AddMyCoffeeViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
            coffeeService = DependencyService.Get<ICoffeeService>();
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(roaster))
            {
                return;
            }

            await coffeeService.AddCoffee(name, roaster);

            await Shell.Current.GoToAsync("..");
        }
    }
}
