namespace Cedar.WebPortal.Service.Common
{
    using System;
    using System.Collections.Generic;

    using Cedar.WebPortal.Domain;

    public interface IMessageService
    {
        IEnumerable<Message> GetPublishedMessages();
        IEnumerable<Message> GetUnpublishedMessages();
        Message GetMessage(Guid id);
        void CreateMessage(Message Message);
        void DeleteMessage(Guid id);
        void SaveMessage();
    }
}