using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MRO_E_Ticket.Domain;
using MRO_E_Ticket.Model;
using System.Drawing.Imaging;
using System.ComponentModel;
using ClassLibrary1.Serializer;
using PerceptronLib;
using NearestNeighbor;

namespace MRO_E_Ticket
{
    public partial class MainForm : Form
    {
        private SkeletonizationImageLTRB skelet = new SkeletonizationImageLTRB();
        private Domain.ImageConverter imageConverter = new Domain.ImageConverter();
        private List<ParametersForGistogram> mainList = new List<ParametersForGistogram>();
        private List<ParametersForGistogram> DividedImageList;
        private TransformationForTheHistogram transformation = new TransformationForTheHistogram();
        private List<ImageCollection> numberImageCollection = new List<ImageCollection>();
        private readonly string PathObjectSerializer = "PerceptronObject.bin";
        private Perceptron per;
        private LambdaArray lamArrayForm = new LambdaArray();
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
            lamArrayForm.FormClosing += LamArrayForm_FormClosing;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            Perceptron yourObjectFromFile = objSerializer.GetSerializedObject(PathObjectSerializer);
            if (yourObjectFromFile != null)
            {
                per = yourObjectFromFile;
            }
            else
            {
                MessageBox.Show("Perceptron not trained");
            }
        }

