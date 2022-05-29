using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Reflection;
using System.IO;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DartboardPage : ContentPage
    {
        SKBitmap bitmap;
        float width;
        float height;

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
                SKBitmap temp = SKBitmap.Decode(stream);
                SKImageInfo scaledInfo = new SKImageInfo(e.Info.Width, (int)Remap(e.Info.Height, 0, e.Info.Height, 0, temp.Height));
                bitmap =  new SKBitmap(scaledInfo);
                temp.ScalePixels(bitmap, SKFilterQuality.Medium);
            }
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            width = info.Width;
            height = info.Height;
            float x = (info.Width - bitmap.Width) / 2;
            float y = (info.Height - bitmap.Height) / 2;

            canvas.DrawBitmap(bitmap, x, y);
            //Content = canvasView;
        }

        private void OnTouching(object sender, SKTouchEventArgs e)
        {
            float ratio = height / width;

            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    var cords = e.Location;
                    var x = Remap(e.Location.X, 0, width, - 200, 200);
                    var y = Remap(e.Location.Y, 0, height , - 200 * ratio, 200 * ratio) * -1;
                    var distance = calculateDistance(x, y);
                    var angle = calculateAngle(y, x) * 180/Math.PI;
                    if (angle < 0) angle += 360;
                    var scoreWM = angleToScore((float)angle);
                    var scoreM = distanceToMulitply((float)distance);
                    var score = calculateScore(scoreWM, scoreM, (float)distance);

                    break;
            }
        }

        private double calculateDistance(float x, float y) 
        {
            return Math.Sqrt((x*x) + (y*y));
        }

        private double calculateAngle(double y, double x) 
        {
            return Math.Atan2(y, x);
        }

        public  float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public int angleToScore(float angle)
        {
            int score = 0;
            if (angle >= 0 && angle < 9) score = 6;
            else if (angle >= 9 && angle < 27) score = 13;
            else if (angle >= 27 && angle < 45) score = 4;
            else if (angle >= 45 && angle < 63) score = 18;
            else if (angle >= 63 && angle < 81) score = 1;
            else if (angle >= 81 && angle < 99) score = 20;
            else if (angle >= 91 && angle < 117) score = 5;
            else if (angle >= 117 && angle < 135) score = 12;
            else if (angle >= 135 && angle < 153) score = 9;
            else if (angle >= 153 && angle < 171) score = 14;
            else if (angle >= 171 && angle < 189) score = 11;
            else if (angle >= 189 && angle < 207) score = 8;
            else if (angle >= 207 && angle < 225) score = 16;
            else if (angle >= 225 && angle < 243) score = 7;
            else if (angle >= 243 && angle < 261) score = 19;
            else if (angle >= 261 && angle < 279) score = 3;
            else if (angle >= 279 && angle < 297) score = 17;
            else if (angle >= 297 && angle < 315) score = 2;
            else if (angle >= 315 && angle < 333) score = 15;
            else if (angle >= 333 && angle < 351) score = 10;
            else score = 6;
            
            return score;
        }
        public int distanceToMulitply(float distance) 
        {
            int multiply;
            if (distance >= 17.3 && distance < 100.5) multiply = 1;
            else if (distance >= 100.5 && distance < 111.7) multiply = 3;
            else if (distance >= 111.7 && distance < 167.6) multiply = 1;
            else if (distance >= 167.6 && distance < 180) multiply = 2;
            else multiply = 0;

            return multiply;
        }
        public float calculateScore(float a, float b, float distance) 
        {
            float score = a * b;

            if (distance <= 7.3) return 50;
            else if (distance > 7.3 && distance <= 17.3) return 25;

            return score;
        }

    }
}