using Dartmania.Models;
using MvvmHelpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameViewPage : ContentPage
    {
        public GameModel currentGame = new GameModel();
        public GameViewPage()
        {

            InitializeComponent();
        }
        private int multiply;
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            int CurrentThrow = Convert.ToInt32(button.Text);
            if(multiply == 3)
            {
                CurrentThrow *= 3;
            }else if(multiply == 2)
            {
                CurrentThrow *= 2;
            }
            currentGame.ThrowsPlayer1.Add(CurrentThrow);
            currentGame.Score1 -= CurrentThrow;
            if(currentGame.Score1 == 0)
            {
                Alert();
            }
            LblResult.Text = Convert.ToString(currentGame.Score1);
            multiply = 1;
        }

        async void Alert()
        {
            await DisplayAlert("Game Ended", "", "Return to menu");
        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            if(currentGame.ThrowsPlayer1.Count >= 0)
            {
                var lastScore = currentGame.ThrowsPlayer1.Last();
                currentGame.Score1 += lastScore;
                currentGame.ThrowsPlayer1.RemoveAt(currentGame.ThrowsPlayer1.Count - 1);
                LblResult.Text = Convert.ToString(currentGame.Score1);
            }
        }

        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        private async void Btn_Multiply(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                if(button.Text == "TRIPLE")
                {
                    multiply = 3;
                }
                else
                {
                    multiply = 2;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

    }
}