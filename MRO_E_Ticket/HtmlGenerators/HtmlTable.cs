using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlGenerators
{
    public class HtmlTable
    {
        private List<HtmlTableColumn> columns;
        private List<HtmlTableRow> rows;
        private int border = 1;
        private string interlacedStyle = "tr:nth-child(even){{background-color: #DADADA;}}";
        private string tableStyle
        {
            get
            {
                return string.Format("table, td, tr, th {{border: {0}px solid black;border-collapse: collapse;}}", border);
            }
        }

        public IEnumerable<HtmlTableColumn> Columns { get; set; }
        public IEnumerable<HtmlTableRow> Rows { get; set; }
        public bool Interlaced { get; set; }
        public int Border
        {
            get { return border; }
            set { border = value; }
        }

        public HtmlTable()
        {
            columns = new List<HtmlTableColumn>();
            rows = new List<HtmlTableRow>();
        }

        public HtmlTableRow this[int index]
        {
            get { return rows[index]; }
            set { rows[index] = value; }
        }

        public string this[int column, int row]
        {
            get { return rows[row][column]; }
            set { rows[row][column] = value; }
        }

        public void AddColumn(string name, int width = 70)
        {
            HtmlTableColumn column = new HtmlTableColumn(name, width);
            this.AddColumn(column);
        }

        public void AddColumn(HtmlTableColumn htmlTableColumn)
        {
            if (htmlTableColumn == null)
                throw new ArgumentNullException("htmlTableColumn");

            if (columns.Any(x => x.Header.Equals(htmlTableColumn.Header)))
                throw new InvalidOperationException("The table already contains a column with such name.");

            columns.Add(htmlTableColumn);
        }

        public void AddRow(HtmlTableRow htmlTableRow)
        {
            if (htmlTableRow == null)
                throw new ArgumentNullException("htmlTableRow");

            rows.Add(htmlTableRow);
        }

        public void AddRow<T>(params T[] data)
        {
            HtmlTableRow row = new HtmlTableRow();
            row.CopyArray(data);
            this.AddRow(row);
        }

        public void CopyMatrix<T>(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                this.AddColumn(i.ToString());
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                this.AddRow(matrix[i]);
            }
        }

        public void CopyMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                this.AddColumn(i.ToString());
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                HtmlTableRow tableRow = new HtmlTableRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tableRow.AddColumn(matrix[i, j].ToString());
                }
                this.AddRow(tableRow);
            }
        }

        public string GenerateHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<style>{0}{1}</style>", tableStyle, Interlaced ? interlacedStyle : string.Empty)
                .AppendLine()
                .AppendLine("<table>")
                .AppendLine("<tr>");

            foreach (var column in columns)
            {
                sb.AppendFormat("<th width={0}>{1}</th>", column.Width, column.Header ?? string.Empty);
            }

            sb.AppendLine("</tr>");

            foreach (var row in rows)
            {
                if (row != null)
                {
                    sb.AppendLine("<tr>");
                    foreach (var data in row.ColumnsData)
                    {
                        sb.AppendFormat("<td>{0}</td>", data ?? string.Empty);
                    }
                    sb.AppendLine("</tr>");
                }
            }

            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
