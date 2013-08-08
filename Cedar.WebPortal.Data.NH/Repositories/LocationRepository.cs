using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(ICedarContext cedarContext) : base(cedarContext)
        {
        }
    }
}