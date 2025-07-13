using Models;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class ChatRepository : BaseRepository<ServiceChat>
    {
        private readonly DelelContext _context;

        public ChatRepository(DelelContext context) : base(context)
        {
        }

        public ServiceChat GetOrCreateChat(string clientId, string providerId)
        {
            var chat = base.Get(p=>p.ClientId == clientId && p.ServiceProviderId  == providerId).FirstOrDefault();
            if (chat == null)
            {
                chat = new ServiceChat
                {
                    ClientId = clientId,
                    ServiceProviderId = providerId,
                    LastMessageAt = DateTime.UtcNow
                };
                base.Add(chat);
                base.Save();
            }

            return chat;
        }

        public ServiceChat GetChatById(int chatId)
        {
            return base.Get(p=>p.Id == chatId).FirstOrDefault();
        }
        public IQueryable<ServiceChat> GetChatsForUser(string userId)
        {
            return base.GetList(p=>p.ClientId==userId || p.ServiceProviderId == userId);
        }

    }

}
