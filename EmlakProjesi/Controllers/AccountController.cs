using DataAccessLayer.Abstract;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using EntityLayer.Entire;
using Microsoft.Build.Framework;
using EmlakProjesi.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EmlakProjesi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IUnitofWork unitofWork, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser>? userManager,RoleManager<IdentityRole> roleManager)
        {
            _unitofWork = unitofWork;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Login(string returnUrl=null)
        {
            returnUrl??= Url.Content("~/");
            LoginVM LoginVm = new ()
            {
                RedirectUrl=returnUrl,

            };
            return View(LoginVm);
        }
        public IActionResult Register()
        {
            if(! _roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                _roleManager.CreateAsync(new IdentityRole("Customer")).Wait();
            }

            LoginVM registerList = new()
            {
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                })
            };
                
           

            return View();
        }

    }
}
