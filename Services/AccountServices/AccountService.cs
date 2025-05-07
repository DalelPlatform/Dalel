using Dalel.Repository;
using Dalel.ViewModels;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Services
{
    public class AccountService
    {
        AppUserRepository appUserRepository;
        ClientRepository clientRepository;
        DriverRepository driverRepository;
        HomeChefReopsitory HomeChefReopsitory;
        HotelOwnerReopsitory HotelOwnerReopsitory;
        PropertyOwnerReopsitory propertownerRepository;
        RestaurantOwnerReopsitory RestaurantOwnerReopsitory;
        ServiceProviderRepository serviceProviderRepository;
        TravelAgencyOwnerReopsitory TravelAgencyOwnerReopsitory;
        IConfiguration appSettingConfiguration;

        public AccountService(
            AppUserRepository appUserRepository,
            ClientRepository clientRepository,
            DriverRepository driverRepository,
            HomeChefReopsitory chefRepository,
            HotelOwnerReopsitory hotelOwnerReopsitory,
            PropertyOwnerReopsitory propertownerRepository,
            RestaurantOwnerReopsitory restaurantOwnerReopsitory,
            ServiceProviderRepository serviceProviderRepository,
            TravelAgencyOwnerReopsitory travelAgencyOwnerReopsitory,
            IConfiguration configuration
            )
        {
            this.appUserRepository = appUserRepository;
            this.clientRepository = clientRepository;
            this.driverRepository = driverRepository;
            this.serviceProviderRepository = serviceProviderRepository;
            HomeChefReopsitory = chefRepository;
            HotelOwnerReopsitory = hotelOwnerReopsitory;
            this.propertownerRepository = propertownerRepository;
            RestaurantOwnerReopsitory = restaurantOwnerReopsitory;
            TravelAgencyOwnerReopsitory = travelAgencyOwnerReopsitory;
            appSettingConfiguration = configuration;
        }

        public async Task<IdentityResult> CreateAccount(UserRegisterVM user)
        {
            var userRes = await appUserRepository.Register(user);
            
            if (userRes.Succeeded)
            {
                var currentUser = await appUserRepository.FindByUserName(user.UserName);
                if (user.Role == "Client")
                {
                    //Add Record In Client table
                    clientRepository.Add(new Client() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "Driver")
                {
                    //Add Record In Driver table
                    driverRepository.Add(new Drivers { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "HomeChef")
                {
                    //Add Record In HomeChef table
                    HomeChefReopsitory.Add(new HomeChef() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "HotelOwner")
                {
                    //Add Record In HotelOwner table
                    HotelOwnerReopsitory.Add(new HotelOwners() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "PropertyOwner")
                {
                    //Add Record In PropertyOwner table
                    propertownerRepository.Add(new PropertyOwner() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "RestaurantOwner")
                {
                    //Add Record In RestaurantOwner table
                    RestaurantOwnerReopsitory.Add(new RestaurantOwner() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "ServiceProvider")
                {
                    //Add Record In ServiceProvider table
                    serviceProviderRepository.Add(new ServiceProvider() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }
                else if (user.Role == "TravelAgencyOwner")
                {
                    //Add Record In TravelAgencyOwner table
                    TravelAgencyOwnerReopsitory.Add(new TravelAgencyOwners() { UserId = currentUser.Id });
                    return IdentityResult.Success;
                }

            }
            return IdentityResult.Failed();
        }
        public async Task<bool> IsUserNameTaken(string userName)
        {
            var user = await appUserRepository.FindByUserName(userName);
            return user != null;
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            var user = await appUserRepository.FindByEmail(email);
            return user != null;
        }

        public async Task<bool> IsNationalIdTaken(string nationalId)
        {
            var user = await appUserRepository.FindById(nationalId);
            return user != null;
        }


        public async Task<SignInResult> Login(UserLoginVM user)
        {
            return await appUserRepository.Login(user);
        }

        public async Task<string> LoginWithToken(UserLoginVM user)
        {
            var res = await appUserRepository.Login(user);
            if (res.Succeeded)
            {
                //give me data to be encrpted in token
                List<Claim> claims = new List<Claim>();
                var currentUser = await appUserRepository.FindByUserName(user.UserNameOrEmail);
                if (currentUser == null)
                {
                    currentUser = await appUserRepository.FindByEmail(user.UserNameOrEmail);
                }
                var roles = await appUserRepository.GetUserRoles(currentUser);

                claims.Add(new Claim(ClaimTypes.Name, currentUser.UserName));
                claims.Add(new Claim(ClaimTypes.Email, currentUser.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, currentUser.Id));
                roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

                //make token    =>      JWT 

                JwtSecurityToken securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60), // expiration time
                    signingCredentials: new SigningCredentials(
                        algorithm: SecurityAlgorithms.HmacSha256,
                        key: new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettingConfiguration["JWT:PrivateKey"]))
                    )
                );
                return new JwtSecurityTokenHandler().WriteToken(securityToken);

            }
            else if (res.IsLockedOut || res.IsNotAllowed)
            {
                return string.Empty;
            }
            return null;

        }
        public async Task Signout()
        {
            await appUserRepository.Signout();
        }
    }
}
