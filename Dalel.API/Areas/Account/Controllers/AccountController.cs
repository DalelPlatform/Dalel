using Dalel.Services;
using Dalel.ViewModels;
using LinqKit;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login([FromBody]UserLoginVM vmodel)
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
                    return new JsonResult(new
                    {
                        Massage = "Logged in Successfully",
                        Status = 200,
                        Token = res,
                        Role = role
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
        //http get check email
        //http get check national
        //http get check username
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
        public async Task<IActionResult> CheckNationalId([FromQuery] string nationalId)
        {
            var isTaken = await accountService.IsNationalIdTaken(nationalId);
            return new JsonResult(new
            {
                Status = isTaken ? 400 : 200,
                Message = isTaken ? "National ID is already used" : "National ID is available"
            });
        }


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await accountService.ForgotPasswordAsync(vm);
            return StatusCode(result.StatusCode, new
            {
                result.Success,
                result.Message,
                Token = result is ServiceResult<string> sr ? sr.Data : null
            });
        }

        // POST: api/Account/ResetPassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await accountService.ResetPasswordAsync(vm);
            return StatusCode(result.StatusCode, new
            {
                result.Success,
                result.Message
            });
        }

        // POST: api/Account/ChangePassword
        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await accountService.ChangePasswordAsync(userId, vm);
            return StatusCode(result.StatusCode, new
            {
                result.Success,
                result.Message
            });
        }

    }
}
