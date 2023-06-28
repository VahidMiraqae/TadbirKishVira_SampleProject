using Microsoft.AspNetCore.Mvc;
using SampleProject.Core;

namespace SampleProject.Web.Controllers
{
    public partial class InsuranceController : ControllerBase
    {
        private bool TryGetCoverageTypes(out IDictionary<int, CoverageType> coverageTypes)
        {
            coverageTypes = new Dictionary<int, CoverageType>();
            try
            {
                coverageTypes = _insuranceService.GetCoverageTypes();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
