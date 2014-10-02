using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace PrintCatSample
{
  /// <summary>
  /// Interaction logic for RotateWindow.xaml
  /// </summary>
  public partial class RotateWindow : Window
  {
    public RotateWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      System.Windows.Size size = new System.Windows.Size(600, 400);
      StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical, RenderSize = size };

      System.Windows.Controls.Image ImageCtrl = new System.Windows.Controls.Image();
      BitmapImage bitImg = new BitmapImage(new Uri("C:\\temp\\32367-78aNJdO.jpg"));
      ImageCtrl.Source = bitImg;
      TransformGroup transformGroup = new TransformGroup();
      ScaleTransform scaleTransform = new ScaleTransform(1, 1);
      transformGroup.Children.Add(scaleTransform);

      System.Windows.Controls.Image image = new System.Windows.Controls.Image { Source = ImageCtrl.Source, Stretch = Stretch.Uniform };

      //image.RenderTransform = new ScaleTransform(1, 1);

      BitmapSource imgSrouce = ImageCtrl.Source as BitmapSource;
      if (imgSrouce.PixelWidth < imgSrouce.PixelHeight)
      {
        /*
        double argle = 90 * 180 / 3.142;
        RotateTransform rotateTransform = new RotateTransform();
        rotateTransform.Angle = argle;
        transformGroup.Children.Add(rotateTransform);
         * */
        image.LayoutTransform = new RotateTransform(90);
      }

      image.RenderTransform = transformGroup;

      stackPanel.Children.Add(image);

      stackPanel.Measure(size);
      stackPanel.Arrange(new Rect(new System.Windows.Point(0, 0), stackPanel.DesiredSize));
      this.AddChild(stackPanel);
    }
  }
}
