using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class Pixelizer
    {
        public Bitmap process(Bitmap image)
        {
            Bitmap tmp = new Bitmap(image, new Size(image.Width /10, image.Height /10));
            ImageToPaletteConverter c = new ImageToPaletteConverter();
            c.convert(tmp, new Palette8bit());
            Bitmap res = new Bitmap(tmp, new Size(image.Width, image.Height));
            return res;
        }
    }
}
