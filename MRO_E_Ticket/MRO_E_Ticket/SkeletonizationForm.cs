using System;
using System.Drawing;
using System.Windows.Forms;

namespace MRO_E_Ticket
{
    public partial class SkeletonizationForm : Form
    {
        Bitmap originalImage;
        Bitmap resultlImage;
        SkeletonizationImageLTRB skelet = new SkeletonizationImageLTRB();

        public SkeletonizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                originalImage = new Bitmap(filePath);
                pictureBox1.Image = originalImage;
                resultlImage = skelet.SkeletizationRun(originalImage);
                pictureBox2.Image = resultlImage;
            }
        }
    }
}
