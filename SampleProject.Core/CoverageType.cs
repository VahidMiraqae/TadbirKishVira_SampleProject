namespace SampleProject.Core
{
    public class CoverageType
    {
        public CoverageType()
        {
            Title = string.Empty;
            PersianTitle = string.Empty;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string PersianTitle { get; set; }
        public int MinCapital { get; set; }
        public int MaxCapital { get; set; }
        public double Rate { get; set; }
    }
}