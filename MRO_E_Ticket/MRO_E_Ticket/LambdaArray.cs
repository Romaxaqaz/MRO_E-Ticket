using ClassLibrary1.Enum;
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

namespace MRO_E_Ticket
{
    public partial class LambdaArray : Form
    {
        private Perceptron myPerceptron;
        Dictionary<ClassName, int[]> dictionaryLambdaElement;
        public LambdaArray()
        {
            InitializeComponent();
            
        }
        public void SetText(Dictionary<ClassName, int[]> dictionary, string text)
        {
            dictionaryLambdaElement = dictionary;
            textBox1.Text = text;
        }

        public void ShowArray()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            var length = 3200;
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Columns[i].FillWeight = 1;
                dataGridView1.Columns[i].Width = 25;
            }
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(i.ToString(), i.ToString());
                dataGridView1.Rows[i].Height = 25;
            }

            foreach (var item in dictionaryLambdaElement)
            {
                for (int i = 0; i < length; i++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = item.Value[i].ToString();
                }
                j++;
            }
        }
    }
}
