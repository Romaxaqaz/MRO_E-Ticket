using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MRO_E_Ticket.Domain;
using MRO_E_Ticket.Model;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace MRO_E_Ticket
{
    public partial class MainForm : Form
    {
        private Domain.ImageConverter imageConverter = new Domain.ImageConverter();
        private List<ParametersForGistogram> mainList = new List<ParametersForGistogram>();
        private List<ParametersForGistogram> DividedImageList;
        private TransformationForTheHistogram transformation = new TransformationForTheHistogram();
        private List<ImageCollection> numberImageCollection = new List<ImageCollection>();
        //rotate image class
        private RotateBitmapImage rotateBitmapImage = new RotateBitmapImage();
        #region Image
        private Bitmap originalImage;
        private Bitmap grayBitmap;
        private Bitmap binary;
        private int[,] DividedImage;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            NotifyLable.DataBindings.Add("Text", NotifyMessage.Instance, "MessageNotify");
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
                NotifyMessage.Instance.MessageNotify = "Open";
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

        #region TabContro
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
                        imageConverter.Progress += ImageConverter_Progress;
                        if (originalImage != null)
                        {
                            grayBitmap = imageConverter.TransferToGrayscaleGetBitmap(originalImage);
                            GrayScalePictureBox.Image = grayBitmap;
                        }
                        else { throw new Exception("choose a grayscale image:"); }

                    break;
                #endregion
                case 2:
                    #region Binarization image
                    if (grayBitmap != null)
                    {
                        imageConverter.Progress += ImageConverter_Progress;
                        Bitmap binarizationImage = imageConverter.BinarizationThresholdMethodGetBitmap(grayBitmap);
                        binary = binarizationImage;
                        var resultGisto = transformation.Parameters(imageConverter.BinarizationThresholdMethodGetArray(grayBitmap));
                        //rotate image
                        Bitmap afterRotete = rotateBitmapImage.RotateBitmap(binary, GetAngleRotate());
                        BinarizationPictureBox.Image = afterRotete;
                        binary = afterRotete;
                        mainList = resultGisto;
                    }
                    else if (binary == null)
                    {
                        binary = OpenImage();
                        //rotate image
                        Bitmap afterRotete = rotateBitmapImage.RotateBitmap(binary, GetAngleRotate());
                        BinarizationPictureBox.Image = afterRotete;
                        binary = afterRotete;
                        var resultGisto = transformation.Parameters(imageConverter.BinarizationThresholdMethodGetArray(afterRotete));
                        mainList = resultGisto;
                    }
                    break;
                #endregion
                case 3:
                    #region Segmentation
                    imageConverter.Progress += ImageConverter_Progress;
                    var arrayImage = imageConverter.BinarizationThresholdMethodGetArray(binary);
                    Segmentation segment = new Segmentation(arrayImage, mainList);
                    // remove up and down element image and
                    Bitmap UpDownRemove = imageConverter.CreateBitmap(segment.RemoveUpAndDownElementImage(mainList, arrayImage));
                    //removing unnecessary lines segment.SelectionOfAreas()
                    var segmentImageInfo = imageConverter.CreateBitmap(segment.SelectionOfAreas());
                    //get array new small image
                    var arrayNewImage = imageConverter.BinarizationThresholdMethodGetArray(segmentImageInfo);
                    //get list params histogramm
                    var paramsForHistogrammNewImage = transformation.HorizontalImageGetParameters(arrayNewImage);
                    var miniArray = segment.SelectionOfAreasInHorizontalImage(paramsForHistogrammNewImage, arrayNewImage);
                    miniArray = segment.RemoveBorder(miniArray);
                    var finishImageRecognition = imageConverter.CreateBitmap(miniArray);
                    SegmentationPictureBox.Image = finishImageRecognition;
                    //var afterBin = imageConverter.BinarizationThresholdMethodGetArray(seg);
                    //var Gisto2 = trans.HorizontalImageGetParameters(afterBin);
                    DividedImage = miniArray;
                    //get params miniImage fo segmentations numbers
                    DividedImageList = transformation.HorizontalImageGetParameters(miniArray);
                    ImageRecognitionPictureBox1.Image =  finishImageRecognition;
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
        //show histogramm
        private void HistogrammlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Histogramm histgramm = new Histogramm();
            histgramm.setData(mainList);
            histgramm.Show();
        }
        //save collection image
        private void DividedIntoImageButton_Click(object sender, EventArgs e)
        {
            NotifyMessage.Instance.MessageNotify = "Divided image";
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
            int x = 0;
            DividedimageList1.ImageSize = new Size(50, 50);
            foreach (var item in numberImageCollection)
            {
                // item.bitmap.Save(item.Name + ".bmp", format);
                DividedimageList1.Images.Add(Image.FromFile(item.Name+".bmp"));
                DividedListView.Items.Add("image",x++);
            }
            DividedListView.LargeImageList = DividedimageList1;
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
            NotifyMessage.Instance.MessageNotify = "Expaansion & Erosion operation";
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
            NotifyMessage.Instance.MessageNotify = "Open perceptron page";
            PerceptronViewer view = new PerceptronViewer();
            view.Show();
        }

        private void skeletizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyMessage.Instance.MessageNotify = "Open sckeletization page";
            SkeletonizationForm skel = new SkeletonizationForm();
            skel.Show();
        }

        private void DividedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in DividedListView.SelectedItems)
            {
                var listItem = numberImageCollection[item.Index];
                ImageViewer imageViewerForm = new ImageViewer(listItem.Name + ".bmp");
                imageViewerForm.Show();
            }
        }

        private float GetAngleRotate()
        {
            var angle = imageConverter.GetAngleImage(binary);
            string stringVal = angle.ToString().Replace(".", ",");
            float angleFloat = (float)Convert.ToDouble(stringVal);
            return angleFloat;
        }

        private void Save_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            switch(link.Name)
            {
                case "GrayScaleLinkLabel":
                    SaveImageInPictureBox(GrayScalePictureBox);
                    break;
                case "BinarizationImagelinkLabel":
                    SaveImageInPictureBox(BinarizationPictureBox);
                    break;
                case "SaveReconditionImageLinkLabel":
                    SaveImageInPictureBox(ImageRecognitionPictureBox1);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
    //class for notification
    public class NotifyMessage : INotifyPropertyChanged
    {
        private static readonly NotifyMessage instance = new NotifyMessage();
        private NotifyMessage() { }
        public static NotifyMessage Instance
        {
            get
            {
                return instance;
            }
        }
        public string _message;      
        public string MessageNotify
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("MessageNotify");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
