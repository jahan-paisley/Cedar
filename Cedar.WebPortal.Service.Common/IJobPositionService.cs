namespace Cedar.WebPortal.Service.Common
{
    using System;
    using System.Collections.Generic;

    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Entities;

    public interface IJobPositionService
    {
        #region Public Methods

        void CreateJobPosition(JobPosition jobPosition);

        void DeleteJobPosition(Guid id);

        IEnumerable<JobPosition> GetAll();

        JobPosition GetJobPosition(Guid id);
        JobPosition GetLastJobPosition();

        void SaveJobPosition();
        #endregion
    }
}