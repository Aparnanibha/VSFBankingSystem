using System;
using System.Collections.Generic;

namespace VSFBankingSystem.Models
{
    public partial class TransactionDetail
    {
        public decimal TransactionId { get; set; }
        public string? TransactionType { get; set; }
        public decimal? ToAccountNumber { get; set; }
        public decimal? AccountNumber { get; set; }
        public string? Maturityinstruct { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string? TransType { get; set; }

        public virtual CustomerAcc? AccountNumberNavigation { get; set; }
    }
}
