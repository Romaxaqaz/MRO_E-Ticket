using PerceptronLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlGenerators;
using PerceptronLib.PerceptronArray;
using System.IO;

namespace MRO_E_Ticket
{
    public partial class PerceptronViewer : Form
    {
        public PerceptronViewer()
        {
            InitializeComponent();
            ParamsPerceptron.Sensors = 2500;
            ParamsPerceptron.AJElement = 160;
            ParamsPerceptron.StaticPerceptronArray = StaticPerceptronArray.GetArrayPerceprton();
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            HtmlTable table = new HtmlTable();
            table.CopyMatrix(ParamsPerceptron.StaticPerceptronArray);
            string html = table.GenerateHtml();
            webBrowser1.DocumentText = html;
        }

        private void openCollectionImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ImageFolderPath = string.Empty;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                ImageFolderPath = FBD.SelectedPath;
            }
            // получаем все файлы
            string[] files = Directory.GetFiles(ImageFolderPath);
            // перебор полученных файлов
            int x = 0;
            imageList1.ImageSize = new Size(64, 64);
            foreach (string file in files)
            {
                imageList1.Images.Add(Image.FromFile(file));
                listViewImageCollection.Items.Add(file, x++);
            }
            listViewImageCollection.LargeImageList = imageList1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listViewImageCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Perceptron per = new Perceptron();
            foreach (ListViewItem item in listViewImageCollection.SelectedItems)
            {
                per.OpenImage(item.Text.ToString());
            }
        }
    }
}
