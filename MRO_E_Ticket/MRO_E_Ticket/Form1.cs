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
using PerceptronLib;
namespace MRO_E_Ticket
{
    public partial class Form1 : Form
    {
        private Domain.ImageConverter imageConverter = new Domain.ImageConverter();
        private List<ParametersForGistogram> mainList = new List<ParametersForGistogram>();
        private List<ParametersForGistogram> DividedImageList;
        private TransformationForTheHistogram trans = new TransformationForTheHistogram();
        private List<ImageCollection> numberImageCollection = new List<ImageCollection>();
        //rotate image class--------
        private RotateBitmapImage rotateBitmapImage = new RotateBitmapImage();
        #region Image
        private Bitmap originalImage;
        private Bitmap grayBitmap;
        private Bitmap binary;
        private int[,] DividedImage;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        //open menu image
        private void OpenImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                originalImage = new Bitmap(filePath);
                OriginalPictureBox.Image = originalImage;
            }
        }
        //open image method
        private Bitmap OpenImage()
        {
            Bitmap returnBitmap = null;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                originalImage = new Bitmap(filePath);
                returnBitmap = originalImage;
            }
            return returnBitmap;
        }
        #region TabControl
        private void SaveImageInPictureBox(PictureBox picrure)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Bmp;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                picrure.Image.Save(saveFileDialog.FileName, format);
            }
        }
        //transfer to grayscale event
        private void TransferToGrayscaleTabPage_Click(object sender, EventArgs e)
        {
            grayBitmap = imageConverter.TransferToGrayscaleGetBitmap(originalImage);
            GrayScalePictureBox.Image = grayBitmap;
        }
        //binarization event
        private void BinarizationTabPage_Click(object sender, EventArgs e)
        {
            Bitmap binarizationImage = imageConverter.BinarizationThresholdMethodGetBitmap(grayBitmap);
            BinarizationPictureBox.Image = binarizationImage;
            binary = binarizationImage;
        }
        //tabcontrol indexChange
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl page = sender as TabControl;
            switch (page.SelectedIndex)
            {
                case 1:
                    #region Transfer to grayscale
                    try
                    {
                        imageConverter.Progress += ImageConverter_Progress;
                        if (originalImage != null)
                        {
                            grayBitmap = imageConverter.TransferToGrayscaleGetBitmap(originalImage);
                            GrayScalePictureBox.Image = grayBitmap;
                        }
                        else { throw new Exception("choose a grayscale image:"); }
                    }
                    catch (Exception ex)
                    {
                        DialogResult result1 = MessageBox.Show(ex.Message.ToString(),
                                                 "no original image selected",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
                        if (result1 == DialogResult.Yes)
                        {

                            originalImage = OpenImage();
                            OriginalPictureBox.Image = originalImage;
                            page.SelectedIndex = 0;
                        }
                    }
                    break;
                #endregion
                case 2:
                    #region Binarization image
                    try
                    {
                        if (grayBitmap != null)
                        {
                            imageConverter.Progress += ImageConverter_Progress;
                            Bitmap binarizationImage = imageConverter.BinarizationThresholdMethodGetBitmap(grayBitmap);
                            BinarizationPictureBox.Image = binarizationImage;
                            binary = binarizationImage;
                            var resultGisto = trans.Parameters(imageConverter.BinarizationThresholdMethodGetArray(grayBitmap));
                            mainList = resultGisto;
                        }
                        else if (binary == null)
                        {
                            binary = OpenImage();
                            BinarizationPictureBox.Image = binary;
                            var resultGisto = trans.Parameters(imageConverter.BinarizationThresholdMethodGetArray(binary));
                            mainList = resultGisto;
                        }
                        else { throw new Exception("choose a binarization image:"); }
                    }
                    catch (Exception ex)
                    {
                        DialogResult result1 = MessageBox.Show(ex.Message.ToString(),
                                                 "no grayscale image selected",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
                        if (result1 == DialogResult.Yes)
                        {

                            binary = OpenImage();
                            BinarizationPictureBox.Image = binary;
                            page.SelectedIndex = 1;
                        }
                    }

                    break;
                #endregion
                case 3:
                    #region Segmentation
                    imageConverter.Progress += ImageConverter_Progress;
                    var arrayImage = imageConverter.BinarizationThresholdMethodGetArray(binary);
                    Segmentation segment = new Segmentation(arrayImage, mainList);
                    // remove up and down element image and
                    SegmentationPictureBox.Image = imageConverter.CreateBitmap(segment.RemoveUpAndDownElementImage(mainList, arrayImage));
                    //removing unnecessary lines segment.SelectionOfAreas()
                    var segmentImageInfo = imageConverter.CreateBitmap(segment.SelectionOfAreas());

                    //get array new small image
                    var arrayNewImage = imageConverter.BinarizationThresholdMethodGetArray(segmentImageInfo);
                    //get list params histogramm
                    var paramsForHistogrammNewImage = trans.HorizontalImageGetParameters(arrayNewImage);
                    var miniArray = segment.SelectionOfAreasInHorizontalImage(paramsForHistogrammNewImage, arrayNewImage);
                    var finishImageRecognition = imageConverter.CreateBitmap(miniArray);
                    SegmentationPictureBox.Image = finishImageRecognition;
                    //var afterBin = imageConverter.BinarizationThresholdMethodGetArray(seg);
                    //var Gisto2 = trans.HorizontalImageGetParameters(afterBin);
                    DividedImage = miniArray;
                    //get params miniImage fo segmentations numbers
                    DividedImageList = trans.HorizontalImageGetParameters(miniArray);
                    ImageRecognitionPictureBox1.Image = finishImageRecognition;
                    #endregion
                    break;

            }
        }
        #endregion
        //progress event
        private void ImageConverter_Progress(int value, int maxValue, string processName)
        {
            ProgressName.Text = processName;
            progressBar1.Maximum = maxValue;
            progressBar1.Value = value;
        }
        //save grayScale Image
        private void GrayScaleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveImageInPictureBox(GrayScalePictureBox);
        }
        //save binarization Image
        private void BinarizationImagelinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveImageInPictureBox(BinarizationPictureBox);
        }
        //show histogramm
        private void HistogrammlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Histogramm histgramm = new Histogramm();
            histgramm.setData(mainList);
            histgramm.Show();
        }
        //savre recondition Image
        private void SaveReconditionImageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveImageInPictureBox(ImageRecognitionPictureBox1);
        }
        //save collection image
        private void DividedIntoImageButton_Click(object sender, EventArgs e)
        {
            Segmentation segment = new Segmentation(null, null);
            numberImageCollection = segment.GetCollectionofImage(DividedImageList, DividedImage);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Bmp;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
            }
            foreach (var item in numberImageCollection)
            {
                item.bitmap.Save(item.Name + ".bmp", format);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stringVal = RotationTextBox.Text.Replace(".", ",");
            float angle = (float)Convert.ToDouble(stringVal);
            Bitmap map = rotateBitmapImage.RotateBitmap(binary, angle);
            binary = map;

            BinarizationPictureBox.Image = null;
            BinarizationPictureBox.Image = imageConverter.BinarizationThresholdMethodGetBitmap(binary);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Bmp;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
            }
            if (ExpansionCheckBox.Checked)
            {
                foreach (var item in ExpansionAndErosion.GetResultImageAfterExpansion(numberImageCollection, "Ex"))
                {
                    item.bitmap.Save(item.Name + ".bmp", format);
                }
            }
            if (ErosionCheckBox.Checked)
            {
                foreach (var item in ExpansionAndErosion.GetResultImageAfterErosion(numberImageCollection, "Er"))
                {
                    item.bitmap.Save(item.Name + ".bmp", format);
                }
            }
        }

        private void perceptronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerceptronViewer view = new PerceptronViewer();
            view.Show();
        }
    }
}
