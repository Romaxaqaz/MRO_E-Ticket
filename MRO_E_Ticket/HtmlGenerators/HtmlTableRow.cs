using System.Collections.Generic;

namespace HtmlGenerators
{
    public class HtmlTableRow
    {
        private List<string> columns;

        public IEnumerable<string> ColumnsData { get { return columns; } }

        public HtmlTableRow()
        {
            columns = new List<string>();
        }

        public HtmlTableRow(params string[] data) : this()
        {
            foreach (var item in data)
            {
                columns.Add(item);
            }
        }

        public void CopyArray<T>(T[] data)
        {
            foreach (var item in data)
            {
                columns.Add(item.ToString());
            }
        }

        public string this[int index]
        {
            get { return columns[index]; }
            set { columns[index] = value; }
        }

        public void AddColumn(string item)
        {
            columns.Add(item);
        }
    }
}
