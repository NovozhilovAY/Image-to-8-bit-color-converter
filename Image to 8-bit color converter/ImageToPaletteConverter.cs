﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_to_8_bit_color_converter
{
    class ImageToPaletteConverter
    {
        private List<List<Color>> rows_of_colors;
        private List<Color> colors;
        private List<Task> tasks;
        public void convert(Bitmap image, Palette _palette)
        {
            colors = _palette.get_colors();

            //for (int i = 0; i < image.Height; i++)
            //{
            //    for (int j = 0; j < image.Width; j++)
            //    {
            //        Color new_color = get_similar_color_from_palette(image.GetPixel(j, i));
            //        image.SetPixel(j, i, new_color);
            //    }
            //}
            for (int i = 0; i < image.Height; i++)
            {
                rows_of_colors[i] = new List<Color>();
                for (int j = 0; j < image.Width; j++)
                {
                    rows_of_colors[i].Add(image.GetPixel(j, i));
                }
            }

            for(int i = 0; i < rows_of_colors.Count;i++)
            {
                int cur_i = i;
                Task t = new Task(() => Process_row(rows_of_colors[cur_i]));
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            Set_new_colors(image);
        }

        void Process_row(List<Color> row)
        {
            for (int i = 0; i < row.Count; i++)
            {
                row[i] = Get_similar_color_from_palette(row[i]);
            }
        }

        private void Set_new_colors(Bitmap image)
        {
            for(int y = 0;y < image.Height;y++)
            {
                for(int x = 0;x<image.Width;x++)
                {
                    image.SetPixel(x, y, rows_of_colors[y][x]);
                }
            }
        }

        private Color Get_similar_color_from_palette(Color color)
        {
            Color new_color;
            int R = color.R;
            int G = color.G;
            int B = color.B;
            int min_dif = int.MaxValue;
            int min_ind = 0;
            for (int i = 0; i < colors.Count; i++)
            {
                int dif = Math.Abs(colors[i].R - R) + Math.Abs(colors[i].G - G) + Math.Abs(colors[i].B - B);
                if (dif < min_dif)
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