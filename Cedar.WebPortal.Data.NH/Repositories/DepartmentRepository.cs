using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ICedarContext cedarContext)
            : base(cedarContext)
        {
        }
    }
}