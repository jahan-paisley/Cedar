using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Data.Infrastructure;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;

    public class JobPositionRepository : RepositoryBase<JobPosition>,IJobPositionRepository
    {
        public JobPositionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}