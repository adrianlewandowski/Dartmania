using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameViewPage : ContentPage
    {
        public GameViewPage()
        {
            InitializeComponent();
        }
        private decimal firstNumner;
        private string operatorName;
        private int multiply;
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            int score = Convert.ToInt32(LblResult.Text);
            int CurrentThrow = Convert.ToInt32(button.Text);
            if(multiply == 3)
            {
                CurrentThrow *= 3;
            }else if(multiply == 2)
            {
                CurrentThrow *= 2;
            }
            score -= CurrentThrow;
            LblResult.Text = Convert.ToString(score);
            multiply = 1;
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            multiply = 1;
            firstNumner = 0;
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