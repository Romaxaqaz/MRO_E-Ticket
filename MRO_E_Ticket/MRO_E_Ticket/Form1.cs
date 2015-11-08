using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRO_E_Ticket.Domain;
using MRO_E_Ticket.Model;
using ZedGraph;
using System.Drawing.Imaging;

namespace MRO_E_Ticket
{
    public partial class Form1 : Form
    {
        private Domain.ImageConverter imageConverter = new Domain.ImageConverter();
        public Form1()
        {
            InitializeComponent();
        }
        private List<ParametersForGistogram> mainList = new List<ParametersForGistogram>();
        Bitmap binary;
        TransformationForTheHistogram trans = new TransformationForTheHistogram();
        private void OpenImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Bitmap bitmap = new Bitmap(filePath);
                OriginalPictureBox.Image = bitmap;
                Bitmap grayBitmap = imageConverter.TransferToGrayscaleGetBitmap(bitmap);
                GrayScalePictureBox.Image = grayBitmap;
                Bitmap binarizationImage = imageConverter.BinarizationThresholdMethodGetBitmap(grayBitmap);
                BinarizationPictureBox.Image = binarizationImage;
                binary = binarizationImage;
                var resultGisto = trans.Parameters(imageConverter.BinarizationThresholdMethodGetArray(grayBitmap));
                mainList = resultGisto;
                Histogramm form2 = new Histogramm();
                form2.setData(resultGisto);
                form2.Show();
            }
        }
        Segmentation segment = new Segmentation();
        private void button1_Click(object sender, EventArgs e)
        {
            var array = imageConverter.BinarizationThresholdMethodGetArray(binary);
            SegmentationPictureBox.Image = imageConverter.CreateBitmap(segment.Fullparameters(mainList, array));
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                SegmentationPictureBox.Image.Save(sfd.FileName, format);
            }
        }
    }
}
