namespace Cedar.WebPortal.Integration.Test
{
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Component;

    public class ControllerTest
    {
        #region Public Methods

        //[Fact]
        //public void ApplicantController_Create_Test()
        //{
        //    AutoMapperConfiguration.Configure();
        //    Applicant applicant = this.FakeApplicant();
        //    ApplicantViewModel applicantVM = new ApplicantViewModel(){IAgree = true};
        //    applicantVM=Mapper.Map(applicant, applicantVM);

        //    var controller = TestHelper.kernel.Get<ApplicantController>();
        //    ActionResult actionResult = controller.Create(applicantVM);
        //    Assert.True(actionResult != null);
        //}

        //[Fact]
        //public void TenderApplicationController_Create_Test()
        //{
        //    var controller = TestHelper.kernel.Get<TenderApplicationController>();
        //    ViewResult actionResult = controller.ListTender();
        //    Assert.True(actionResult != null);
        //}

        #endregion

        #region Methods

        private Applicant FakeApplicant()
        {
            var applicant = new Applicant();
            applicant.FirstName = "alaik";
            var educationInfo = new EducationInfo
                {   College = "asdasd", Level = EducationLevel.Bachelor };
            var educationInfo2 = new EducationInfo
                { College = "12312", Level = EducationLevel.Master };
            applicant.EducationInfos.Add(educationInfo);
            applicant.EducationInfos.Add(educationInfo2);
            return applicant;
        }

     

        #endregion
    }
}