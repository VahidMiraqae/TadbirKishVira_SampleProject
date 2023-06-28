using SampleProject.Core;
using SampleProject.Infrastructure.Data;

namespace SampleProject.Application
{
    public class InsuranceService : IInsuranceService
    {
        private AppDbContext _db;

        public InsuranceService(AppDbContext db)
        {
            _db = db;
        }

        public IDictionary<int, CoverageType> GetCoverageTypes()
        {
            return _db.CoverageTypes.ToDictionary(aa => aa.Id, aa => aa);
        }

        public Request ProcessRequest(Request request, IDictionary<int, CoverageType> dic)
        { 
            foreach (var item in request.Coverages)
            {
                item.Request = request;
                item.RequestId = request.Id;
            }
            request.CalcualteInsurance(dic);

            _db.Requests.Add(request);
            _db.SaveChanges();

            return request;
        }
    }
}