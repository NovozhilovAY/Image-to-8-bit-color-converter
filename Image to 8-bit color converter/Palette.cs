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

        protected void fill_colors()
        {
            for(int r = 0; r < R_vals.Length; r++)
            {
                for(int g = 0; g < G_vals.Length; g++)
                {
                    for (int b = 0; b < B_vals.Length; b++)
                    {
                        Color new_color = new Color();
                        new_color = Color.FromArgb(R_vals[r], G_vals[g], B_vals[b]);
                        colors.Add(new_color);
                    }
                }
            }
        }
    }
}
