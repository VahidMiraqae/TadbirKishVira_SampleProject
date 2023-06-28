using System.Runtime.InteropServices;

namespace SampleProject.Web.DTOs
{
    public class RequestProcessedDto
    {
        public string Title { get; set; }
        public List<CoverageRequestDto> Coverages { get; set; }
        public int Total { get; set; }
    }
}
