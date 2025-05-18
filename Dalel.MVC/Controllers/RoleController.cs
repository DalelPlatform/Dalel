using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dalel.MVC.Controllers
{
    public class RoleController : Controller
    {
        private RoleRepository roleRepository;
        public RoleController(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var list = roleRepository.GetList().Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();

            //ViewBag.Invalid = 0;
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(string roleName)
        {
            if (roleName.IsNullOrEmpty())
            {
                ViewBag.Invalid = 1;
                var list = roleRepository.GetList().Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList();
                return View(list);
            }
            else
            {
                var res = await roleRepository.Add(roleName);
                if (res.Succeeded)
                {
                    ViewBag.Invalid = 2;
                }
                else
                {
                    ViewBag.Invalid = 1;
                }
                var list = roleRepository.GetList().Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList();
                return View(list);
            }

        }


    }
}
