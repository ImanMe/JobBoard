using JobBoard.Core.Models;
using System;
using System.Collections.Generic;

namespace JobBoard.Core.DTOs
{
    public class JobFormDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string JobDescription { get; set; }

        public string JobRequirements { get; set; }

        public decimal? Salary { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public bool IsEverGreen { get; set; }

        public int SchedulingPod { get; set; }

        public int OfficeId { get; set; }

        public short? MinimumExperience { get; set; }

        public short? MaximumExperience { get; set; }

        public string CompanyName { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string EmailTo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string EditedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public string Division { get; set; }

        public string Currency { get; set; }

        public string[] Currencies { get; set; }

        public bool IsBestPerforming { get; set; }

        public bool IsOnlineApply { get; set; }

        public string Author { get; set; }

        public int JobBoardId { get; set; }

        public IEnumerable<Models.JobBoard> JobBoards { get; set; }

        public bool IsEmailApply { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public int EmploymentTypeId { get; set; }

        public IEnumerable<EmploymentType> EmploymentTypes { get; set; }

        public int SalaryTypeId { get; set; }

        public IEnumerable<SalaryType> SalaryTypes { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public int StateId { get; set; }

        public IEnumerable<State> States { get; set; }

        public int[] OccupationsSelected { get; set; }

        public IEnumerable<Occupation> Occupations { get; set; }

        public DateTime GetActivationDate() => DateTime.Parse($"{ActivationDate}");

        public DateTime GetExpirationDate() => DateTime.Parse($"{ExpirationDate}");

        public int? Bob { get; set; }

        public int? Intvs { get; set; }

        public int? Intvs2 { get; set; }

        public int? ApsCl { get; set; }

        public bool IsClone { get; set; }
    }
}