        private void LamArrayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                lamArrayForm.Hide();
            }
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
                    else
                    {
                        grayBitmap = OpenImage();
                        GrayScalePictureBox.Image = grayBitmap;
                    }

                    break;
                #endregion
                case 2:
                    #region Binarization image
                    ThresholdValue();
                    if (grayBitmap != null)
                    {
                        imageConverter.Progress += ImageConverter_Progress;
                        Bitmap binarizationImage = imageConverter.BinarizationThresholdMethodGetBitmap(grayBitmap);
                        binary = binarizationImage;
                        //rotate image
                        Bitmap afterRotete = rotateBitmapImage.RotateBitmap(binary, GetAngleRotate());
                        binary = afterRotete;
                        BinarizationPictureBox.Image = binary;
                        var resultGisto = transformation.Parameters(imageConverter.BinarizationThresholdMethodGetArray(binary));
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
                    ImageRecognitionPictureBox1.Image = finishImageRecognition;
                    DividedIntoImageButton.Enabled = true;
                    binary = null;
                    grayBitmap = null;
                    numberImageCollection.Clear();
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
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            Perceptron yourObjectFromFile = objSerializer.GetSerializedObject(PathObjectSerializer);
            if (yourObjectFromFile != null)
            {
                per = yourObjectFromFile;
            }
            else
            {
                MessageBox.Show("Perceptron not trained");
            }
            Segmentation segment = new Segmentation(null, null);
            numberImageCollection = segment.GetCollectionofImage(DividedImageList, DividedImage);
            ImageFormat format = ImageFormat.Bmp;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int x = 0;
                DividedimageList1.ImageSize = new Size(50, 50);
                foreach (var item in numberImageCollection)
                {
                    item.bitmap.Save(saveFileDialog.FileName + item.Name + ".bmp", format);
                    DividedimageList1.Images.Add(Image.FromFile(saveFileDialog.FileName + item.Name + ".bmp"));
                    DividedListView.Items.Add("image", x++);
                }
                DividedListView.LargeImageList = DividedimageList1;
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
            if (ExpansionCheckBox.Checked || ErosionCheckBox.Checked || SceletizationCheckBox1.Checked)
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                ImageFormat format = ImageFormat.Bmp;
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ExpansionCheckBox.Checked)
                    {
                        foreach (var item in ExpansionAndErosion.GetResultImageAfterExpansion(numberImageCollection, "Ex"))
                        {
                            item.bitmap.Save(saveFileDialog.FileName + item.Name + ".bmp", format);
                        }
                    }
                    if (ErosionCheckBox.Checked)
                    {
                        foreach (var item in ExpansionAndErosion.GetResultImageAfterErosion(numberImageCollection, "Er"))
                        {
                            item.bitmap.Save(saveFileDialog.FileName + item.Name + ".bmp", format);
                        }
                    }
                    if (SceletizationCheckBox1.Checked)
                    {
                        foreach (var item in numberImageCollection)
                        {
                            skelet.SkeletizationRun(item.bitmap).Save(saveFileDialog.FileName + item.Name + "_skelet.bmp", format);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Not Set filtering method");
            }

        }

        private void perceptronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerceptronViewer view = new PerceptronViewer();
            view.Show();
        }
        //open skelerization form
        private void skeletizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkeletonizationForm skel = new SkeletonizationForm();
            skel.Show();
        }
        //open individual image in collection
        private void DividedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in DividedListView.SelectedItems)
            {
                var listItem = numberImageCollection[item.Index];
                ImageViewer imageViewerForm = new ImageViewer(listItem.Name + ".bmp");
                imageViewerForm.Show();
            }
        }
        //get angle rotate image
        private float GetAngleRotate()
        {
            var angle = imageConverter.GetAngleImage(binary);
            string stringVal = angle.ToString().Replace(".", ",");
            float angleFloat = (float)Convert.ToDouble(stringVal);
            return angleFloat;
        }
        //event link clicked
        private void Save_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            switch (link.Name)
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
        //set thresold binarization
        private void ThresholdValue()
        {
            if (MethodBinarizationtoolStripComboBox1.SelectedIndex.ToString() == "-1")
            {
                imageConverter.BinarizationThreshold = 120;
            }
            else
            {
                if (toolStripTextBox1.Text != "")
                {
                    imageConverter.BinarizationThreshold = int.Parse(toolStripTextBox1.Text);
                }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        //activate toolStripTextbox
        private void MethodBinarizationtoolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MethodBinarizationtoolStripComboBox1.SelectedIndex == 1)
            {
                toolStripTextBox1.Enabled = true;
            }
            else
            {
                toolStripTextBox1.Enabled = false;
            }
        }
        //recpgnize image
        private void RecongnizeButton_Click(object sender, EventArgs e)
        {
            if (numberImageCollection != null)
            {
                ResultLable.Text = "";
                foreach (var item in numberImageCollection)
                {
                    ResultLable.Text = ResultLable.Text + NumbersOfString(per.InputsImageForPerseptron(item.bitmap));
                    per.LearningPerseptron("", per.InputsImageForPerseptron(item.bitmap), item.bitmap);
                }
                per.EndLearning();
                SavePerceptron();
                lamArrayForm.SetText(per.dictionaryLambdaElement, "Compleate");
                lamArrayForm.ShowArray();
                lamArrayForm.Refresh();
            }
            else
            {
                MessageBox.Show("Collection image empty");
            }

        }
        //get number of numberName
        private string NumbersOfString(string numbername)
        {
            string result = numbername;
            switch (result)
            {
                case "Null": result = "0"; break;
                case "One": result = "1"; break;
                case "Two": result = "2"; break;
                case "Three": result = "3"; break;
                case "Four": result = "4"; break;
                case "Five": result = "5"; break;
                case "Six": result = "6"; break;
                case "Seven": result = "7"; break;
                case "Eight": result = "8"; break;
                case "Nine": result = "9"; break;
                default: result = "-"; break;
            }
            return result;
        }

        private void nearestNeighborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeighborForm neighBor = new NeighborForm();
            neighBor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numberImageCollection != null)
            {
                NeighbLable.Text = "";
                Neighbor neir = new Neighbor();
                ObjectSerializer<Neighbor> objSerializer = new ObjectSerializer<Neighbor>();
                Neighbor yourObjectFromFile = objSerializer.GetSerializedObject("Neighbor.bin");
                if (yourObjectFromFile != null)
                {
                    neir = yourObjectFromFile;
                }
                else
                {
                    MessageBox.Show("Neighbor not trained");
                }
                foreach (var item in numberImageCollection)
                {
                    NeighbLable.Text = NeighbLable.Text + neir.NameClass(item.bitmap);
                }
            }
            else
            {
                MessageBox.Show("Collection image empty");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lamArrayForm.SetText(per.dictionaryLambdaElement, "Open learning");
            lamArrayForm.ShowArray();
            lamArrayForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void SavePerceptron()
        {
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            objSerializer.SaveSerializedObject(per, PathObjectSerializer);
        }

        private void ValueNumberTrue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PerceptronFromAnswer_Click(object sender, EventArgs e)
        {
            if (numberImageCollection != null)
            {
                ResultLable.Text = "";
                ResultPerceptronFromAAnswer.Text = "";
                foreach (var item in numberImageCollection)
                {
                    ResultPerceptronFromAAnswer.Text = ResultPerceptronFromAAnswer.Text + NumbersOfString(per.InputsImageForPerseptronFromAnswer(item.bitmap));
                    //per.LearningPerseptronFromAnswer("", per.InputsImageForPerseptronFromAnswer(item.bitmap), item.bitmap);
                }
                // per.EndLearning();
                //SavePerceptron();
                lamArrayForm.SetText(per.dictionaryLambdaElement, "Lambda array perceptron without answer");
                lamArrayForm.ShowArray();
                lamArrayForm.Refresh();
            }
            else
            {
                MessageBox.Show("Collection image empty");
            }
        }

        private void LambdaArrayFromAnswer_Click(object sender, EventArgs e)
        {
            lamArrayForm.SetText(per.dictionaryLambdaElementAnswer, "Lambda array perceptron from answer");
            lamArrayForm.ShowArray();
            lamArrayForm.Show();
        }
    }

    //class for notification
}
