﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_to_8_bit_color_converter
{
    public partial class Form1 : Form
    {
        const int MAX_PIXEL_SIZE = 30;
        private Palette p8b;
        private Palette p12b;
        private Palette p16b;
        private Pixelizer pixelizer;
        private List<Task> tasks; 
        private Bitmap[] images;
        private Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = (Bitmap)Image.FromFile("C:\\Users\\sasha\\source\\repos\\Image to 8-bit color converter\\test.jpg");
            images = new Bitmap[MAX_PIXEL_SIZE];
            images[0] = image;
            tasks = new List<Task>();
            pixelizer = new Pixelizer();
            for (int i = 1; i < MAX_PIXEL_SIZE; i++)
            {
                int localI = i;
                Bitmap tmp = new Bitmap(image);
                Task t = Task.Run(() => pixelize_image(tmp, localI, localI + 1));
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            p8b = new Palette8bit();
            p12b = new Palette12bit();
            p16b = new Palette16bit();
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageToPaletteConverter converter = new ImageToPaletteConverter();
            
            //pictureBox1.Image = image;
            //pictureBox1.Refresh();
            Pixelizer p = new Pixelizer();
            
            Bitmap new_b = p.process(image,5);
            converter.convert(new_b, p8b);
            
            pictureBox1.Image = new_b;
            pictureBox1.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = images[trackBar1.Value-1];

        }

        public void pixelize_image(Bitmap orig,int pos, int pixel_size)
        {
           images[pos] = pixelizer.process(orig, pixel_size); 
        }
    }
}
