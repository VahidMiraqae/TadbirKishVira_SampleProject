using System.Net;

namespace SampleProject.Web.DTOs.Common
{
    public class CommonResponse
    {
        public CommonResponse()
        {
                
        }

        public static CommonResponse OkResponse(object obj)
        {
            return new CommonResponse()
            {
                Status = HttpStatusCode.OK.ToString(),
                StatusCode = (int)HttpStatusCode.OK,
                Result = obj
            };
        }

        public static CommonResponse BackRequestResponse(object obj)
        {
            return new CommonResponse()
            {
                Status = HttpStatusCode.BadRequest.ToString(),
                StatusCode = (int)HttpStatusCode.BadRequest,
                Result = new {Errors = obj}
            };
        }


        public string Status { get; set; }
        public int StatusCode { get; set; }
        public object Result { get; set; }
    }
}
