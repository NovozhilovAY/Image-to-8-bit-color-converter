﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int[] R_vals;
        private int[] G_vals;
        private int[] B_vals;
        private List<Task> tasks;
        public Bitmap Convert(Bitmap _image, Palette _palette)
        {
            Bitmap image = new Bitmap(_image);
            colors = _palette.get_colors();
            R_vals = _palette.Get_R();
            G_vals = _palette.Get_G();
            B_vals = _palette.Get_B();
            Fill_rows_of_colors(image);
            tasks = new List<Task>();
            for (int i = 0; i < rows_of_colors.Count; i++)
            {
                int cur_i = i;
                Task t = Task.Run(() => Process_row(rows_of_colors[cur_i]));
                tasks.Add(t);
                if (tasks.Count == Environment.ProcessorCount)
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                }
            }
            if (tasks.Count != 0)
            {
                Task.WaitAll(tasks.ToArray());
            }
            Set_new_colors(image);
            return image;
        }
        public Bitmap Convert(Bitmap _image, Palette _palette, BackgroundWorker bw)
        {
            Bitmap image = new Bitmap(_image);
            colors = _palette.get_colors();
            R_vals = _palette.Get_R();
            G_vals = _palette.Get_G();
            B_vals = _palette.Get_B();
            Fill_rows_of_colors(image);
            tasks = new List<Task>();
            for (int i = 0; i < rows_of_colors.Count; i++)
            {
                int cur_i = i;
                bw.ReportProgress((int)Calc_percent(i, rows_of_colors.Count));
                Task t = Task.Run(() => Process_row(rows_of_colors[cur_i]));
                tasks.Add(t);
                if (tasks.Count == Environment.ProcessorCount)
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                }
            }
            if (tasks.Count != 0)
            {
                Task.WaitAll(tasks.ToArray());
            }
            Set_new_colors(image);
            return image;
        }

        private void Fill_rows_of_colors(Bitmap image)
        {
            FastBitmap fb = new FastBitmap(image);
            fb.Lock();
            rows_of_colors = new List<List<Color>>(image.Height);
            for (int i = 0; i < image.Height; i++)
            {
                rows_of_colors.Add(new List<Color>(image.Width));
            }
            for (int i = 0; i < image.Height; i++)
            {
                rows_of_colors[i] = new List<Color>(image.Width);
                for (int j = 0; j < image.Width; j++)
                {
                    rows_of_colors[i].Add(fb.GetPixel(j, i));
                }
            }
            fb.Unlock();
        }
        private void Process_row(List<Color> row)
        {
            bool is_init = false;
            Color prew_color = new Color();
            Color new_prew_color = new Color();
            for (int i = 0; i < row.Count; i++)
            {
                if (is_init && prew_color == row[i])
                {
                    row[i] = new_prew_color;
                }
                else
                {
                    is_init = true;
                    prew_color = row[i];
                    row[i] = Get_similar_color_from_palette(row[i]);
                    new_prew_color = row[i];
                }
            }
        }

        private void Set_new_colors(Bitmap image)
        {
            FastBitmap fb = new FastBitmap(image);
            fb.Lock();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    fb.SetPixel(x, y, rows_of_colors[y][x]);
                }
            }
            fb.Unlock();
        }

        private Color Get_similar_color_from_palette(Color color)
        {
            int R = color.R;
            int G = color.G;
            int B = color.B;
            int new_R = Get_most_similar_number(R, R_vals);
            int new_G = Get_most_similar_number(G, G_vals);
            int new_B = Get_most_similar_number(B, B_vals);
            return Color.FromArgb(new_R,new_G,new_B);
        }

        private int Get_most_similar_number(int val, int[] arr)
        {
            int min_dif = int.MaxValue;
            int min_ind = 0;
            for(int i = 0; i<arr.Length; ++i)
            {
                int dif = Math.Abs(arr[i] - val);
                if (dif < min_dif)
                {
                    min_dif = dif;
                    min_ind = i;
                }
            }
            return arr[min_ind];
        }
        private double Calc_percent(int part, int val)
        {
            return part / (val / 100.0);
        }
    }
    
}
