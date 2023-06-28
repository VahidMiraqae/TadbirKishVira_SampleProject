using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SampleProject.Web.DTOs
{
    public class ValidationViolationDto
    {
        public ValidationViolationDto(ValidationFailure aa)
        {
            Message = aa.ErrorMessage;
            Property = aa.PropertyName;
        }

        public string Message { get; set; }
        public string Property { get; set; }
    }
}
