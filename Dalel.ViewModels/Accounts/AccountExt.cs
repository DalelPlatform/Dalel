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
    }
}
