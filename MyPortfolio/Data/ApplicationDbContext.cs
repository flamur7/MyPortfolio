using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Areas.Admin.Models;
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

        public virtual DbSet<ProjectMade> ProjectMades { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Collaborators> Collaboratorss { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DatabaseTechnology> DatabaseTechnology { get; set; }
        public virtual DbSet<FrontEndTechnology> FrontEndTechnology { get; set; }
        public virtual DbSet<BackEndTechnology> BackEndTechnology { get; set; }
        public virtual DbSet<OtherTechnology> OtherTechnology { get; set; }
        public virtual DbSet<PersonalUser> PersonalUsers { get; set; }

    }
}
