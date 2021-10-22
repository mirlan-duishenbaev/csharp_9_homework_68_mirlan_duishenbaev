using HeadHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.ViewModels
{
    public class CvUserViewModel
    {
        public User User { get; set; }
        public IEnumerable<CV> CVs { get; set; }
        public IEnumerable<Vacancy> Vacancies { get; set; }

    }
}
