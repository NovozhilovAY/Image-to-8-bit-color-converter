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
        HashSet<int> R;
        HashSet<int> G;
        HashSet<int> B;
        public PaletteFromFile(string File)
        {
            image = (Bitmap)Image.FromFile(File);
            unic_colors = new HashSet<Color>();
            R = new HashSet<int>();
            G = new HashSet<int>();
            B = new HashSet<int>();
            for (int y = 0;y < image.Height;y++)
            {
                for(int x = 0;x<image.Width;x++)
                {
                    Color cur_color = image.GetPixel(x, y);
                    unic_colors.Add(cur_color);
                    R.Add(cur_color.R);
                    G.Add(cur_color.G);
                    B.Add(cur_color.B);
                }
            }
            colors = unic_colors.ToList();
            R_vals = R.ToArray();
            G_vals = G.ToArray();
            B_vals = B.ToArray();
        }
    }
}
