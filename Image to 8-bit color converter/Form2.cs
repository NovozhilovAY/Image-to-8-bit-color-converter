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
    public partial class Form2 : Form
    {
        private Bitmap image;
        //public Form2()
        //{
        //    InitializeComponent();
        //}
        public Form2(Bitmap _image)
        {
            InitializeComponent();
            image = _image;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }
    }
}
