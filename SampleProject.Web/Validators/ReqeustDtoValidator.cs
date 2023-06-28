using FluentValidation;
using SampleProject.Core;
using SampleProject.Web.DTOs;

namespace SampleProject.Web.Validators
{
    public class ReqeustDtoValidator : AbstractValidator<RequestDto>
    {
        public ReqeustDtoValidator(IDictionary<int, CoverageType> coverageTypes)
        {
            RuleFor(a => a.Title).NotNull().NotEmpty();
            RuleFor(aa => aa.Coverages).NotNull().NotEmpty().Must(aa =>
            {
                return aa.Count >= 1 && aa.Count <= coverageTypes.Count;
            }).WithMessage($"request must contain at least 1 coverage. max number of couverages is {coverageTypes.Count}");
            RuleForEach(aa => aa.Coverages).SetValidator(new CoverageReqeustDtoValidator(coverageTypes));
            RuleFor(aa => aa.Coverages).Must(aa => aa.Count == aa.Select(bb => bb.CoverageTypeId).Distinct().Count()).WithMessage("Each coverage type must be used once.");
        }
    }
}
