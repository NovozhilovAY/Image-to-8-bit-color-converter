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
        public Bitmap process(Bitmap image,int p_size)
        {
            Bitmap res = new Bitmap(image, new Size(image.Width, image.Height));
            List<Color> one_pixel_colors = new List<Color>();
            
            for(int y = 0; y < image.Height; y += p_size)
            {
                for(int x = 0; x < image.Width; x += p_size)
                {
                    one_pixel_colors.Clear();
                    for(int i = y; i < y + p_size; i++)
                    {
                        if(i >= image.Height)
                        {
                            break;
                        }
                        for(int j = x; j < x + p_size; j++)
                        {
                           if(j >= image.Width)
                           {
                                break;
                           }
                           one_pixel_colors.Add(image.GetPixel(j, i));
                        }
                    }
                    Color new_color = get_avr_color(one_pixel_colors);
                    for (int i = y; i < y + p_size; i++)
                    {
                        if (i >= image.Height)
                        {
                            break;
                        }
                        for (int j = x; j < x + p_size; j++)
                        {
                            if (j >= image.Width)
                            {
                                break;
                            }
                            res.SetPixel(j, i,new_color);
                        }
                    }
                }
            }
            return res;
        }

        private Color get_avr_color(List<Color> colors)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            int c_num = colors.Count;
            for (int i = 0;i< c_num; i++)
            {
                R += colors[i].R;
                G += colors[i].G;
                B += colors[i].B;
            }
            
            return Color.FromArgb((int)(R / (double)c_num), (int)(G / (double)c_num),(int)(B / (double)c_num));
        }
    }
}
