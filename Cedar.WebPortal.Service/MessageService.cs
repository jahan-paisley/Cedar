using System.Collections.Generic;

using Cedar.WebPortal.Domain;

namespace Cedar.WebPortal.Service
{
    using System;

    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Service.Common;

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository MessageRepository;
        private readonly IUnitOfWork unitOfWork;
        public MessageService(IMessageRepository MessageRepository, IUnitOfWork unitOfWork)
        {
            this.MessageRepository = MessageRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IMessageervice Members

        public IEnumerable<Message> GetPublishedMessages()
        {
            var Message = this.MessageRepository.GetMany(o=> o.Published);
            return Message;
        }
        public IEnumerable<Message> GetUnpublishedMessages()
        {
            var Message = this.MessageRepository.GetMany(o=> !o.Published);
            return Message;
        }
        
        public Message GetMessage(Guid id)
        {
            var Message = this.MessageRepository.GetById(id);
            return Message;
        }

        public void CreateMessage(Message Message)
        {
            this.MessageRepository.Add(Message);
            unitOfWork.Commit();
        }

        public void DeleteMessage(Guid id)
        {
            var Message = this.MessageRepository.GetById(id);
            this.MessageRepository.Delete(Message);
            unitOfWork.Commit();
        }

        public void SaveMessage()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
