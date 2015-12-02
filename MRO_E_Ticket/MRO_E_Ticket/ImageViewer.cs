using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRO_E_Ticket
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(string path)
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(path);
        }
    }
}
