namespace Cedar.WebPortal.Data.Common
{
    using Cedar.WebPortal.Domain;

    using System;

    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Attachment GetAttachment(Guid id, FileType type);

    }
}