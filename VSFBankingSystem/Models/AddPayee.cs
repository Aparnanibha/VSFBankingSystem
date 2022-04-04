using System;
using System.Collections.Generic;

namespace VSFBankingSystem.Models
{
    public partial class AddPayee
    {
        public decimal BeneficiaryAccountNumber { get; set; }
        public decimal? AccountNumber { get; set; }
        public string? BeneficiaryName { get; set; }
        public string? NickName { get; set; }

        public virtual CustomerAcc? AccountNumberNavigation { get; set; }
    }
}
