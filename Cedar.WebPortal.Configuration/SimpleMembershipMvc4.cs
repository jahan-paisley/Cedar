using System.Collections.Specialized;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Cedar.WebPortal.Service;
using WebMatrix.WebData;

namespace Cedar.WebPortal.Configuration
{
    public static class SimpleMembershipMVC4
    {
        private const string EnableSimpleMembershipKey = "enableSimpleMembership";

        private static bool SimpleMembershipEnabled
        {
            get { return IsSimpleMembershipEnabled(); }
        }

        public static void Initialize()
        {
            var webSecurityService = DependencyResolver.Current.GetService<IWebSecurityService>();
            webSecurityService.InitializeDatabaseConnection("CedarContext", "Users", "ID", "Username", true);
        }

        public static void Start()
        {
            if (SimpleMembershipEnabled)
            {
                MembershipProvider membershipProvider = Membership.Providers["AspNetSqlMembershipProvider"];
                if (membershipProvider != null)
                {
                    var simpleMembershipProvider =
                        CreateDefaultSimpleMembershipProvider("AspNetSqlMembershipProvider", membershipProvider);
                    Membership.Providers.Remove("AspNetSqlMembershipProvider");
                    Membership.Providers.Add(simpleMembershipProvider);
                }
                Roles.Enabled = true;
                var roleProvider = Roles.Providers["AspNetSqlRoleProvider"];
                if (roleProvider != null)
                {
                    var simpleRoleProvider = CreateDefaultSimpleRoleProvider("AspNetSqlRoleProvider", roleProvider);
                    Roles.Providers.Remove("AspNetSqlRoleProvider");
                    Roles.Providers.Add(simpleRoleProvider);
                }
            }
        }

        private static bool IsSimpleMembershipEnabled()
        {
            bool flag;
            string str = ConfigurationManager.AppSettings[EnableSimpleMembershipKey];
            if (!string.IsNullOrEmpty(str) && bool.TryParse(str, out flag))
            {
                return flag;
            }
            return true;
        }

        private static SimpleMembershipProvider CreateDefaultSimpleMembershipProvider(string name,
                                                                                      MembershipProvider currentDefault)
        {
            MembershipProvider previousProvider = currentDefault;
            var provider = new SimpleMembershipProvider(previousProvider);
            var config = new NameValueCollection();
            provider.Initialize(name, config);
            return provider;
        }

        private static SimpleRoleProvider CreateDefaultSimpleRoleProvider(string name, RoleProvider currentDefault)
        {
            RoleProvider previousProvider = currentDefault;
            var provider = new SimpleRoleProvider(previousProvider);
            var config = new NameValueCollection();
            provider.Initialize(name, config);
            return provider;
        }
    }
}