using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using System.Windows.Xps;

namespace PrintCatSample
{
  /// <summary>
  /// Interaction logic for PrinterWindows.xaml
  /// </summary>
  public partial class PrinterWindows : Window
  {
    public PrinterWindows()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      var server = new PrintServer();
      var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local,
     EnumeratedPrintQueueTypes.Connections});

      foreach (var queue in queues)
      {
        Console.WriteLine(queue.Name);
        var capabilities = queue.GetPrintCapabilities();
        foreach (PageMediaSize size in capabilities.PageMediaSizeCapability)
        { Console.WriteLine(size.ToString()); }
        Console.WriteLine();
      }
    }

    private void Print_Click(object sender, RoutedEventArgs e)
    {
      PrintDialog printDlg = new PrintDialog();

      if (printDlg.ShowDialog() == true)
      {
        printDlg.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.NorthAmerica4x6);
        //printDlg.PrintQueue.DefaultPrintTicket.PageOrientation = PageOrientation.Landscape;
        printDlg.PrintTicket.PageOrientation = PageOrientation.Landscape;
        Console.WriteLine("wwwwwwwwwwwwww->" + printDlg.PrintableAreaWidth);
        Console.WriteLine("hhhhhhhhhhhhhhh->" + printDlg.PrintableAreaHeight);
        Console.WriteLine("W-> "+printDlg.PrintTicket.PageMediaSize.Width);
        Console.WriteLine("H-> "+printDlg.PrintTicket.PageMediaSize.Height);
        //printDlg.PrintQueue.DefaultPrintTicket.PageOrientation = PageOrientation.Portrait;
        /*
        XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(printDlg.PrintQueue);
        PrintTicket ticket = new PrintTicket();
        if (printDlg.PrintTicket.PageOrientation == PageOrientation.Landscape)
        {
          ticket.PageMediaSize =
            new PageMediaSize(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight);
        }
        docWriter.Write(visual, ticket);
        */
        Size size = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
        StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical, RenderSize = size };

        //TextBlock title = new TextBlock { Text = @"Form", FontSize = 20 };
        //stackPanel.Children.Add(title);

        Image image = new Image { Source = this.theImage.Source, Stretch = Stretch.Uniform };
        image.RenderTransform = new ScaleTransform(1, 1);
        stackPanel.Children.Add(image);

        stackPanel.Measure(size);
        stackPanel.Arrange(new Rect(new Point(0, 0), stackPanel.DesiredSize));

        printDlg.PrintVisual(stackPanel, @"Form image");
        //printDlg.PrintVisual(theImage, "My First Print Job");
      }
    }
  }
}
