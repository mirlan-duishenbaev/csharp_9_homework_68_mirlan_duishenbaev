using HeadHunter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Controllers
{
    public class CVsController : Controller
    {
        private UserContext _db;
        private IMemoryCache cache;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        IWebHostEnvironment _appEnvironment;

        public CVsController(UserContext db,
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

        public IActionResult CreateCv()
        {
            return View();
        }

        private async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpPost]
        public IActionResult CreateCv(CV cV)
        {
            
            
            if (cV != null)
            {
                CV cv = new CV
                {
                    User = GetCurrentUser().Result,
                    PositionName = cV.PositionName,
                    PositionCategory = cV.PositionCategory,
                    ExpectedSalary = cV.ExpectedSalary,
                    PostDate = DateTime.Now,
                };

                _db.CVs.Add(cv);
                _db.SaveChanges();
            }

            return RedirectToAction("UserPage", "Account");
        }

    }
}
