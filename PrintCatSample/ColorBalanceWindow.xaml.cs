using PrintCatSample.Utils;
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
using System.Windows.Shapes;

namespace PrintCatSample
{
  /// <summary>
  /// Interaction logic for ColorBalanceWindow.xaml
  /// </summary>
  public partial class ColorBalanceWindow : Window
  {
    private ImageHandler imageHandler;
    public ColorBalanceWindow()
    {
      InitializeComponent();
      imageHandler = new ImageHandler(theImage.Source as BitmapSource);
    }


    private void reset_Click(object sender, RoutedEventArgs e)
    {
      RSlider.Value = 0;
      GSlider.Value = 0;
      BSlider.Value = 0;
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (e.OldValue == e.NewValue)
      {
        return;
      }
      //Console.WriteLine(String.Format("{0},{1},{2}", RSlider.Value, GSlider.Value, BSlider.Value));
      int rValue = (int)RSlider.Value;
      int gValue = (int)GSlider.Value;
      int bValue = (int)BSlider.Value;
      float adjRValue = 0f;
      float adjGValue = 0f;
      float adjBValue = 0f;

      if (rValue < 0)
      {
        adjBValue += -rValue;
        adjGValue += -rValue;
      }
      else
      {
        adjRValue += rValue;
      }
      if (gValue < 0)
      {
        adjRValue += -gValue;
        adjBValue += -gValue;
      }
      else
      {
        adjGValue += gValue;
      }
      if (bValue < 0)
      {
        adjRValue += -bValue;
        adjGValue += -bValue;
      }
      else
      {
        adjBValue += bValue;
      }

      int adjRValueP = (int)Math.Round(255 * (1 - adjRValue / 100));
      int adjGValueP = (int)Math.Round(255 * (1 - adjGValue / 100));
      int adjBValueP = (int)Math.Round(255 * (1 - adjBValue / 100));
      Console.WriteLine(String.Format("adjust value is {0},{1},{2}", adjRValueP, adjGValueP, adjBValueP));



      if (rValue == 0 && gValue == 0 && bValue == 0)
      {
        theImage.Source = imageHandler.OriginalBitmapSource;
      }
      else
      {
        BitmapSource newSource = imageHandler.ColorBalance(adjRValueP, adjGValueP, adjBValueP);
        //BitmapSource newSource = imageHandler.ColorBalance(255, 0, 0);
        theImage.Source = newSource;
      }

    }
  }
}
