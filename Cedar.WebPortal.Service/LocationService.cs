using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Service
{
    using Cedar.WebPortal.Data;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.Service.Infrastructure;

    public class LocationService : ServiceBase<Location, ILocationRepository>, ILocationService
    {
        public LocationService(ILocationRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}