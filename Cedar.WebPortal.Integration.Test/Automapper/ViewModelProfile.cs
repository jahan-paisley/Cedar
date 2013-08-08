using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.Integration.Test
{
    using System;

    using AutoMapper;

    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.WebMVC4.Helpers;
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

            #region Applciant And ApplicantViewModel Map

            this.CreateMap<ApplicantViewModel, Applicant>().IgnoreAllNonExisting();
            this.CreateMap<Applicant, ApplicantViewModel>()
                .ForMember(x => x.IAgree, y => y.Ignore()).IgnoreAllNonExisting();

            #endregion

            #region JobPosition and JobPositionViewModel Map

            //this.CreateMap<JobPositionViewModel, JobPosition>();

            #endregion

            #region News

            this.CreateMap<News, NewsViewModel>();
            this.CreateMap<NewsViewModel, News>();
             
            #endregion

            base.Configure();
            Mapper.AssertConfigurationIsValid();
        }

        #endregion
    }
}