using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRO_E_Ticket.Model;
using ZedGraph;

namespace MRO_E_Ticket
{
    public partial class Histogramm : Form
    {
        public Histogramm()
        {
            InitializeComponent();
            zedGraphControl1.IsShowPointValues = true;
        }

        internal void setData(List<ParametersForGistogram> list)
        {

            GraphPane pane = zedGraphControl1.GraphPane;
            int itemscount = list.Count;
            int x = 0;
            double[] values = new double[itemscount];

            foreach (var item in list)
            {
                values[x] = item.TheТumberOfPixels;
                x++;
            }

            // Создадим кривую-гистограмму
            BarItem curve = pane.AddBar("Гистограмма изображения", null, values, Color.Blue);
            // !!!
            // Установим цвет для столбцов гистограммы
            curve.Bar.Fill.Color = Color.YellowGreen;
            // Отключим градиентную заливку
            curve.Bar.Fill.Type = FillType.Solid;
            pane.BarSettings.MinClusterGap = 0.0f;
            // Сделаем границы столбцов невидимыми
            curve.Bar.Border.IsVisible = true;
            // Обновить данные об осях
            zedGraphControl1.AxisChange();
            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        private void Histogramm_Load(object sender, EventArgs e)
        {

        }
    }
}
