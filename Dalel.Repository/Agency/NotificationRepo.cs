using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Notification;

namespace Dalel.Repository.Agency
{
    public class NotificationRepo : BaseRepository<Notification>
    {
        public NotificationRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
    }
}
