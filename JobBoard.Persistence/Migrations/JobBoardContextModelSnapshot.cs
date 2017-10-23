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
    partial class JobBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobBoard.Core.Models.Applicant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

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

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JobBoard.Core.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("CountryName")
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

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("date");

                    b.Property<string>("Address")
                        .HasMaxLength(1200);

                    b.Property<string>("Author");

                    b.Property<int>("CategoryId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<long?>("CloneFrom");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("CountryId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Currency")
                        .HasMaxLength(120);

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("EditedBy")
                        .HasMaxLength(120);

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("date");

                    b.Property<string>("EmailTo")
                        .HasMaxLength(120);

                    b.Property<int>("EmploymentTypeId");

                    b.Property<long?>("EverGreenId");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsBestPerforming");

                    b.Property<bool>("IsEverGreen");

                    b.Property<bool>("IsSponsored");

                    b.Property<int>("JobBoardId");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<string>("JobRequirements")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<short?>("MaximumExperience");

                    b.Property<short?>("MinimumExperience");

                    b.Property<int>("OfficeId");

                    b.Property<decimal?>("Salary");

                    b.Property<int>("SalaryTypeId");

                    b.Property<int>("SchedulingPod");

                    b.Property<int>("StateId");

                    b.Property<string>("Tags")
                        .HasMaxLength(255);

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

                    b.HasIndex("StateId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobBoard.Core.Models.JobBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EstreamJbsId")
                        .HasColumnName("EstreamJBsID ");

                    b.Property<bool>("IsEmailApply");

                    b.Property<bool>("IsOnlineApply");

                    b.Property<string>("JobBoardName")
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

                    b.ToTable("JobOccupation");
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

            modelBuilder.Entity("JobBoard.Core.Models.Stat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApsCl");

                    b.Property<int?>("Bob");

                    b.Property<int?>("Intvs");

                    b.Property<int?>("Intvs2");

                    b.Property<long>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("JobBoard.Core.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("StateName")
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

                    b.HasOne("JobBoard.Core.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("JobBoard.Core.Models.JobOccupation", b =>
                {
                    b.HasOne("JobBoard.Core.Models.Job", "Job")
                        .WithMany("Occupations")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobBoard.Core.Models.Occupation", "Occupation")
                        .WithMany("JobOccupations")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobBoard.Core.Models.Stat", b =>
                {
                    b.HasOne("JobBoard.Core.Models.Job", "Job")
                        .WithOne("Stat")
                        .HasForeignKey("JobBoard.Core.Models.Stat", "JobId")
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
