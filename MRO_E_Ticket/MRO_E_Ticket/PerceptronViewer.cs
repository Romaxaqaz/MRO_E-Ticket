using ClassLibrary1.Serializer;
using HtmlGenerators;
using PerceptronLib;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRO_E_Ticket
{
    public partial class PerceptronViewer : Form
    {
        private readonly string PathObjectSerializer = "PerceptronObject.bin";
        private Perceptron per;
        private LambdaArray lform = new LambdaArray();
        private bool formOpen = true;
        private string[] AllFiles;

        public PerceptronViewer()
        {
            InitializeComponent();
            lform.FormClosing += Lform_FormClosing;
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            Perceptron yourObjectFromFile = objSerializer.GetSerializedObject(PathObjectSerializer);
            if (yourObjectFromFile != null)
            {
                per = yourObjectFromFile;
            }
            else
            {
                per = new Perceptron(6400, 3200);
            }
            Load += PerceptronViewer_Load;
        }

        private void Lform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                lform.Hide();
            }
        }

        private void PerceptronViewer_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            HtmlTable table = new HtmlTable();
            string html = table.GenerateHtml();         
        }

        private void openCollectionImageToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            string ImageFolderPath = string.Empty;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                ImageFolderPath = FBD.SelectedPath;
            }
            AllFiles = Directory.GetFiles(ImageFolderPath);
            int x = 0;
            imageList1.ImageSize = new Size(64, 64);
            foreach (string file in AllFiles)
            {
                imageList1.Images.Add(Image.FromFile(file));
                listViewImageCollection.Items.Add(file, x++);
                string newFilePath = Path.GetFileName(file);
            }
            listViewImageCollection.LargeImageList = imageList1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          var s = per.InputsImageForPerseptron("C:\\Users\\romax\\Desktop\\Image\\one.bmp");
        }

        private void listViewImageCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewImageCollection.SelectedItems)
            {
                if (WithoutAanswerRadioButton.Checked)
                {
                    FromAnswerRadioButton.Checked = false;
                    formOpen = true;
                    NumberNameLabel.Text = per.InputsImageForPerseptron(item.Text);
                }
                if(FromAnswerRadioButton.Checked)
                {
                    WithoutAanswerRadioButton.Checked = false;
                    formOpen = false;
                    NumberNameLabel.Text = per.InputsImageForPerseptronFromAnswer(item.Text);
                }
            }
        }

        private  void learningPerseptronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerseptronProgressBar.Maximum = AllFiles.Length;
            int counter = 0;
            foreach (string file in AllFiles)
            {
                string newFilePath = Path.GetFileName(file);
                per.LearningPerseptron(file, newFilePath);
                PerseptronProgressBar.Value = counter++;
            }
            per.EndLearning();
            SavePerceptron();
            PerseptronProgressBar.Value = 0;
            PerseptronStatusLabel.Text = "Learning"; 
        }

        private void lambdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            per.CombineArrays();
            PerseptronProgressBar.Maximum = AllFiles.Length;
            int counter = 0;
            foreach (string file in AllFiles)
            {
                var name = per.InputsImageForPerseptronFromAnswer(file);
                if (file.Contains(name.ToLower()) != true)
                {
                    string newFilePath = Path.GetFileName(file);
                    per.LearningPerseptronFromAnswer(file, newFilePath);
                }
            }
            SavePerceptron();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (formOpen)
            {
                lform.SetText(per.dictionaryLambdaElement, "Withoutn answer");
                lform.ShowArray();
                lform.Show();
            }
            else
            {
                lform.SetText(per.dictionaryLambdaElementAnswer, "From answer");
                lform.ShowArray();
                lform.Show();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            formOpen = false;
        }

        private void WithoutAanswerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            formOpen = true;
        }

        private void SavePerceptron()
        {
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            objSerializer.SaveSerializedObject(per, PathObjectSerializer);
        }
    }
}
