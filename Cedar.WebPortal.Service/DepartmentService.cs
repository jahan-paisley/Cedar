using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Service
{
    using Cedar.WebPortal.Data;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.Service.Infrastructure;

    public class DepartmentService : ServiceBase<Department, IDepartmentRepository>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}