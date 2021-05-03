using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class PaletteFromFile: Palette
    {
        Bitmap image;
        HashSet<Color> unic_colors;
        public PaletteFromFile(string File)
        {
            image = (Bitmap)Image.FromFile(File);
            unic_colors = new HashSet<Color>();
            for(int y = 0;y < image.Height;y++)
            {
                for(int x = 0;x<image.Width;x++)
                {
                    unic_colors.Add(image.GetPixel(x, y));
                }
            }
            colors = unic_colors.ToList();
        }
    }
}
