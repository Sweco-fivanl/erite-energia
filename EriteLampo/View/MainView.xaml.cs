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
      }

      public static float ToSingle(double? value)
      {
          if (null == value) return 1;
          return (float)value;
      }
    }
}
