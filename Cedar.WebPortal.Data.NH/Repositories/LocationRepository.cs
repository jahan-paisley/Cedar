namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}