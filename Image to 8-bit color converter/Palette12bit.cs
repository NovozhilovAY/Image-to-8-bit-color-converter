using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class Palette12bit : Palette
    {
        public Palette12bit()
        {
            colors = new List<Color>(4096);
            B_vals = G_vals = R_vals = split_range_of_values(0, 255, 16);
            fill_colors();
        }
    }
}