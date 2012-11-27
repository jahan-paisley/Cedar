using Cedar.WebPortal.Domain;
using Xunit;
using NHibernate.Linq;
using System.Linq;

namespace Cedar.WebPortal.Data.Test
{
    public class Automapping_Test
    {
        // Set the correct absolute path before running
        [Fact]
        public static void Mapping_Test()
        {
            //var buildSessionFactory = MyAutoMapper.BuildSessionFactory();
            //var openSession = buildSessionFactory.OpenSession();
            //var distributor = new Distributor();
            ////distributor.Locations = openSession.Query<Location>().ToList();
            //var save = openSession.Save(distributor);
            //openSession.Flush();
            //var openSession1 = buildSessionFactory.OpenSession();
            //var load = openSession.Load<Distributor>(save);
            //Assert.True(load.Locations.Count == distributor.Locations.Count);
        } 
    }
}