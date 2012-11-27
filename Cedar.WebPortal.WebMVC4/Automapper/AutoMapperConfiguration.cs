namespace Cedar.WebPortal.WebMVC4.Helpers
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