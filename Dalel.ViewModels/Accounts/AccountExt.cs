using Dalel.ViewModels.Accounts;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class AccountExt
    {
         public static AppUser ToModel(this UserRegisterVM viewmodel)
        {
            return new AppUser
            {
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,
                NationalId = viewmodel.NationalId,
                UserName = viewmodel.UserName,
                Email = viewmodel.Email,
                PhoneNumber = viewmodel.PhoneNumber,

            };
        }
        public static AppUser ToEditModel(this UpdateProfile viewmodel, AppUser user)
        {
            user.FirstName = string.IsNullOrEmpty(viewmodel.FirstName) ? user.FirstName : viewmodel.FirstName;
            user.LastName = string.IsNullOrEmpty(viewmodel.LastName) ? user.LastName : viewmodel.LastName;
            user.PhoneNumber = string.IsNullOrEmpty(viewmodel.PhoneNumber) ? user.PhoneNumber : viewmodel.PhoneNumber;
            user.ProfileImg = string.IsNullOrEmpty(viewmodel.ProfileImg) ? user.ProfileImg : viewmodel.ProfileImg;

            return user;
        }
    }
}
