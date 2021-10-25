using HeadHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.ViewModels
{
    public class CategoryAndVacancyViewModel
    {
        public Vacancy Vacancy { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
