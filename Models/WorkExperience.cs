using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Years { get; set; }
        public string Duties { get; set; }

        public int CVId { get; set; }
        public CV CV { get; set; }
    }
}
