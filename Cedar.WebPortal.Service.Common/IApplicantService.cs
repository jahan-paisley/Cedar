using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NPOI.HSSF.Record.Formula.Functions;

namespace Cedar.WebPortal.Service.Common
{
    using Cedar.WebPortal.Domain;

    public interface IApplicantService: IServiceBase<Applicant>
    {
        string CreateApplicant(Applicant Applicant);
        string GenerateFollowupCode();
        void SendMail(Applicant applicant, string body);
        IEnumerable<Applicant> DynamicQuery<TValue>(TValue value, Expression<Func<Applicant, bool>> predicate);
    }
}