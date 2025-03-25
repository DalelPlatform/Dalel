using Models.User;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(DelelContext context) : base(context) { }

        public IQueryable<Client> GetClientWithRequests(string clientId)
        {
            return GetList(x => x.UserId == clientId);
        }
    }
}
