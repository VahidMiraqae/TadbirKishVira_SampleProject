namespace SampleProject.Core
{
    public class RequestCoverage
    {
        public RequestCoverage()
        {
            Request = new Request(); 
        }
        public int Id { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int CoverageTypeId { get; set; }
        public int Capital { get; set; }
    }
}