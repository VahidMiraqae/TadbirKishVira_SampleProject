using System.Net;

namespace SampleProject.Web.DTOs.Common
{
    public class ErrorResponse
    { 
        public ErrorResponse()
        {
            Status = HttpStatusCode.InternalServerError.ToString();
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public string Status { get; set; }
        public int StatusCode { get; set; } 
    }
}
