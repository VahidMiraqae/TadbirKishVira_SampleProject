namespace SampleProject.Core
{
    public class Request
    {
        public Request()
        {
            Title = string.Empty;
            Coverages = new List<RequestCoverage>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }
        public ICollection<RequestCoverage> Coverages { get; set; }

        public void CalcualteInsurance(IDictionary<int, CoverageType> dic)
        {
            Total = Convert.ToInt32(Coverages.Sum(aa => aa.Capital * dic[aa.CoverageTypeId].Rate));
        }
    }
}