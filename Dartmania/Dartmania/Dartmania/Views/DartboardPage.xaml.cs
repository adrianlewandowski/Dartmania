using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace Dartmania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DartboardPage : ContentPage
    {
        SKPaint blackFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        SKPaint redFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Red
        };

        SKPaint greenFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Green
        };

        SKPaint ringPatern = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            Color = SKColors.Red,
            StrokeWidth = 10
        };
        SKPaint rectRed = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            Color = SKColors.Red,
            StrokeWidth = 5
        };
        SKPaint rectGreen = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            Color = SKColors.Green,
            StrokeWidth = 5
        };

        SKPaint whiteTrianglePaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = SKColors.White,
            StrokeWidth = 5,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Square
        };

        SKPaint fillTriangle = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        public DartboardPage()
        {
            InitializeComponent();
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;


            //Get the widht and height of screen
            canvas.Clear(SKColors.CornflowerBlue);
            int width = e.Info.Width;
            int height = e.Info.Height;


            //Translate the width and height for canvas and scale with screen size
            canvas.Translate(width / 2 , height / 2);
            canvas.Scale(width/ 200f);
            canvas.DrawCircle(0, 0, 100, blackFillPaint);

            SKRect smallArcGreen = new SKRect();
            smallArcGreen.Size = new SKSize(80, 80);
            smallArcGreen.Location = new SKPoint(-40, -40);

            SKRect bigArcGreen = new SKRect();
            bigArcGreen.Size = new SKSize(160, 160);
            bigArcGreen.Location = new SKPoint(-80, -80);

            SKPath smallGreen = drawSegmentsGreen(smallArcGreen);
            SKPath bigGreen = drawSegmentsGreen(bigArcGreen);
            SKPath smallRed = drawSegmentsRed(smallArcGreen);
            SKPath bigRed = drawSegmentsRed(bigArcGreen);

            //TRIANGLE inicjacja listy(wywołanie metody whiteTriangle która zwraca liste punktów
            var Triangles = whiteTriangle();
            foreach(var triangle in Triangles)
            {
                canvas.DrawPoints(SKPointMode.Lines, triangle, whiteTrianglePaint);
            }

            canvas.DrawPath(smallGreen, rectGreen);
            canvas.DrawPath(bigGreen, rectGreen);
            canvas.DrawPath(smallRed, rectRed);
            canvas.DrawPath(bigRed, rectRed);
            canvas.DrawCircle(0, 0, 10, greenFillPaint);
            canvas.DrawCircle(0, 0, 5, redFillPaint);
        }

        private SKPath drawSegmentsGreen(SKRect arc)
        {
            SKPath skPath = new SKPath();
            float sweepAngle = 18;
            List<int> startAngle = new List<int>() { -80, -44, -8, 28, 64, 100, 136, 172, 208, 244, 280 };
            for (int i = 0; i <= startAngle.Count() - 1; i++)
            {
                skPath.AddArc(arc, startAngle[i], sweepAngle);
            }
            return skPath;

        }
        private SKPath drawSegmentsRed(SKRect arc)
        {
            SKPath skPath = new SKPath();
            float sweepAngle = 18;
            List<int> startAngle = new List<int>() { -98, -62, -26, 10, 46, 82, 118, 154, 190, 226, 262 };
            for (int i = 0; i <= startAngle.Count() - 1; i++)
            {
                skPath.AddArc(arc, startAngle[i], sweepAngle);
                skPath.FillType = SKPathFillType.EvenOdd;
            }
            return skPath;

        }

        //DRAW TRIANGLE FORM 3 POINTS
        private List<SKPoint[]> whiteTriangle()
        {
            List<SKPoint[]> triangleList = new List<SKPoint[]>();
            int[,] points =
            {
                {-33, 68 },
                {-11, 75 }
            };
            for (int i = 0; i < (points.Length / 2) - 1; i++)
            {
                SKPoint[] skPointsList = new SKPoint[]
                {
	                // Path 1 FROM 1 POINT TO CENTER
	                new SKPoint(points[i,0],points[i,1]),
                    new SKPoint(0,0),

	                // path 2 FROM 2 POINT TO CENTER
	                new SKPoint(points[i + 1,0],points[i + 1,1]),
                    new SKPoint(0,0),

	                // path 3 FROM 1 POINT TO 2 POINT
	                new SKPoint(points[i + 1,0],points[i + 1,1]),
                    new SKPoint(points[i,0],points[i,1]),
                };
                triangleList.Add(skPointsList);
            };
            return triangleList;
        }
    }
}