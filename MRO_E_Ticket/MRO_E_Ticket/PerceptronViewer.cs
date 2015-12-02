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
        private string[] AllFiles;

        public PerceptronViewer()
        {
            InitializeComponent();
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            Perceptron yourObjectFromFile = objSerializer.GetSerializedObject(PathObjectSerializer);
            if (yourObjectFromFile != null)
            {
                per = yourObjectFromFile;
            }
            else
            {
                per = new Perceptron(2500, 1500);
            }
            Load += PerceptronViewer_Load;
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
                NumberNameLabel.Text = per.InputsImageForPerseptron(item.Text);
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
            ObjectSerializer<Perceptron> objSerializer = new ObjectSerializer<Perceptron>();
            objSerializer.SaveSerializedObject(per, PathObjectSerializer);
            PerseptronProgressBar.Value = 0;
            PerseptronStatusLabel.Text = "Learning";
          
        }

    }
}
