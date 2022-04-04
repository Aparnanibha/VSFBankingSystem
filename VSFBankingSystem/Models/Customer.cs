using System;
using System.Collections.Generic;

namespace VSFBankingSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAccs = new HashSet<CustomerAcc>();
        }

        public decimal CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FathersName { get; set; }
        public decimal? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? OccupationType { get; set; }
        public string? SourceOfIncome { get; set; }
        public decimal? GrossAnnualIncome { get; set; }
        public string? IsDebitCardRequired { get; set; }
        public string? EnableNetBanking { get; set; }
        public decimal? AadharNumber { get; set; }

        public virtual ValidLogin ValidLogin { get; set; } = null!;
        public virtual ICollection<CustomerAcc> CustomerAccs { get; set; }
    }
}
