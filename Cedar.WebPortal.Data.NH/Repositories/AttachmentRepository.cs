namespace Cedar.WebPortal.Data
{
    using System;
    using System.Linq;

    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class AttachmentRepository : RepositoryBase<Attachment>, IAttachmentRepository
    {
        #region Constructors and Destructors

        public AttachmentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        #region Implemented Interfaces

        #region IAttachmentRepository

        public Attachment GetAttachment(Guid id, FileType fileType)
        {
            string s = fileType.ToString();
            Attachment firstOrDefault = null;

            IQueryable<Attachment> @where = this.DataContext.Query<Attachment>().Where(o => o.AttachmentId == id);
            firstOrDefault = @where.FirstOrDefault();
            return firstOrDefault;
        }



        #endregion

        #endregion
    }
}