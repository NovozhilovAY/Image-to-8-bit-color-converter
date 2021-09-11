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
        enum CurP{p6b, p8b, p12b, p16b };
        const int MAX_PIXEL_SIZE = 16;

        private Pixelizer pixelizer;
        private List<Task> tasks; 
        private Bitmap[] images;
        private Bitmap cur_image;
        private Form result_form;
        private bool IsResultFormLoaded;
        private Palette cur_palette;
        private Bitmap result_image;

        CurP cur_p;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            images = new Bitmap[MAX_PIXEL_SIZE];
            tasks = new List<Task>();
            pixelizer = new Pixelizer();
            cur_palette = new Palette8bit();
            cur_p = CurP.p8b;
            PixelSizeTrackBar.Maximum = MAX_PIXEL_SIZE;
            //button1.Enabled = false;
            //PixelSizeTrackBar.Enabled = false;
            //PaletteToolStripMenuItem.Enabled = false;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Disable_GUI();
        //    backgroundWorker2.RunWorkerAsync();
        //}

        //public void pixelize_image(Bitmap orig,int pos, int pixel_size)
        //{
        //    images[pos] = pixelizer.process(orig, pixel_size);
        //}
        //private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog d = new OpenFileDialog();
        //    d.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
        //    if (d.ShowDialog() == DialogResult.OK)
        //    {
        //        Bitmap image = (Bitmap)Image.FromFile(d.FileName);
        //        image = GetCopyWith32bppArgbPixelFormat(image);
        //        cur_image = image;
        //        images[0] = new Bitmap(cur_image);
        //        Disable_GUI();
        //        backgroundWorker1.RunWorkerAsync();
        //        UpdateTitle();
        //    }
        //}
        //private Bitmap GetCopyWith32bppArgbPixelFormat(Bitmap _image)
        //{
        //    if(_image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        //    {
        //        Bitmap new_image = _image.Clone(new Rectangle(0, 0, _image.Width, _image.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //        _image = new_image;
        //    }
        //    return _image;
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 1; i < MAX_PIXEL_SIZE; i++)
            //{
            //    int localI = i;
            //    backgroundWorker1.ReportProgress((int)Calc_percent(i, MAX_PIXEL_SIZE));
            //    Bitmap tmp = new Bitmap(cur_image);
            //    Task t = Task.Run(() => pixelize_image(tmp, localI, localI + 1));
            //    tasks.Add(t);
            //    if (tasks.Count == Environment.ProcessorCount)
            //    {
            //        Task.WaitAll(tasks.ToArray());
            //        tasks.Clear();
            //    }
            //}
            //if (tasks.Count != 0)
            //{
            //    Task.WaitAll(tasks.ToArray());
            //    tasks.Clear();
            //}
            //pictureBox1.Image = new Bitmap(cur_image);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
        }

        //private double Calc_percent(int part, int val)
        //{
        //    return part / (val / 100.0);
        //}

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBar1.Value = 0;
            //PixelSizeTrackBar.Value = 1;
            //Enable_GUI();
        }

        //private void Enable_GUI()
        //{
        //    menuStrip2.Enabled = true;
        //    button1.Enabled = true;
        //    PixelSizeTrackBar.Enabled = true;
        //    PaletteToolStripMenuItem.Enabled = true;
        //}

        //private void Disable_GUI()
        //{
        //    menuStrip2.Enabled = false;
        //    button1.Enabled = false;
        //    PixelSizeTrackBar.Enabled = false;
        //    PaletteToolStripMenuItem.Enabled = false;
        //}

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //ImageToPaletteConverter converter = new ImageToPaletteConverter();
            //result_image = converter.Convert(cur_image, cur_palette, backgroundWorker2);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (IsResultFormLoaded)
            //{
            //    result_form.Close();
            //}
            //result_form = new Form2(result_image);
            //result_form.Show();
            //IsResultFormLoaded = true;
            //progressBar1.Value = 0;
            //Enable_GUI();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
        }

    //    private void p6bToolStripMenuItem_Click(object sender, EventArgs e)
    //    {
    //        cur_palette = new Palette6bit();
    //        cur_p = CurP.p6b;
    //        UpdateTitle();
    //    }

    //    private void p8bToolStripMenuItem1_Click(object sender, EventArgs e)
    //    {
    //        cur_palette = new Palette8bit();
    //        cur_p = CurP.p8b;
    //        UpdateTitle();
    //    }

    //    private void p12ToolStripMenuItem2_Click(object sender, EventArgs e)
    //    {
    //        cur_palette = new Palette12bit();
    //        cur_p = CurP.p12b;
    //        UpdateTitle();
    //    }

    //    private void p16bToolStripMenuItem3_Click(object sender, EventArgs e)
    //    {
    //        cur_palette = new Palette16bit();
    //        cur_p = CurP.p16b;
    //        UpdateTitle();
    //    }
    //    private void UpdateTitle()
    //    {
    //        string title = "Size:" + cur_image.Width.ToString() + "x" + cur_image.Height.ToString() + "   ";
    //        title += "Pixel size:" + PixelSizeTrackBar.Value.ToString() + "   ";
    //        switch(cur_p)
    //        {
    //            case CurP.p6b:
    //                title += " Palette:6 bit";
    //                break;
    //            case CurP.p8b:
    //                title += " Palette:8 bit";
    //                break;
    //            case CurP.p12b:
    //                title += " Palette:12 bit";
    //                break;
    //            case CurP.p16b:
    //                title += " Palette:16 bit";
    //                break;
    //        }
    //        Text = title;
    //    }

    //    private void PixelSizeTrackBar_Scroll(object sender, ScrollEventArgs e)
    //    {
    //        PixelSizeTrackBar.Refresh();
    //        pictureBox1.Image = images[PixelSizeTrackBar.Value - 1];
    //        cur_image = images[PixelSizeTrackBar.Value - 1];
    //        UpdateTitle();
    //    }
    }
}
