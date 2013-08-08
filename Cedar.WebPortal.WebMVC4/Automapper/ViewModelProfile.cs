namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;

    using AutoMapper;

    using Cedar.WebPortal.Domain.Entities;
    using Cedar.WebPortal.WebMVC4.ViewModel;

    public class ViewModelProfile : Profile
    {
        #region Methods

        protected override void Configure()
        {
            #region Global DateTime to Jalali Date Converter

            this.CreateMap<string, DateTime?>().ConvertUsing<DateTimeTypeConverter>();
            this.CreateMap<DateTime?, string>().ConvertUsing<DateTimeTypeConverter>();

            this.CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();
            this.CreateMap<DateTime, string>().ConvertUsing<DateTimeTypeConverter>();

            #endregion

            #region News

            this.CreateMap<News, NewsViewModel>().IgnoreAllNonExisting();
            this.CreateMap<NewsViewModel, News>().IgnoreAllNonExisting();

            #endregion

            base.Configure();

            Mapper.AssertConfigurationIsValid();
        }

        #endregion
    }
}