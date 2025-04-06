using Dalel.ViewModels;
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

        public async Task<IdentityResult> Register(UserRegisterVM accountRegister)
        {
            //return await userManager.CreateAsync(accountRegister.ToModel(),
            //    accountRegister.Password);
            var res = await userManager.CreateAsync(accountRegister.ToModel(),
                accountRegister.Password);
            if (res.Succeeded)
            {
                AppUser account = await userManager.FindByNameAsync(accountRegister.UserName);

                res = await userManager.AddToRoleAsync(account, accountRegister.Role);


            }
            return res;

        }
      
       public async Task<SignInResult> Login(UserLoginVM accountLogin)
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
        public async Task<AppUser> FindByUserName(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }
        public async Task<AppUser> FindByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoles(AppUser user)
        {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AsignUserToRole(AppUser user, string newrole)
        {
            return await userManager.AddToRoleAsync(user, newrole);
        }


        public async Task Signout()
        {
            await signInManager.SignOutAsync();
        }


    }
}
