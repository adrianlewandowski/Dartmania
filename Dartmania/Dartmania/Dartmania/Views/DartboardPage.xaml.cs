using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using AiForms;
using AiForms.Effects;
using System.Reflection;
using System.IO;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DartboardPage : ContentPage
    {
        SKBitmap bitmap;
        public DartboardPage()
        {
            InitializeComponent();
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvasView canvasView = new SKCanvasView();
            string resourceID = "Dartmania.images.board.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                bitmap = SKBitmap.Decode(stream);
            }
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float x = (info.Width - bitmap.Width) / 2;
            float y = (info.Height - bitmap.Height) / 2;

            canvas.DrawBitmap(bitmap, x, y);
            //Content = canvasView;
        }

        private void OnTouching(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    var cords = e.Location;
                    var x = Remap(e.Location.X, 0, 1440, - 100, 100);
                    var y = Remap(e.Location.Y, 0, 1916, - 100, 100);
                    Console.WriteLine();
                    break;
            }
        }

        public  float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

    }
}