namespace Cedar.WebPortal.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Cedar.WebPortal.Common.Resources;

    public class CollectionMinLenghAttribute : ValidationAttribute
    {
        #region Constants and Fields

        private readonly int _minElements;

        #endregion

        #region Constructors and Destructors

        public CollectionMinLenghAttribute(int minElements)
        {
            this._minElements = minElements;
        }

        #endregion

        #region Public Methods

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            return new[]
                {
                    
                    new ModelClientValidationRule
                        { ValidationType = "minlist", ErrorMessage = ValidationResource.minlist }
                };
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count >= this._minElements;
            }
            return false;
        }

        #endregion
    }
}