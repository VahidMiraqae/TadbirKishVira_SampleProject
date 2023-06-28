using SampleProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Application
{
    public interface IInsuranceService
    {
        Request ProcessRequest(Request request, IDictionary<int, CoverageType> dic);

        IDictionary<int, CoverageType> GetCoverageTypes();
    }
}
