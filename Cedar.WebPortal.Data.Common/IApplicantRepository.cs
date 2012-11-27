namespace Cedar.WebPortal.Data.Common
{
    using Cedar.WebPortal.Domain;

    public interface IApplicantRepository : IRepository<Applicant>
    {
        string GenerateFollowupCode();
    }
}