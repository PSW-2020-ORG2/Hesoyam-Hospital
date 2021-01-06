namespace Documents.Util
{
    public class TextFilter
    {
        public string Text { get; set; }
        public TextmatchFilter Filter { get; set; }

        public TextFilter()
        {
        }

        public TextFilter (string text, TextmatchFilter matchFilter) 
        {
            Text = text;
            Filter = matchFilter;
        }
    }
}
