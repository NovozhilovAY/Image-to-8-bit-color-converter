using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class BrightnessUpFilter
    {
        const int VAL = 30;
        public void Process(Bitmap image)
        {
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color new_color = GetLighterColor(image.GetPixel(x,y));
                    image.SetPixel(x, y, new_color);
                }
            }
        }
        Color GetLighterColor(Color color)
        {
            return Color.FromArgb(Rounder(color.R + VAL), Rounder(color.G + VAL), Rounder(color.B + VAL));
        }

        int Rounder(int val)
        {
            if(val >= 255)
            {
                return 255;
            }
            else if(val < 0)
            {
                return 0;
            }
            else
            {
                return val;
            }
        }
    }
}
