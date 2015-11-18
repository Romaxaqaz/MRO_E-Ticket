namespace HtmlGenerators
{
    public class HtmlTableColumn
    {
        public int Width { get; set; }
        public string Header { get; set; }

        public HtmlTableColumn() { }

        public HtmlTableColumn(string header, int width)
        {
            this.Width = width;
            this.Header = header;
        }
    }
}
