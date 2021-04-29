using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class ImageToPaletteConverter
    {
        private List<Color> colors;
        public void convert(Bitmap image, Palette _palette)
        {
            colors = _palette.get_colors();
            for(int i = 0; i < image.Height; i++)
            {
                for(int j = 0; j < image.Width; j++)
                {
                    Color new_color = get_similar_color_from_palette(image.GetPixel(i, j));
                    image.SetPixel(i, j, new_color);
                }
            }
        }

        private Color get_similar_color_from_palette(Color color)
        {
            Color new_color;
            int R = color.R;
            int G = color.G;
            int B = color.B;
            int min_dif = int.MaxValue;
            int min_ind = 0;
            for(int i = 0; i < colors.Count; i++)
            {
                int dif = Math.Abs(colors[i].R - R) + Math.Abs(colors[i].G - G) + Math.Abs(colors[i].B - B);
                if(dif < min_dif)
                {
                    min_dif = dif;
                    min_ind = i;
                }
            }
            new_color = colors[min_ind];
            return new_color;
        }
    }
}
