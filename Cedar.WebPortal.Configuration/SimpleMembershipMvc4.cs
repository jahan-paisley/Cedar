using System.Collections.Specialized;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Cedar.WebPortal.Service;
using WebMatrix.WebData;

namespace Cedar.WebPortal.Configuration
{
    public static class SimpleMembershipMvc4
    {
        public static readonly string EnableSimpleMembershipKey = "enableSimpleMembership";

        public static bool SimpleMembershipEnabled
        {
            get { return IsSimpleMembershipEnabled(); }
        }

        public static void Initialize()
        {
            // Modify the settings below as appropriate for your application
//            WebSecurity.InitializeDatabaseConnection(connectionStringName: "CedarContext", userTableName: "Users",
//                                                     userIdColumn: "ID", userNameColumn: "Username",
//                                                     autoCreateTables: true);

            // Comment the line above and uncomment these lines to use the IWebSecurityService abstraction
            var webSecurityService = DependencyResolver.Current.GetService<IWebSecurityService>();
            webSecurityService.InitializeDatabaseConnection(connectionStringName: "CedarContext", userTableName: "Users", userIdColumn: "ID", userNameColumn: "Username", autoCreateTables: true);
        }

        public static void Start()
        {
            if (SimpleMembershipEnabled)
            {
                MembershipProvider provider = Membership.Providers["AspNetSqlMembershipProvider"];
                if (provider != null)
                {
                    MembershipProvider currentDefault = provider;
                    SimpleMembershipProvider provider2 =
                        CreateDefaultSimpleMembershipProvider("AspNetSqlMembershipProvider", currentDefault);
                    Membership.Providers.Remove("AspNetSqlMembershipProvider");
                    Membership.Providers.Add(provider2);
                }
                Roles.Enabled = true;
                RoleProvider provider3 = Roles.Providers["AspNetSqlRoleProvider"];
                if (provider3 != null)
                {
                    RoleProvider provider6 = provider3;
                    SimpleRoleProvider provider4 = CreateDefaultSimpleRoleProvider("AspNetSqlRoleProvider", provider6);
                    Roles.Providers.Remove("AspNetSqlRoleProvider");
                    Roles.Providers.Add(provider4);
                }
            }
        }

        #region : Private Methods :

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

        #endregion
    }
}