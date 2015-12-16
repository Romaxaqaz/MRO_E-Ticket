using ClassLibrary1.Enum;
using HtmlGenerators;
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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();

        }

        internal void setData(Dictionary<ClassName, int[]> dictionaryLambdaElement)
        {
            foreach (var item in dictionaryLambdaElement)
            {
                for (int i = 0; i < item.Value.Length; i++)
                {

                }
            }
        }
    }
}
