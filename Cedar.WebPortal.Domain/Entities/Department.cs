using System;
using System.ComponentModel.DataAnnotations;
using Cedar.WebPortal.Domain.Resources;

namespace Cedar.WebPortal.Domain
{
    public class Department
    {
        #region Constructors and Destructors

        #endregion

        #region Properties

        public virtual Guid DepartmentId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string About { get; set; }

        #endregion
    }
}