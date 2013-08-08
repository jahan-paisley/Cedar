using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using Cedar.WebPortal.Domain.Enums;

    public class UserModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            Guid UserID =
                (Guid)Membership.GetUser().ProviderUserKey;

            return UserID;
        }
    }
}