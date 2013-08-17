namespace Cedar.WebPortal.Common
{
    public static class RegexConsts
    {
        #region Constants and Fields

        public const string CellNo = @"^09[0-9]{9}";

        public const string TelNo = @"^[0-9]{7,8}$";

        public const string TelCode = @"^[0-9]{3,4}$";

        public const string TelNoWithTelCode = @"^0[0-9]{9,10}$"; 
        
        public const string PostalCode=@"^[0-9]{10}$";

        public const string NationalNo = @"^[0-9]{10}$";

        public const string Digits = @"^\d+$";

        #endregion
    }
}