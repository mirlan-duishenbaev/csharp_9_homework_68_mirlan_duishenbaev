using HeadHunter.Models;
using HeadHunter.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Controllers
{
    public class AccountController : Controller
    {
        private UserContext _db;
        private IMemoryCache cache;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        IWebHostEnvironment _appEnvironment;

        public AccountController(UserContext db,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment appEnvironment,
            IMemoryCache memoryCache)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _appEnvironment = appEnvironment;
            cache = memoryCache;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    model.RememberMe,
                    false
                    );
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("UserCabinet");
                }
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {

                if (uploadedFile == null)
                {
                    if(model.Role == "applicant")
                    {
                        string path = "/Files/applicant.png";
                        FileModel file = new FileModel { Name = "default_avatar.png", Path = path };
                        _db.Files.Add(file);
                        model.Avatar = file.Path;
                    }
                    else
                    {
                        string path = "/Files/employee.png";
                        FileModel file = new FileModel { Name = "default_avatar.png", Path = path };
                        _db.Files.Add(file);
                        model.Avatar = file.Path;
                    }
                }
                else
                {
                    string path = "/Files/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                    _db.Files.Add(file);
                    model.Avatar = file.Path;
                }


                User user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Avatar = model.Avatar,
                    Role = model.Role
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }
}
