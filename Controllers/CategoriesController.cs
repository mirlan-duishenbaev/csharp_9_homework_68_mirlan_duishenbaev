using HeadHunter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly UserContext _context;

        public CategoriesController(UserContext context)
        {
            _context = context;
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Медицина" });
                _context.Categories.Add(new Category { Name = "Образование" });
                _context.Categories.Add(new Category { Name = "Государственная служба" });
                _context.Categories.Add(new Category { Name = "Программирование" });
                _context.Categories.Add(new Category { Name = "Промышленность" });
                _context.Categories.Add(new Category { Name = "Торговля" });
                _context.Categories.Add(new Category { Name = "Туризм" });
                _context.Categories.Add(new Category { Name = "Финансы" });
                _context.Categories.Add(new Category { Name = "Строительство" });
                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var categoties = _context.Categories.ToList();
            return View(categoties);
        }
    }
}
