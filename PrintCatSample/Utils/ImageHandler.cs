using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PrintCatSample.Utils
{
  class ImageHandler
  {
    public BitmapSource OriginalBitmapSource { get; set; }
    public Bitmap OriginalBitmap { get; set; }
    public ImageHandler(BitmapSource source)
    {
      this.OriginalBitmapSource = source;
      this.OriginalBitmap = ImageHelper.BitmapFromSource(source);
    }

    internal BitmapSource ColorBalance(int rValue, int gValue, int bValue)
    {
      Bitmap newBitmap = BitmapColorBalance.ColorBalance(OriginalBitmap, (byte)bValue, (byte)gValue, (byte)rValue);
      BitmapSource newSource = ImageHelper.ConvertBitmap(newBitmap);
      return newSource;
    }
  }
}
