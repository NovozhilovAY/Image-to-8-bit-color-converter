using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class Palette
    {
        private List<Color> colors;

        protected int[] R_vals;
        protected int[] G_vals;
        protected int[] B_vals;

        public List<Color> get_colors()
        {
            return colors;
        }

    }
}
