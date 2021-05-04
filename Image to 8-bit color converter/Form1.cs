using System;
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
        const int MAX_PIXEL_SIZE = 16;
        private Palette p8b;
        private Palette p12b;
        private Palette p16b;
        private Palette p6b;
        private Palette paletteFromFile;
        private Palette paletteFromFile2;
        private Palette paletteFromFile3;
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
            images = new Bitmap[MAX_PIXEL_SIZE];
            tasks = new List<Task>();
            pixelizer = new Pixelizer();
            p8b = new Palette8bit();
            p12b = new Palette12bit();
            p16b = new Palette16bit();
            p6b = new Palette6bit();
            paletteFromFile = new PaletteFromFile("C:\\Users\\sasha\\source\\repos\\Image to 8-bit color converter\\ufo32.png");
            paletteFromFile2 = new PaletteFromFile("C:\\Users\\sasha\\source\\repos\\Image to 8-bit color converter\\ufo128.png");
            paletteFromFile3 = new PaletteFromFile("C:\\Users\\sasha\\source\\repos\\Image to 8-bit color converter\\wave.jpg");
            trackBar1.Maximum = MAX_PIXEL_SIZE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrightnessUpFilter bf = new BrightnessUpFilter(); 
            ImageToPaletteConverter converter = new ImageToPaletteConverter();
            //bf.Process(image);
            converter.Convert(image, paletteFromFile);    
            pictureBox1.Image = image;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = images[trackBar1.Value-1];
            image = images[trackBar1.Value - 1];
        }

        public void pixelize_image(Bitmap orig,int pos, int pixel_size)
        {
           images[pos] = pixelizer.process(orig, pixel_size); 
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (d.ShowDialog() == DialogResult.OK)
            {
                image = (Bitmap)Image.FromFile(d.FileName);
                images[0] = image;
                for (int i = 1; i < MAX_PIXEL_SIZE; i++)
                {
                    int localI = i;
                    Bitmap tmp = new Bitmap(image);
                    Task t = Task.Run(() => pixelize_image(tmp, localI, localI + 1));
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
                    tasks.Clear();
                }
                pictureBox1.Image = image;
                trackBar1.Value = 1;
            }
        }
    }
}
