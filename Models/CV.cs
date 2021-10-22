using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class CV
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string PositionCategory { get; set; }
        public double ExpectedSalary { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<StudyExperience> StudyExperiences { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime UpdateDate { get; set; }



        public string UserId { get; set; }
        public User User { get; set; }
    }
}
