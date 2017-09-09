﻿// <auto-generated />
using JobBoard.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JobBoard.Persistence.Migrations
{
    [DbContext(typeof(JobBoardContext))]
    [Migration("20170826034041_Fix")]
    partial class Fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobBoard.Core.Models.Applicant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("FileName");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<long>("JobId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Phone")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("JobBoard.Core.Models.EmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Job", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivationDate");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1200);

                    b.Property<int>("ApsCl");

                    b.Property<string>("Author");

                    b.Property<int>("Bob");

                    b.Property<int>("CategoryId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<long>("CloneFrom");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("CountryId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("EditedBy")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<DateTime>("EditedDate");

                    b.Property<string>("EmailTo")
                        .HasMaxLength(120);

                    b.Property<int>("EmploymentTypeId");

                    b.Property<long>("EverGreenId");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<int>("Intvs");

                    b.Property<int>("Intvs2");

                    b.Property<bool>("IsBestPerforming");

                    b.Property<bool>("IsEverGreen");

                    b.Property<bool>("IsOnlineApply");

                    b.Property<int>("JobBoardId");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<string>("JobRequirements")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<short>("MaximumExperience");

                    b.Property<short>("MinimumExperience");

                    b.Property<int>("OfficeId");

                    b.Property<decimal>("Salary");

                    b.Property<int>("SalaryTypeId");

                    b.Property<int>("SchedulingPod");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("JobBoardId");

                    b.HasIndex("SalaryTypeId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobBoard.Core.Models.JobBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EstreamJbsId");

                    b.Property<bool>("IsEmailApply");

                    b.Property<bool>("IsOnlineApply");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("JobBoards");
                });

            modelBuilder.Entity("JobBoard.Core.Models.JobOccupation", b =>
                {
                    b.Property<long>("JobId");

                    b.Property<int>("OccupationId");

                    b.HasKey("JobId", "OccupationId");

                    b.HasIndex("OccupationId");

                    b.ToTable("JobOccupations");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OccupationCategory")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("OccupationName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("JobBoard.Core.Models.SalaryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SalaryTypes");
                });

            modelBuilder.Entity("JobBoard.Core.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Job", b =>
                {
                    b.HasOne("JobBoard.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.JobBoard", "JobBoard")
                        .WithMany()
                        .HasForeignKey("JobBoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.SalaryType", "SalaryType")
                        .WithMany()
                        .HasForeignKey("SalaryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobBoard.Core.Models.JobOccupation", b =>
                {
                    b.HasOne("JobBoard.Core.Models.Job", "Job")
                        .WithMany("JobOccupations")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.Occupation", "Occupation")
                        .WithMany("JobOccupations")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobBoard.Core.Models.State", b =>
                {
                    b.HasOne("JobBoard.Core.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
