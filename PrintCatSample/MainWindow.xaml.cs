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

namespace PrintCatSample
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void rgb_balance_Click(object sender, RoutedEventArgs e)
    {
      Window win = new ColorBalanceWindow();
      win.Show();
    }

    private void color_slider_btn_Click(object sender, RoutedEventArgs e)
    {
      Window win = new ColorSliderWindow();
      win.Show();
    }

    private void printer_btn_Click(object sender, RoutedEventArgs e)
    {
      Window win = new PrinterWindows();
      win.Show();
    }

    private void rotate_btn_Click(object sender, RoutedEventArgs e)
    {
      Window win = new RotateWindow();
      win.Show();
    }
  }
}
