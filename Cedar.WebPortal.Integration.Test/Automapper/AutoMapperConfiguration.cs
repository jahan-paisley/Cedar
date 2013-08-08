namespace Cedar.WebPortal.Integration.Test
{
    using AutoMapper;
    
    public class AutoMapperConfiguration
    {
        #region Public Methods

        public static void Configure()
        {
            Mapper.Initialize(o => o.AddProfile(new ViewModelProfile()));
        }

        #endregion
    }
}