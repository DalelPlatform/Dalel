using Microsoft.AspNetCore.Identity;
using Models;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class AppUserRepository : BaseRepository<AppUser>
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AppUserRepository(DelelContext dbContext,
            UserManager<AppUser> _UserManager,
            SignInManager<AppUser> _signInManager) : base(dbContext)
        {
            userManager = _UserManager;
            signInManager = _signInManager;
        }

      /*  public async Task<IdentityResult> Register(AccountRegisterVM accountRegister)
        {
            //return await userManager.CreateAsync(accountRegister.ToModel(),
            //    accountRegister.Password);
            var res = await userManager.CreateAsync(accountRegister.ToModel(),
                accountRegister.Password);
            if (res.Succeeded)
            {
                Account account = await userManager.FindByNameAsync(accountRegister.UserName);

                res = await userManager.AddToRoleAsync(account, accountRegister.Role);

                if (accountRegister.Role == "Teacher")
                {
                    //
                }
                else if (accountRegister.Role == "Student")
                {
                    //
                }
            }
            return res;

        }
      */
     /*   public async Task<SignInResult> Login(AccountLoginVM accountLogin)
        {
            var User = await userManager.FindByEmailAsync(accountLogin.UserNameOrEmail);

            if (User != null)
            {
                return await signInManager.PasswordSignInAsync(User, accountLogin.Password, true, true);
            }
            else
            {
                return await signInManager.PasswordSignInAsync(accountLogin.UserNameOrEmail, accountLogin.Password, true, true);
            }
        }
     */
    }
}
