using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class Palette8bit: Palette
    {
        public Palette8bit()
        {
            colors = new List<Color>(256);
            G_vals = R_vals = split_range_of_values(0, 255, 8);
            B_vals = split_range_of_values(0, 255, 4);
            fill_colors();
        }
    }
}
