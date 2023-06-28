using System.Runtime.InteropServices;

namespace SampleProject.Web.DTOs
{
    public class RequestDto
    {
        public string Title { get; set; }
        public List<CoverageRequestDto> Coverages { get; set; } 
    }
}
