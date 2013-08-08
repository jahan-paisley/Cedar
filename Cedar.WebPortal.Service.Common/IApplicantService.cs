using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Cedar.WebPortal.Service.Common
{
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Entities;

    public interface IApplicantService: IServiceBase<Applicant>
    {
        string CreateApplicant(Applicant Applicant);
        string GenerateFollowupCode();
        void SendMail(Applicant applicant, string body);
        IEnumerable<Applicant> DynamicQuery<TValue>(TValue value, Expression<Func<Applicant, bool>> predicate);
    }
}