using Cedar.WebPortal.Domain.Enums;

namespace Cedar.WebPortal.Data.Common
{
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Entities;
    using System;

    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Attachment GetAttachment(Guid id, FileType type);

    }
}