﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPortfolio.Data;

namespace MyPortfolio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220127224910_TabelLinkigRoles")]
    partial class TabelLinkigRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyPortfolio.Models.BackEndTechnology", b =>
                {
                    b.Property<int>("BackEndTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackEndTechnologyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BackEndTechnologyId");

                    b.ToTable("BackEndTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.Collaborators", b =>
                {
                    b.Property<int>("CollaboratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackEndTechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("CollaboratorFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DatabaseTechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("FrontEndTechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("OtherTechnologyId")
                        .HasColumnType("int");

                    b.HasKey("CollaboratorId");

                    b.HasIndex("BackEndTechnologyId");

                    b.HasIndex("DatabaseTechnologyId");

                    b.HasIndex("FrontEndTechnologyId");

                    b.HasIndex("OtherTechnologyId");

                    b.ToTable("Collaborators");
                });

            modelBuilder.Entity("MyPortfolio.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("MyPortfolio.Models.DatabaseTechnology", b =>
                {
                    b.Property<int>("DatabaseTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DatabaseTechnologyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DatabaseTechnologyId");

                    b.ToTable("DatabaseTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.FrontEndTechnology", b =>
                {
                    b.Property<int>("FrontEndTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FrontEndName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FrontEndTechnologyId");

                    b.ToTable("FrontEndTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.OtherTechnology", b =>
                {
                    b.Property<int>("OtherTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OtherTechnologyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OtherTechnologyId");

                    b.ToTable("OtherTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.PersonalUser", b =>
                {
                    b.Property<int>("PersonalUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birthplace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("PersonalUserId");

                    b.HasIndex("SkillId");

                    b.ToTable("PersonalUser");
                });

            modelBuilder.Entity("MyPortfolio.Models.ProjectMade", b =>
                {
                    b.Property<int>("ProjectMadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackEndTechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("DatabaseTechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("FrontEndTechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("OtherTechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectMadeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectMadeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectMadeId");

                    b.HasIndex("BackEndTechnologyId");

                    b.HasIndex("DatabaseTechnologyId");

                    b.HasIndex("FrontEndTechnologyId");

                    b.HasIndex("OtherTechnologyId");

                    b.ToTable("ProjectMade");
                });

            modelBuilder.Entity("MyPortfolio.Models.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectMadeId")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.HasIndex("ProjectMadeId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("MyPortfolio.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("MyPortfolio.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyPortfolio.Models.Collaborators", b =>
                {
                    b.HasOne("MyPortfolio.Models.BackEndTechnology", "BackEndTechnology")
                        .WithMany("Collaboratorss")
                        .HasForeignKey("BackEndTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.DatabaseTechnology", "DatabaseTechnology")
                        .WithMany("Collaboratorss")
                        .HasForeignKey("DatabaseTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.FrontEndTechnology", "FrontEndTechnology")
                        .WithMany("Collaboratorss")
                        .HasForeignKey("FrontEndTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.OtherTechnology", "OtherTechnology")
                        .WithMany("Collaboratorss")
                        .HasForeignKey("OtherTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BackEndTechnology");

                    b.Navigation("DatabaseTechnology");

                    b.Navigation("FrontEndTechnology");

                    b.Navigation("OtherTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.PersonalUser", b =>
                {
                    b.HasOne("MyPortfolio.Models.Skill", null)
                        .WithMany("PersonalUsers")
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("MyPortfolio.Models.ProjectMade", b =>
                {
                    b.HasOne("MyPortfolio.Models.BackEndTechnology", "BackEndTechnology")
                        .WithMany("ProjectMades")
                        .HasForeignKey("BackEndTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.DatabaseTechnology", "DatabaseTechnology")
                        .WithMany("ProjectMades")
                        .HasForeignKey("DatabaseTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.FrontEndTechnology", "FrontEndTechnology")
                        .WithMany("ProjectMades")
                        .HasForeignKey("FrontEndTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyPortfolio.Models.OtherTechnology", "OtherTechnology")
                        .WithMany("ProjectMades")
                        .HasForeignKey("OtherTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BackEndTechnology");

                    b.Navigation("DatabaseTechnology");

                    b.Navigation("FrontEndTechnology");

                    b.Navigation("OtherTechnology");
                });

            modelBuilder.Entity("MyPortfolio.Models.Rate", b =>
                {
                    b.HasOne("MyPortfolio.Models.ProjectMade", "ProjectMade")
                        .WithMany("Rates")
                        .HasForeignKey("ProjectMadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectMade");
                });

            modelBuilder.Entity("MyPortfolio.Models.BackEndTechnology", b =>
                {
                    b.Navigation("Collaboratorss");

                    b.Navigation("ProjectMades");
                });

            modelBuilder.Entity("MyPortfolio.Models.DatabaseTechnology", b =>
                {
                    b.Navigation("Collaboratorss");

                    b.Navigation("ProjectMades");
                });

            modelBuilder.Entity("MyPortfolio.Models.FrontEndTechnology", b =>
                {
                    b.Navigation("Collaboratorss");

                    b.Navigation("ProjectMades");
                });

            modelBuilder.Entity("MyPortfolio.Models.OtherTechnology", b =>
                {
                    b.Navigation("Collaboratorss");

                    b.Navigation("ProjectMades");
                });

            modelBuilder.Entity("MyPortfolio.Models.ProjectMade", b =>
                {
                    b.Navigation("Rates");
                });

            modelBuilder.Entity("MyPortfolio.Models.Skill", b =>
                {
                    b.Navigation("PersonalUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
