using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tribality.Models;

namespace Tribality.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ISessionBuilder sessionManager): base(sessionManager){}        
    }
}