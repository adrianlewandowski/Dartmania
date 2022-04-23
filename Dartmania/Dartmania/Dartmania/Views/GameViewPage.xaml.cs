using Dartmania.Models;
using MvvmHelpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using Dartmania.Services.Points_Calculator;
using System.Collections.Generic;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameViewPage : ContentPage
    {
        public GameModel currentGame = new GameModel();
        public int throwCounter = 3;
        private string finishCounter;
        public string FinishCounter
        {
            get { return finishCounter; }
            set
            {
                finishCounter = value;
                OnPropertyChanged(nameof(FinishCounter)); // Notify that there was a change on this property
            }
        }
        private int multiply;
        public Dictionary<string, int> triples = new Dictionary<string, int> { {"T1", 3}, {"T2", 6}, {"T3", 9}, { "T4", 12}, {"T5", 15}, { "T6", 18 }, { "T7", 21 },
        {"T8", 24}, {"T9", 27}, {"T10", 30}, {"T11", 33}, {"T12", 36}, {"T13", 39}, {"T14", 42}, {"T15", 45}, {"T16", 48}, {"T17", 51}, {"T18", 54}, {"T19", 57}, {"T20", 60}};
        public Dictionary<string, int> doubles = new Dictionary<string, int> { {"D1", 2}, { "D2", 4 }, { "D3", 6 }, { "D4", 8 }, { "D5", 10 }, { "D6", 12 },
        {"D7", 14}, {"D8", 16}, {"D9", 18}, {"D10", 20}, {"D11", 22}, {"D12", 24}, {"D13", 26}, {"D14", 28}, {"D15", 30}, {"D16", 32}, {"D17", 34},
        {"D18", 36}, {"D19", 38}, {"D20", 40}, {"DB", 50} };
        public Dictionary<string, int> singles = new Dictionary<string, int> { {"1", 1}, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
        {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}, {"11", 11}, {"12", 12}, {"13", 13}, {"14", 14}, {"15", 15}, {"16", 16}, {"17", 17}, {"18", 18},
        {"19", 19}, {"20", 20}, {"B", 25}};
        public GameViewPage()
        {
            InitializeComponent();
            BindingContext = this;
            FinishCounter = "Lepszy Start";
        }
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            int CurrentThrow = Convert.ToInt32(button.Text);
            if (multiply == 3)
            {
                CurrentThrow *= 3;
            } else if (multiply == 2)
            {
                CurrentThrow *= 2;
            }
            if ((currentGame.Score1 - CurrentThrow < 0 || currentGame.Score1 - CurrentThrow == 1) || (currentGame.Score1 - CurrentThrow == 0 && multiply != 2))
            {
                Alert("FURA!","Return");
                throwCounter = 1;
                Throw();
                return;
            }
            else
            {
                currentGame.Score1 -= CurrentThrow;
                currentGame.ThrowsPlayer1.Add(CurrentThrow);
                LblResult.Text = Convert.ToString(currentGame.Score1);
            }
            if (currentGame.Score1 == 0 && multiply == 2)
            {
                var avg = Math.Round(Queryable.Average(currentGame.ThrowsPlayer1.AsQueryable()));

                AlertFinish("Game Ended","Throws: " + currentGame.ThrowsPlayer1.Count() + "\n" + "Average score: " + avg,"Return");
                currentGame.Score1 = 501;
            }
            Throw();
            Counter();
            multiply = 1;
        }

        void Counter()
        {
            if ((throwCounter == 3) && (currentGame.Score1 <= 170))
            {
                LabelFinisher.Text = ThreeShots.calculateFinish(triples, doubles, singles, currentGame.Score1, (currentGame.ThrowsPlayer1.Count() % 3) + 1);
            }
            else if ((throwCounter == 2) && (currentGame.Score1 <= 100))
            {
                LabelFinisher.Text = TwoShots.calculateFinish(triples, doubles, singles, currentGame.Score1, (currentGame.ThrowsPlayer1.Count() % 3) + 1);
            }
            else if ((throwCounter == 1) && (currentGame.Score1 <= 40))
            {
                LabelFinisher.Text = OneShot.calculateFinish(doubles, currentGame.Score1, (currentGame.ThrowsPlayer1.Count() % 3) + 1);
            }else if(throwCounter == 1 && (currentGame.Score1 != 0))
            {
                LabelFinisher.Text = ThreeShots.calculateFinish(triples, doubles, singles, currentGame.Score1, 3);
            }
        }

        void Throw()
        {
            throwCounter--;
            if (throwCounter == 0)
            {
                throwCounter = 3;
                LblThrows.Text = "| | |";
            }
            if (throwCounter == 2)
            {
                LblThrows.Text = "| |";
            }
            if (throwCounter == 1)
            {
                LblThrows.Text = "|";
            }
        }

        void ThrowUndo()
        {
            throwCounter++;
            if(throwCounter >= 4)
            {
                throwCounter = 3;
            }
            if (throwCounter == 3)
            {
                LblThrows.Text = "| | |";
            }
            if (throwCounter == 2)
            {
                LblThrows.Text = "| |";
            }
            if(throwCounter == 1)
            {
                LblThrows.Text = "|";
            }
        }
        async void AlertFinish(string text,string text1, string text2)
        {
            await DisplayAlert(text, text1, text2);
        }
        async void Alert(string text,string text2)
        {
            await DisplayAlert(text, "", text2);
        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            ThrowUndo();
            if(currentGame.ThrowsPlayer1.Count() > 0)
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