using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cedar.WebPortal.Domain.Component;

namespace Cedar.WebPortal.Data.Test
{
    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    using Xunit;

    public class Location_Test
    {
        #region Public Methods

        public static IList<Location> FakeLocation()
        {
            var Locations =
                new Collection<Location>
                    {
                        new Location
                            {LocationId = Guid.Parse("5518DD00-DACC-4E0E-97CC-2AC9FF5C9EBD"), Province = "شیراز"},
                        new Location
                            {LocationId = Guid.Parse("5518DD20-DACC-4E0E-97CC-2AC9FF5C9EAD"), Province = "تهران"}
                    };
            return Locations;
        }

        [Fact]
        public void Create_Locations()
        {
            IList<Location> locations= FakeLocation();

            var factory = new NHDatabaseFactory();

            foreach (var location in locations)
            {
                factory.CedarContext.Save(location);
                factory.CedarContext.Commit();
                
            }
            foreach (var location in locations)
            {
                var find = factory.CedarContext.Get<Location>(location.LocationId);
                Assert.True(find.IsNotNull());
            }
           
        }

        #endregion
    }
}