using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NearestNeighbor;
using System.IO;
using ClassLibrary1.Serializer;

namespace MRO_E_Ticket
{
    public partial class NeighborForm : Form
    {
        private Neighbor neighbor;
        private Dictionary<string, Bitmap> bitList = new Dictionary<string, Bitmap>();

        public NeighborForm()
        {
            InitializeComponent();
            ObjectSerializer<Neighbor> objSerializer = new ObjectSerializer<Neighbor>();
            Neighbor yourObjectFromFile = objSerializer.GetSerializedObject("Neighbor.bin");
            if (yourObjectFromFile != null)
            {
                neighbor = yourObjectFromFile;
            }
            else
            {
                MessageBox.Show("Not reasy");
            }
        }

        private void OpenImageStripButton1_Click(object sender, EventArgs e)
        {
            string ImageFolderPath = string.Empty;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                ImageFolderPath = FBD.SelectedPath;
            }
            var AllFiles = Directory.GetFiles(ImageFolderPath);
            int x = 0;
            imageList1.ImageSize = new Size(64, 64);
            foreach (string file in AllFiles)
            {
                imageList1.Images.Add(Image.FromFile(file));
                listViewImageCollection.Items.Add(file, x++);
                string newFilePath = Path.GetFileName(file);
                bitList.Add(newFilePath , (Bitmap)Image.FromFile(file));
            }
            listViewImageCollection.LargeImageList = imageList1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            neighbor = new Neighbor(bitList);
            ObjectSerializer<Neighbor> objSerializer = new ObjectSerializer<Neighbor>();
            objSerializer.SaveSerializedObject(neighbor, "Neighbor.bin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                var originalImage = new Bitmap(filePath);
                bitList.Add("", originalImage);
                bitList.Remove("");
                var s = neighbor.NameClass(originalImage);
                MessageBox.Show(s);
            }
        }
    }
}
