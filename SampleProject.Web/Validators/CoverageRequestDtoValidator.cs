using FluentValidation;
using SampleProject.Core;
using SampleProject.Web.DTOs;

namespace SampleProject.Web.Validators
{
    public class CoverageReqeustDtoValidator : AbstractValidator<CoverageRequestDto>
    {
        public CoverageReqeustDtoValidator(IDictionary<int, CoverageType> coverageTypes)
        {
            RuleFor(aa => aa.CoverageTypeId).Must(aa =>
            {
                return coverageTypes.ContainsKey(aa);
            }).WithMessage(aa => $"input coverage type '{aa.CoverageTypeId}' is not valid");

            RuleFor(aa => aa).Must(aa =>
            {
                var ct = coverageTypes[aa.CoverageTypeId];
                return aa.Capital >= ct.MinCapital && aa.Capital <= ct.MaxCapital;
            }).When(aa =>
            {
                return coverageTypes.ContainsKey(aa.CoverageTypeId);
            }).WithMessage(aa =>
            {
                var ct = coverageTypes[aa.CoverageTypeId];
                return $"value of capital of type '{aa.CoverageTypeId}' must be between {ct.MinCapital} and {ct.MaxCapital}";
            });
        }
    }
}
