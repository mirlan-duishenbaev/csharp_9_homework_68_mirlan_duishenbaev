using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public string Company { get; set; }
        public string Avatar { get; set; }

        public string TelegramProof { get; set; }
        public string FacebookProof { get; set; }
        public string LinkedInProof { get; set; }
    }
}
