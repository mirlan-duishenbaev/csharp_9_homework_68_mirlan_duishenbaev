using HeadHunter.Models;
using HeadHunter.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Controllers
{
    public class VacanciesController : Controller
    {
        private UserContext _db;
        private readonly UserManager<User> _userManager;


        public VacanciesController(UserContext db,
            UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        private async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        public IActionResult Add()
        {
            var categories = _db.Categories.ToList();
            var vacancyAndCategory = new CategoryAndVacancyViewModel
            {
                CategoryList = categories
            };
            return View(vacancyAndCategory);
        }

        [HttpPost]
        public IActionResult Add(CategoryAndVacancyViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    Vacancy vacancy = new Vacancy
                    {
                        VacancyName = model.Vacancy.VacancyName,
                        CategoryId = model.Vacancy.CategoryId,
                        Category = model.Vacancy.Category,
                        SalaryValue = model.Vacancy.SalaryValue,
                        JobDescription = model.Vacancy.JobDescription,
                        JobDuties = model.Vacancy.JobDuties,
                        RequiredExperience = model.Vacancy.RequiredExperience,
                        PostDate = DateTime.Now,
                        UserId = GetCurrentUser().Result.Id,
                        User = _db.SiteUsers.FirstOrDefault(x => x.Id == GetCurrentUser().Result.Id)
                    };

                    _db.Vacancies.Add(vacancy);
                    _db.SaveChanges();
                }
                return RedirectToAction("UserPage", "Account");
            }
            return RedirectToAction("Add");
        }


        public IActionResult Index()
        {
            List<Vacancy> vacancies = _db.Vacancies.ToList();

            return View(vacancies);
        }

        public async Task<IActionResult> VacancyPage(int vacancyId)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = await _db.Vacancies.Include(x => x.User)
                        .Include(x => x.Category)
                        .FirstOrDefaultAsync(x => x.Id == vacancyId);


                    var responses = _db.Responses.ToList();

                    VacancyPageViewModel model = new VacancyPageViewModel
                    {
                        User = GetCurrentUser().Result,
                        Vacancy = vacancy
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                Vacancy vacancy = await _db.Vacancies.Include(x => x.User)
                        .FirstOrDefaultAsync(x => x.Id == vacancyId);

                VacancyPageViewModel model = new VacancyPageViewModel
                {
                    Vacancy = vacancy
                };

                return View(model);
            }
        }

        public async Task<IActionResult> Respond(int vacancyId)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = await _db.Vacancies.Include(x => x.User)
                        .FirstOrDefaultAsync(x => x.Id == vacancyId);

                    User user = GetCurrentUser().Result;

                    Response response = new Response { User = user };

                    _db.Responses.Add(response);

                    if(vacancy.Responses == null)
                    {
                        vacancy.Responses = new List<Response> { response };
                    }
                    else
                    {
                        vacancy.Responses.Add(response);
                    }

                    _db.Vacancies.Update(vacancy);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("VacancyPage", new { vacancyId });
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

    }
}
