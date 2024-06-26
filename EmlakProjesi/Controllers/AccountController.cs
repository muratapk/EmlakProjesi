﻿using DataAccessLayer.Abstract;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using EntityLayer.Entire;
using Microsoft.Build.Framework;
using EmlakProjesi.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            IEnumerable<SelectListItem> RolesTable = _roleManager.Roles.ToList().Select(u=>new SelectListItem{
            Text=u.Name,
            Value=u.Name.ToString()
            
            });
            //<select>
            //<option value="1">Adana</option>
            //<option value="2">İstanbul</option>
            //</select>
            ViewData["Roles"] = RolesTable;
            //LoginVM registerList = new()
            //{
            //    RoleList = _roleManager.Roles.Select(x => new SelectListItem
            //    {
            //        Text = x.Name,
            //        Value = x.Name
            //    })
            //};
                
           

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            ApplicationUser user = new() {
                Name = registerVM.Name,
                Email=registerVM.Email,
                PhoneNumber=registerVM.PhoneNumber,
                FirstName=registerVM.FirstName,
                LastName=registerVM.LastName,
                NormalizedEmail=registerVM.Email.ToUpper(),
                EmailConfirmed=true,
                CreateAt=DateTime.Now,
                

            };

            var result = await _userManager.CreateAsync(user,registerVM.PassWord);
            
            if(result.Succeeded)
            {
                if(!string.IsNullOrEmpty(registerVM.Role))
                {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index","Admin");
                
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            IEnumerable<SelectListItem> RolesTable = _roleManager.Roles.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name.ToString()

            });
            ViewData["Roles"] = RolesTable;
            return View();
        }

          
    }
}
