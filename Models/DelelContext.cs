using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DelelContext : IdentityDbContext<AppUser>
    {
        //not add DbSet AppUser

    }
}
