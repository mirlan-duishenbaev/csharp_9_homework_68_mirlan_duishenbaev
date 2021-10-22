using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string VacancyName { get; set; }
        public double SalaryValue { get; set; }
        public string JobDescription { get; set; }
        public string JobDuties { get; set; }
        public string RequiredExperience { get; set; }
        public string VacancyCategory { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<CV> CVs { get; set; }
        public List<Response> Responses { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
    }
}
