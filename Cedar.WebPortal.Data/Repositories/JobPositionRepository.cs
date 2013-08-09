using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Data.Infrastructure;
using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;

    public class JobPositionRepository : RepositoryBase<JobPosition>,IJobPositionRepository
    {
        public JobPositionRepository(ICedarContext cedarContext)
            : base(cedarContext)
        {
        }
    }
}