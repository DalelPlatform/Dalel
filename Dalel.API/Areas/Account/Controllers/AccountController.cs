using Dalel.Services;
using Dalel.ViewModels;
using LinqKit;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Models.User;
using System.Security.Claims;
using System.Text;

using Utilities;


namespace Dalel.API.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;
        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }


        [HttpGet("MyAccount")]
        public IActionResult getMyAccount()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = accountService.GetUserById(id);
            if (result == null)
                return new JsonResult(new { Success = false, Message = "User not found" });
            return new JsonResult(new { Success = true, Data = result, Message = "User retrieved successfully" });
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await accountService.GetUserById(id);
            if (user == null)
            {
                return new JsonResult(new
                {
                    Success = false,
                    Message = "User not found"
                });
            }

            return new JsonResult(new
            {
                Success = true,
                Data = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                },
                Message = "User retrieved successfully!"
            });
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterVM user)
        {

            if (ModelState.IsValid)
            {
                var res = await accountService.CreateAccount(user);
                if (res.Succeeded)
                {
                    return new JsonResult(new
                    {
                        Massage = "Your Account Added Successfully ,Go to Login",
                        Status = 200
                    });
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    res.Errors.ForEach(err => stringBuilder.Append(err.Description));
                    return new JsonResult(new
                    {
                        Massage = "Some Data Are Missing",
                        Status = 400
                    });
                }
            }
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (var item in ModelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    stringBuilder1.Append(err.ErrorMessage);
                }
            }
            return new JsonResult(new
            {
                Massage = stringBuilder1.ToString(),
                Status = 400
            });
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginVM vmodel)
        {
            if (ModelState.IsValid)
            {
                var res = await accountService.LoginWithToken(vmodel);
                if (res == null)
                {
                    return new JsonResult(new
                    {
                        Massage = "Sorry Invalid Email Or User Name Or Password",
                        Status = 400
                    });
                }
                else if (res == "")
                {
                    return new JsonResult(new
                    {
                        Massage = "Sorry try again Later!!!! Your Accout under Review",
                        Status = 400
                    });
                }
                else
                {
                    var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                    var user = await accountService.GetUserById(userId);

                    return new JsonResult(new
                    {
                        Massage = "Logged in Successfully",
                        Status = 200,
                        Token = res,
                        Role = role,
                        Image = user.ProfileImg,
                        FullName = user.FirstName + " " + user.LastName,
                    });

                }
            }
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (var item in ModelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    stringBuilder1.Append(err.ErrorMessage);
                }
            }

            return new JsonResult(new
            {
                Massage = stringBuilder1.ToString(),
                Status = 400
            });

        }

        [HttpPost("Signout")]
        public async Task<IActionResult> Signout()
        {
            await accountService.Signout();
            return new JsonResult(new
            {
                Massage = "Sign out Successfully",
                Status = 200
            });
        }

        [HttpGet("CheckUsername")]
        public async Task<IActionResult> CheckUsername([FromQuery] string username)
        {
            var isTaken = await accountService.IsUserNameTaken(username);
            return new JsonResult(new
            {
                Status = isTaken ? 400 : 200,
                Message = isTaken ? "Username is already taken" : "Username is available"
            });
        }

        [HttpGet("CheckEmail")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            var isTaken = await accountService.IsEmailTaken(email);
            return new JsonResult(new
            {
                Status = isTaken ? 400 : 200,
                Message = isTaken ? "Email is already taken" : "Email is available"
            });
        }

        [HttpGet("CheckNationalId")]
        public IActionResult CheckNationalId([FromQuery] string nationalId)
        {
            try
            {
                var isTaken =  accountService.IsNationalIdTaken(nationalId);

                return new JsonResult(new
                {
                    Status = isTaken ? 400 : 200,
                    Message = isTaken ? "National ID is already used" : "National ID is available"
                });
            }

            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    Status = 500,
                    Message = $"{ex.Message}"
                });
            }
         
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVM vm)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder errorMessages = new StringBuilder();
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        errorMessages.Append(error.ErrorMessage + " ");
                    }
                }

                return new JsonResult(new
                {
                    Message = errorMessages.ToString().Trim(),
                    Status = 400
                });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await accountService.ChangePasswordAsync(userId, vm);

            return new JsonResult(new
            {
                Message = result.Message,
                Status = result.Success ? 200 : 400
            });
        }

    }
}
