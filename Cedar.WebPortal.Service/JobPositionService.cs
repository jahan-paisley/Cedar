namespace Cedar.WebPortal.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;

    public class JobPositionService : IJobPositionService
    {
        #region Constants and Fields

        private readonly IJobPositionRepository jobPositionRepository;

        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors and Destructors

        public JobPositionService(IJobPositionRepository jobPositionRepository, IUnitOfWork unitOfWork)
        {
            this.jobPositionRepository = jobPositionRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Implemented Interfaces

        #region IJobPositionService

        public void CreateJobPosition(JobPosition jobPosition)
        {
            this.jobPositionRepository.Add(jobPosition);
            this.unitOfWork.Commit();
        }

        public void DeleteJobPosition(Guid id)
        {
            JobPosition jobPosition = this.jobPositionRepository.GetById(id);
            this.jobPositionRepository.Delete(jobPosition);
            this.unitOfWork.Commit();
        }

        public IEnumerable<JobPosition> GetAll()
        {
            IEnumerable<JobPosition> jobPosition = this.jobPositionRepository.GetAll();
            return jobPosition;
        }

        public JobPosition GetJobPosition(Guid id)
        {
            JobPosition jobPosition = this.jobPositionRepository.GetById(id);
            return jobPosition;
        }

        public JobPosition GetLastJobPosition()
        {
            JobPosition jobPosition = this.jobPositionRepository.GetAll().LastOrDefault();
            return jobPosition;
        }

        public void SaveJobPosition()
        {
            this.unitOfWork.Commit();
        }

        #endregion

        #endregion
    }
}