using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class Palette16bit : Palette
    {
        public Palette16bit()
        {
            colors = new List<Color>(65536);
            G_vals = split_range_of_values(0, 255, 64);
            B_vals = R_vals = split_range_of_values(0, 255, 32);
            fill_colors();
        }
    }
}
