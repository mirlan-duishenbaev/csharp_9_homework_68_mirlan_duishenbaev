using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.Models
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<User> SiteUsers { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<StudyExperience> StudyExperiences { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
