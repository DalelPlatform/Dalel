using Microsoft.AspNetCore.Identity;
using Models;

namespace Dalel.Repository
{
    public class RoleRepository : BaseRepository<IdentityRole>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleRepository(DelelContext context, RoleManager<IdentityRole> roleManager)
            : base(context)
        {
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> Add(string roleName)
        {
            return await roleManager.CreateAsync(new IdentityRole { Name = roleName });
        }
    }

}
