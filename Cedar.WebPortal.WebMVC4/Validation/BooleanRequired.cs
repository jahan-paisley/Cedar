namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Cedar.WebPortal.Common.Resources;

    public class BooleanRequired : RequiredAttribute, System.Web.Mvc.IClientValidatable
    {
        #region Public Methods

        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }

        #endregion

        #region Implemented Interfaces

        #region IClientValidatable

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            System.Web.Mvc.ModelMetadata metadata, System.Web.Mvc.ControllerContext context)
        {
            return new[]
                {
                    new ModelClientValidationRule
                        { ValidationType = "checkboxrequired", ErrorMessage = ValidationResource.checkboxrequired }
                };
        }

        #endregion

        #endregion
    }
}