using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cedar.WebPortal.Common
{
    using System;

    using Cedar.WebPortal.Common.Resources;

    public class IsNationalNo : RequiredAttribute, IClientValidatable
    {
        #region IClientValidatable Members

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            return new[]
                       {
                           new ModelClientValidationRule
                               {
                                   ValidationType = "isnationalno",
                                   ErrorMessage =  ValidationResource.ResourceManager.GetString("isnationalno")
                               }
                       };
        }

        #endregion

        public override bool IsValid(object arg)
        {
            if (arg == null)
            {
                return false;
            }
            string value = arg.ToString();
            long result;
            for (int i = value.Length; i < 10 && value.Length >= 8; i++)
            {
                value = "0" + value;
            }
            if (Int64.TryParse(value, out result))
            {
                if (value.Length == 10)
                {
                    if (value == "1111111111" || value == "0000000000" || value == "2222222222" || value == "3333333333" || value == "4444444444" || value == "5555555555" || value == "7777777777" || value == "8888888888" || value == "9999999999")
                        return false;
                    else if (value[0] == '0' && value[1] == '0' && value[2] == '0' && value[3] == '0' && value[4] == '0'
                        && value[5] == '0' && value[6] == '0')
                        return false;
                    else
                    {
                        int c = value[9] - 48;
                        int n = (value[0] - 48) * 10 + (value[1] - 48) * 9 + (value[2] - 48) * 8 + (value[3] - 48) * 7 + (value[4] - 48) * 6 + (value[5] - 48) * 5 + (value[6] - 48) * 4 + (value[7] - 48) * 3 + (value[8] - 48) * 2;
                        int r = n - Convert.ToInt32(n / 11) * 11;
                        if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r))
                            return true;
                        else
                            return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;

        }

    }
}