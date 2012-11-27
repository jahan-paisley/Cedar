using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Data.Infrastructure;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Data.Common;

    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}