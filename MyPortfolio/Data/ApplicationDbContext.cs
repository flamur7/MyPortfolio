using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyPortfolio.Models.BackEndTechnology> BackEndTechnology { get; set; }
        public DbSet<MyPortfolio.Models.Collaborators> Collaborators { get; set; }
        public DbSet<MyPortfolio.Models.DatabaseTechnology> DatabaseTechnology { get; set; }
        public DbSet<MyPortfolio.Models.FrontEndTechnology> FrontEndTechnology { get; set; }
        public DbSet<MyPortfolio.Models.OtherTechnology> OtherTechnology { get; set; }
        public DbSet<MyPortfolio.Models.ProjectMade> ProjectMade { get; set; }
        public DbSet<MyPortfolio.Models.PersonalUser> PersonalUser { get; set; }
        public DbSet<MyPortfolio.Models.Skill> Skill { get; set; }
    }
}
