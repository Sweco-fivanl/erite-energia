using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
//using Windows.UI.Xaml;

namespace SkiaWpf.View
{
  /// <summary>
  /// Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : UserControl
  {
    public MainView()
    {
      InitializeComponent();
    }

      private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
      {
          // the the canvas and properties
          var canvas = e.Surface.Canvas;

            // get the screen density for scaling
            //var display = DisplayInformation.GetForCurrentView();
            //double dpi = DisplayProperties.LogicalDpi;
            //var display = Window.GetWindow()
          PresentationSource source = PresentationSource.FromVisual(this);

          double dpiX, dpiY;
          float scale = 1;
          if (source != null)
          {
              scale = ToSingle(source.CompositionTarget?.TransformToDevice.M11);
              //dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
              //dpiY = 96.0 * source.CompositionTarget.TransformToDevice.M22;
          }

          //  var scale = display.LogicalDpi / 96.0f;
          //var scale = 
          var scaledSize = new SKSize(e.Info.Width / scale, e.Info.Height / scale);

          // handle the device screen density
          canvas.Scale(scale);

          // make sure the canvas is blank
          canvas.Clear(SKColors.White);

          // draw some text
          var paint = new SKPaint
          {
              Color = SKColors.Black,
              IsAntialias = true,
              Style = SKPaintStyle.Fill,
              TextAlign = SKTextAlign.Center,
              TextSize = 24
          };
          var coord = new SKPoint(scaledSize.Width / 2, (scaledSize.Height + paint.TextSize) / 2);
          canvas.DrawText("SkiaSharp", coord, paint);

          const float hatchWidth = 20;

          // create the path (diagonal hatch) with the center at 0,0
          var hatchPath = new SKPath();
          hatchPath.MoveTo(0, hatchWidth);
          hatchPath.LineTo(hatchWidth, 0);
          hatchPath.LineTo(0, -hatchWidth);
          hatchPath.LineTo(-hatchWidth, 0);
          hatchPath.LineTo(0, hatchWidth);

          // the size of the pattern
          var hatchMatrix = SKMatrix.MakeScale(hatchWidth * 2, hatchWidth * 2);
          // create the paint
          var hatchPaint = new SKPaint
          {
              PathEffect = SKPathEffect.Create2DPath(hatchMatrix, hatchPath),
              Color = SKColors.Gray,
              Style = SKPaintStyle.Stroke,
              StrokeWidth = 1
          };

          // the rectangle to draw
          var rect = SKRect.Create(60, 50, 310, 300);

          // draw the background
          var backgroundPaint = new SKPaint
          {
              Color = SKColors.LightGray,
              Style = SKPaintStyle.Fill,
          };
          canvas.DrawRect(rect, backgroundPaint);

          // shift the drawing because the 2D Path starts at the canvas origin
          canvas.Save();
          canvas.Translate(rect.Location);

          var hatchRect = SKRect.Create(rect.Size);
          canvas.ClipRect(hatchRect);
          canvas.DrawRect(hatchRect, hatchPaint);

          // undo the translate and clip
          canvas.Restore();

          // draw a border
          var borderPaint = new SKPaint
          {
              Color = SKColors.DarkGray,
              Style = SKPaintStyle.Stroke,
              StrokeWidth = 3
          };
          canvas.DrawRect(rect, borderPaint);
        }

      public static float ToSingle(double? value)
      {
          if (null == value) return 1;
          return (float)value;
      }
    }
}
