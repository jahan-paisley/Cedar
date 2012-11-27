using Cedar.WebPortal.Service.Common;

namespace Cedar.WebPortal.Service.Test
{
    using System.Web.Security;
    using Cedar.WebPortal.Domain;
    using Xunit;

    public class GalleryService_Test
    {
        private IGalleryService galleryService;
        private MembershipProvider MembershipService { get; set; }

        private RoleProvider RoleService { get; set; }

        [Fact]
        public void Add_Gallery_Test()
        {
            var gallery = new Gallery()
            {
                
            };
           
            this.galleryService.Add(gallery);

            //            var find = (this.distributorService.Get(o => o.DistributorId == distributor.DistributorId));
            //            Assert.True(find.IsNotNull());
            //            Assert.True(find.DistributorOffices.Count == 2);
        }

      

    }
}