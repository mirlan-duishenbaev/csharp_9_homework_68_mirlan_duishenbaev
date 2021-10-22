using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class StudyExperience
    {
        public int Id { get; set; }
        public string InstituteName { get; set; }
        public string Years { get; set; }
        public string Specialization { get; set; }

        public int CVId { get; set; }
        public CV CV { get; set; }
    }
}
