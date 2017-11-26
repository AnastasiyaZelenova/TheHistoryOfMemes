namespace ClassLibraryOfMemes
{
    public class Statistics
    {
        private uint year;

        public uint Year
        {
            get { return year; }
            set
            {
                if (value < Meme.Year)
                    year = Meme.Year;
                year = value;
            }
        }

        public Meme Meme { get; set; }
        public uint Rating { get; set; }
    }
}